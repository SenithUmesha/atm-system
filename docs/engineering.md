# ZEMO ATM — engineering notes

This document describes the project as it actually exists: a 2021 C# WinForms banking **simulation** built with .NET Framework 4.7.2, SQL Server, a large set of forms/user controls, printable DataGridViews and optional SMTP email.

It is intentionally not presented as real banking infrastructure.

The useful engineering story is the gap between the original screen-by-screen implementation and the invariants that become necessary as soon as an application starts moving balances between accounts.

## 1. system shape

The original application is one Windows desktop process talking directly to SQL Server.

```text
WinForms
   │
   ├── customer screens
   ├── admin screens
   ├── transaction flows
   └── settings / receipts
   │
   ▼
System.Data.SqlClient
   │
   ▼
ZEMO_Bank
```

There is no backend API.

That distinction matters. The current cleanup improves the repository and makes its transaction semantics clearer, but the desktop app still lives inside a trust boundary that would be inappropriate for a real financial system.

A modern version would never distribute SQL credentials or allow clients to mutate balances directly.

## 2. customer and management surfaces

The app has two sign-in modes.

```text
Home
 ├── customer login
 │      ↓
 │    Dash1
 │      ├── Withdrawal
 │      ├── Deposit
 │      ├── Balance
 │      ├── RecentT
 │      ├── BillPayment
 │      ├── FastCash
 │      ├── FundTransfer
 │      └── Settings
 │
 └── management login
        ↓
      AdminDash
        ├── account details
        ├── transactions
        ├── transfers
        ├── bill payments
        ├── e-receipts
        ├── security alerts
        └── ATM directory
```

The old architecture lets each form own a lot of its own data access.

The cleanup leaves the UI recognizable while pulling shared database concerns toward a few small services.

## 3. current shared boundaries

The most important shared pieces are now:

```text
Infrastructure/
 ├── Database.cs
 └── GridData.cs

Security/
 └── CredentialHasher.cs

Services/
 ├── BankingService.cs
 └── EmailService.cs
```

### Database

Owns connection-string resolution and opening SQL connections.

### BankingService

Owns the balance-changing operations and e-receipt/account helpers.

### GridData

Owns read-only tabular queries used by admin/search screens.

### CredentialHasher

Owns PBKDF2 hashing and legacy development-credential migration.

### EmailService

Owns optional SMTP configuration and HTML-template loading.

This is deliberately a small refactor rather than an attempt to retrofit a large enterprise architecture onto coursework.

## 4. database configuration

The old source repeated a developer-specific SQL Server connection string across many forms.

Current database configuration checks:

```text
ZEMO_DB_CONNECTION_STRING
```

and otherwise falls back to:

```text
(LocalDB)\MSSQLLocalDB
database: ZEMO_Bank
integrated security
```

That has two useful effects:

1. the public repository no longer depends on one developer machine;
2. database configuration is no longer copied into every event handler.

A production client should still not connect directly to the financial database. Environment configuration only makes sense here because this is a local desktop simulation.

## 5. credential storage

The original schema used short plaintext fields for customer PINs and management passwords.

The current project supports PBKDF2-HMAC-SHA256.

The stored shape is self-describing:

```text
pbkdf2-sha256
      $
iteration count
      $
base64 salt
      $
base64 derived key
```

The current parameters are:

- random 16-byte salt
- 100,000 PBKDF2 iterations
- SHA-256
- 32-byte derived key

The exact values are less important than the architectural correction: authentication no longer requires equality against plaintext database credentials.

## 6. legacy development migration

The replacement development database intentionally includes obvious demo credentials in the historical plaintext form.

That exists to exercise the compatibility path.

At sign in:

```text
load stored credential
        │
        ├── encoded PBKDF2
        │       ↓
        │     verify
        │
        └── legacy local plaintext
                ↓
             compare
                ↓ success
         replace with PBKDF2
```

This is useful for old local data.

It should not be interpreted as a complete production credential-migration design. A real migration would require much more around policy, session invalidation, lockout, auditing, credential reset and operational rollout.

## 7. signed-in state

The historical application uses static fields for session state:

```text
Home.signinName
Home.signinPin
Home.signinAccNo
Dash1.AccNo
```

The cleanup improves one important part: the authenticated account number is resolved during sign-in and then carried through the session.

Previously many screens repeatedly queried accounts by PIN.

