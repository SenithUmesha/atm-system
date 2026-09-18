IF DB_ID('ZEMO_Bank') IS NULL
BEGIN
    CREATE DATABASE ZEMO_Bank;
END
GO

USE ZEMO_Bank;
GO

-- Development schema for the historical WinForms banking simulation.
-- This script contains only local demo data. It is not a production banking schema.

DROP TABLE IF EXISTS SecurityAlerts;
DROP TABLE IF EXISTS EReceipt;
DROP TABLE IF EXISTS FundTransfer;
DROP TABLE IF EXISTS BillPayment;
DROP TABLE IF EXISTS RecentT;
DROP TABLE IF EXISTS NearbyATMs;
DROP TABLE IF EXISTS ManagementAccountDetails;
DROP TABLE IF EXISTS UserAccountDetails;
GO

CREATE TABLE UserAccountDetails (
    Name varchar(80) NOT NULL,
    AccNo varchar(20) NOT NULL PRIMARY KEY,
    Password varchar(255) NULL,
    Address varchar(160) NULL,
    Contact_number varchar(30) NULL,
    Birth_of_date date NULL,
    Email varchar(160) NULL,
    Pin varchar(255) NOT NULL,
    Balance decimal(18,2) NOT NULL CONSTRAINT DF_UserAccountDetails_Balance DEFAULT (0),
    CONSTRAINT CK_UserAccountDetails_Balance CHECK (Balance >= 0)
);
GO

CREATE INDEX IX_UserAccountDetails_Name
    ON UserAccountDetails(Name);
GO

CREATE UNIQUE INDEX UX_UserAccountDetails_Email
    ON UserAccountDetails(Email)
    WHERE Email IS NOT NULL;
GO

CREATE TABLE ManagementAccountDetails (
    Name varchar(80) NOT NULL,
    AccNo varchar(20) NOT NULL PRIMARY KEY,
    Password varchar(255) NOT NULL
);
GO

CREATE TABLE RecentT (
    TransactionId bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AccNo varchar(20) NOT NULL,
    Type varchar(60) NOT NULL,
    Date datetime2 NOT NULL,
    Amount decimal(18,2) NOT NULL,
    CONSTRAINT FK_RecentT_UserAccount
        FOREIGN KEY (AccNo) REFERENCES UserAccountDetails(AccNo),
    CONSTRAINT CK_RecentT_Amount CHECK (Amount > 0)
);
GO

CREATE INDEX IX_RecentT_AccountDate
    ON RecentT(AccNo, Date DESC);
GO

CREATE TABLE BillPayment (
    PaymentId bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AccNo varchar(20) NOT NULL,
    BillNo varchar(30) NOT NULL,
    Type varchar(80) NOT NULL,
    Date datetime2 NOT NULL,
    Amount decimal(18,2) NOT NULL,
    CONSTRAINT FK_BillPayment_UserAccount
        FOREIGN KEY (AccNo) REFERENCES UserAccountDetails(AccNo),
    CONSTRAINT CK_BillPayment_Amount CHECK (Amount > 0)
);
GO

CREATE INDEX IX_BillPayment_AccountDate
    ON BillPayment(AccNo, Date DESC);
GO

CREATE TABLE FundTransfer (
    TransferId bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AccNo varchar(20) NOT NULL,
    RAccNo varchar(20) NOT NULL,
    Date datetime2 NOT NULL,
    Amount decimal(18,2) NOT NULL,
    CONSTRAINT FK_FundTransfer_Sender
        FOREIGN KEY (AccNo) REFERENCES UserAccountDetails(AccNo),
    CONSTRAINT FK_FundTransfer_Recipient
        FOREIGN KEY (RAccNo) REFERENCES UserAccountDetails(AccNo),
    CONSTRAINT CK_FundTransfer_Amount CHECK (Amount > 0),
    CONSTRAINT CK_FundTransfer_DifferentAccounts CHECK (AccNo <> RAccNo)
);
GO

CREATE INDEX IX_FundTransfer_SenderDate
    ON FundTransfer(AccNo, Date DESC);
GO

CREATE TABLE NearbyATMs (
    ATMNo varchar(20) NOT NULL PRIMARY KEY,
    Branch varchar(80) NOT NULL,
    Location varchar(120) NOT NULL,
    Distance varchar(20) NOT NULL
);
GO

CREATE TABLE EReceipt (
    AccNo varchar(20) NOT NULL PRIMARY KEY,
    Status varchar(10) NULL,
    Date datetime2 NULL,
    CONSTRAINT FK_EReceipt_UserAccount
        FOREIGN KEY (AccNo) REFERENCES UserAccountDetails(AccNo)
);
GO

CREATE TABLE SecurityAlerts (
    AlertId bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
    AccNo varchar(20) NOT NULL,
    Type varchar(60) NOT NULL,
    Date datetime2 NOT NULL,
    Amount decimal(18,2) NULL,
    CONSTRAINT FK_SecurityAlerts_UserAccount
        FOREIGN KEY (AccNo) REFERENCES UserAccountDetails(AccNo)
);
GO

CREATE INDEX IX_SecurityAlerts_AccountDate
    ON SecurityAlerts(AccNo, Date DESC);
GO

-- Obvious local demo accounts. These intentionally use the old plaintext format so
-- the application's compatibility path can upgrade them to PBKDF2 after first login.
-- Do not reuse these credentials anywhere outside this disposable development database.

INSERT INTO UserAccountDetails
    (Name, AccNo, Password, Address, Contact_number, Birth_of_date, Email, Pin, Balance)
VALUES
    ('Demo User', '1000000001', NULL, 'Demo Street', '0000000000', '2000-01-01', NULL, '1234', 2500.00),
    ('Demo Recipient', '1000000002', NULL, 'Demo Avenue', '0000000001', '2000-01-02', NULL, '5678', 750.00);
GO

INSERT INTO ManagementAccountDetails(Name, AccNo, Password)
VALUES ('Demo Admin', 'M001', 'demo-admin');
GO

INSERT INTO NearbyATMs(ATMNo, Branch, Location, Distance)
VALUES
    ('ATM001', 'Galle', 'Main Branch', '0 km'),
    ('ATM002', 'Karapitiya', 'Hospital Road', '4 km'),
    ('ATM003', 'Unawatuna', 'Matara Road', '6 km');
GO