Using the account number is less ambiguous and avoids making the PIN double as an account identifier.

However, static session fields are still global mutable state.

A cleaner desktop model would be:

```text
UserSession
 ├── AccountNumber
 ├── DisplayName
 └── roles / capabilities
```

passed or injected into the screens that require it.

The plaintext PIN would not remain in session state in a production design.

## 8. why balance changes need transactions

A balance update and its history entry describe one logical operation.

The original project performed them as separate connections/commands.

Example:

```text
UPDATE balance       ✓
close connection
INSERT RecentT       ✗
```

Now the application has a state it cannot explain.

The current `BankingService` treats the related writes as one SQL transaction.

That is the central correctness improvement in this overhaul.

## 9. deposit flow

A deposit now follows:

```text
BEGIN
  UPDATE balance = balance + amount
  INSERT RecentT
  SELECT resulting balance
COMMIT
```

If either the balance update or history write fails, the transaction is rolled back.

The amount is parsed as `decimal`, not `double`, in the cleaned UI path.

The simulation still does not model cash acceptance, deposit verification or settlement. It only models the account-state change.

## 10. withdrawal flow

Withdrawal uses a guarded update:

```sql
UPDATE UserAccountDetails
SET Balance = Balance - @Amount
WHERE AccNo = @AccNo
  AND Balance >= @Amount
```

That is better than this shape:

```text
SELECT balance
if balance >= amount
    UPDATE balance
```

because another transaction could change the balance between the read and write.

The withdrawal transaction uses serializable isolation and verifies that exactly one account row was updated.

The history entry is committed with the debit.

## 11. fast cash

The original `FastCash.cs` had essentially the same database routine copied six times for fixed amounts.

Current handlers are intentionally tiny:

```text
10   ┐
20   │
30   │
50   ├──> ProcessFastCash(amount)
80   │
100  ┘
```

The helper calls the same transactional withdrawal path as a normal withdrawal.

This is a good example of a refactor that reduces bugs without changing the old UI.

## 12. the fund-transfer correctness bug

The original transfer flow:

```text
read sender balance
      ↓
debit sender
      ↓
write RecentT
      ↓
write FundTransfer
```

It recorded the recipient account number, but it never credited that recipient.

So it was a transfer log attached to a one-sided debit.

The current operation explicitly models both sides.

```text
BEGIN SERIALIZABLE
        │
        ├── recipient exists?
        │
        ├── sender != recipient?
        │
        ├── debit sender if balance is sufficient
        │
        ├── credit recipient
        │
        ├── sender history
        │
        ├── recipient history
        │
        └── transfer record
        │
      COMMIT
```

Any failure rolls back both accounts.

This still is not a double-entry ledger, but it restores the minimum invariant expected from this simulation:

```text
money removed from sender
==
money added to recipient
```

## 13. why this still is not a ledger

The account table owns a mutable `Balance` column and the transaction tables are supporting history.

A real ledger normally reverses that relationship.

Conceptually:

```text
immutable postings
       ↓
account balance/read model
```

rather than:

```text
mutable balance
       +
best-effort history
```

That distinction becomes important for auditability, corrections, replay, reconciliation and idempotency.

The historical app remains a balance simulator.

## 14. bill-payment transaction

Electricity and water share the same transactional operation.

Inputs:

```text
account
bill number
provider
transaction type
amount
timestamp
```

Database work:

```text
BEGIN
  guarded account debit
  RecentT insert
  BillPayment insert
COMMIT
```

Only after commit does the UI decide how to present the receipt.

This ordering keeps an email or printer problem out of the accounting transaction.

## 15. printable receipts vs email receipts

The original app used DataGridView printing for local receipts and SMTP for e-receipts.

That behavior is preserved.

The cleaned flow is:

```text
payment committed
      │
      ▼
e-receipt enabled?
   /          \
 no           yes
 │             │
print       SMTP configured?
receipt       /       \
            no        yes
            │          │
          print      send
            │        /   \
            │     success fail
            │        │     │
            └────────┘   print fallback
```

Receipt delivery failure is therefore not treated as payment failure.

## 16. email boundary

The old forms contained SMTP host settings, credentials and developer-machine template paths.

The current `EmailService` uses environment variables:

```text
ZEMO_SMTP_HOST
ZEMO_SMTP_PORT
ZEMO_SMTP_USERNAME
ZEMO_SMTP_PASSWORD
ZEMO_SMTP_FROM
```

Templates are loaded relative to the application directory.

The project file copies these files to the output folder:

```text
index.html
ProfileAlert.html
TransactionAlert.html
```

Template replacement values are HTML-encoded before insertion.

This is safer repository hygiene, but a deployed application should still send mail from a trusted backend rather than distributing reusable SMTP credentials to desktop clients.

## 17. security alerts

The simulation records two broad alert types in the current UI:

- a transaction alert for a large withdrawal;
- a profile alert when the PIN changes.

A large withdrawal is defined by the historical UI threshold, currently greater than 1000.

The database record is independent of SMTP.

If mail is configured, the app attempts the corresponding message after recording the alert.

## 18. PIN changes

Changing a PIN now checks:

- current PIN matches the active session;
- the new PIN is exactly four digits;
- confirmation matches;
- new and old PIN differ.

The stored value is PBKDF2, while the current in-process session keeps the new plaintext PIN because several historical screens still ask the user to re-enter and compare it locally.

That latter behavior is an explicit remaining limitation.

A modern design would re-authenticate through a trusted identity service instead of retaining the PIN in a static field.

## 19. e-receipt preference state

The historical application stores:

```text
EReceipt
 ├── AccNo
 ├── Status
 └── Date
```

The `Date` represents when the preference was enabled.

The UI preserves the original 30-day restriction before disabling.

The current service uses one row per account and performs an upsert-style update.

This is product state, not accounting state, so it intentionally lives outside the money transaction tables.

## 20. admin data exposure

The old admin account screen used:

```sql
SELECT * FROM UserAccountDetails
```

That meant whatever credential columns existed in that table were part of the grid source.

The current admin account query explicitly selects only account metadata:

```text
Name
AccNo
Address
Contact_number
Birth_of_date
Email
Balance
```

PIN/password values are not loaded into that grid.

This is a small but important example of not treating `SELECT *` as harmless just because the UI is called “admin”.

## 21. search parameterization

Several old admin/ATM search screens used text concatenation for prefix search.

Current `GridData` and `NearbyATM` paths use:

```sql
... WHERE AccNo LIKE @Prefix
```

or:

```sql
... WHERE ATMNo LIKE @Prefix
```

with the prefix passed as a SQL parameter.

The table and search-column names inside `GridData` are code-owned constants, not user-provided identifiers.

## 22. the repaired development schema

The original `Database.sql` was useful as a snapshot but had multiple historical issues, including foreign keys pointing at a differently named account table.

The replacement schema is still intentionally small, but it is internally coherent.

### UserAccountDetails

Contains customer profile fields, hash-capable credential columns and a nonnegative decimal balance.

### ManagementAccountDetails

Contains management login records with hash-capable password storage.

### RecentT

Represents account transaction history.

It now has a stable identity primary key and an account/date index.

### FundTransfer

Stores sender, recipient, date and amount.

Both accounts are foreign keys and self-transfer is rejected.

### BillPayment

Stores account, bill number, provider/type, date and amount.

### EReceipt

One preference row per account.

### SecurityAlerts

Stores account, alert type, date and optional amount.

### NearbyATMs

Keeps the static location/distance dataset used by the original UI.

## 23. money types

The cleaned service uses `decimal` for money.

That is better than floating-point `double` for exact decimal values.

A serious financial design would go further and make currency explicit.

Possible models include:

```text
Money
 ├── minorUnits: long
 └── currency: ISO code
```

or a fixed decimal type with strict scale/currency rules.

The current project still renders the historical UI currency symbol directly and does not model multiple currencies.

## 24. concurrency

The most sensitive operations use SQL transactions, and withdrawals/transfers use serializable isolation.

That protects the small local model much better than separate reads/writes.

It is not the same as a complete high-throughput transaction system.

A modern backend would likely use explicit command/idempotency identifiers, row/version controls or database-specific locking strategy, immutable ledger postings and tests that deliberately race concurrent commands.

## 25. idempotency

The project has no idempotency key.

If a user manages to submit the same transfer command twice, the database sees two legitimate transfers.

That is acceptable for this desktop exercise but not for networked financial commands where clients retry after timeouts.

A modern transfer API might require:

```text
Idempotency-Key: <unique command id>
```

and persist the first result so retries cannot duplicate the movement.

## 26. failure boundaries

The cleanup intentionally separates three kinds of failure.

### accounting failure

Examples:

- insufficient balance
- missing recipient
- SQL write failure

These prevent or roll back the money transaction.

### presentation failure

Examples:

- local receipt printer unavailable

The accounting operation is already complete.

### notification failure

Examples:

- SMTP unavailable
- missing email address

The accounting operation remains successful.

That separation makes error messages much less likely to lie about the state of the account.

## 27. static ATM directory

The nearby-ATM data is local database data.

The original UI even describes distances relative to one branch.

It is therefore a static demo dataset, not a location-aware ATM discovery service.

A current product would likely use geospatial coordinates, device location, remote configuration and distance calculations rather than storing human-written distance strings.

## 28. admin console

The management area is effectively a read/reporting console.

Its screens load a table, optionally filter by an account prefix and can print the grid.

That is useful for demonstrating the full data footprint of the simulation, but a real admin tool would need granular authorization, audit events, masking, pagination, server-side filtering and explicit capabilities per role.

Simply having a “management login” is not sufficient authorization architecture.

## 29. repository hygiene

The original repository included Visual Studio state, compiled output and a full restored NuGet package directory.

Those are generated/machine-local artifacts.

The cleaned repository keeps source and dependency declarations instead:

```text
ATM.sln
ATM/ATM.csproj
ATM/packages.config
source
designer/resource files
HTML templates
Database.sql
docs
```

NuGet packages should be restored by tooling rather than stored in Git.

The `.Designer.cs` and `.resx` files are different: they are source/resources required by WinForms and remain tracked.

## 30. build reproducibility

CI restores NuGet packages and builds the solution on Windows using MSBuild.

That is intentionally closer to the project's historical toolchain than migrating the repository to a new SDK-style project merely to make CI fashionable.

CI also checks that generated folders are not tracked and that the obvious developer-machine credential/path patterns do not return to active source.

## 31. testing gap

The original project has no useful automated domain-test seam.

Moving balance-changing code into `BankingService` makes that boundary more obvious, but the current service still talks directly to SQL Server.

A modern rebuild would separate transaction policy from persistence so scenarios such as these can be tested cheaply:

```text
deposit 25
withdraw with insufficient funds
transfer to missing account
self-transfer
concurrent withdrawals
duplicate command retry
bill payment rollback
email failure after successful payment
```

For this historical repo, CI compilation plus the explicit transactional code is a proportional stopping point.

## 32. what I would rebuild today

The fundamental architecture would change from:

```text
desktop client
     │
     ▼
SQL Server
```

to:

```text
client
  │
  ▼
authenticated backend
  │
  ├── identity / authorization
  ├── accounts
  ├── transaction commands
  ├── receipt delivery
  ├── admin APIs
  └── audit
  │
  ▼
ledger / database
```

The client would never receive database credentials.

It would also never decide for itself whether it is allowed to perform an operation.

## 33. a better transaction model

A stronger conceptual model would use commands and postings.

```text
TransferCommand
 ├── commandId
 ├── sender
 ├── recipient
 ├── money
 └── requestedAt

LedgerTransaction
 ├── transactionId
 ├── commandId
 └── postings[]
       ├── sender  -25
       └── recipient +25
```

The invariant becomes:

```text
sum(postings) == 0
```

rather than hoping two mutable account updates remain synchronized forever.

Again, that is a rebuild direction, not something being retrofitted into the old coursework app.

## 34. why keep the old UI?

Because the point of this repository is the progression.

Replacing every form with a new framework would remove the evidence of what was actually built.

The more useful cleanup is to keep the 2021 WinForms experience intact while making the public repository:

- safer to clone;
- less dependent on one machine;
- clearer about its limitations;
- correct about transfers;
- transactional around core balance changes;
- explicit about where a real system would need a very different trust model.

## 35. final takeaway

The most important lesson in this project is not “how to build an ATM.”

It is that once an application starts representing money, even a student simulation quickly exposes invariants that ordinary CRUD can get away with ignoring.

A few related SQL writes are not automatically one operation.

A transfer is not complete because a row says “transfer.”

A receipt failure is not a payment failure.

An admin screen should not load secrets just because the user is an admin.

And a desktop application with direct database access is not a secure banking architecture merely because the UI looks like one.

That is why this repo is still worth keeping around.
