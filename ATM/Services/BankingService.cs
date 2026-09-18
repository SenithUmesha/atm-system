using System;
using System.Data;
using System.Data.SqlClient;

namespace ATM
{
    internal static class BankingService
    {
        public static decimal GetBalance(string accountNumber)
        {
            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT Balance FROM UserAccountDetails WHERE AccNo = @AccNo", connection))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                object value = command.ExecuteScalar();
                if (value == null || value == DBNull.Value)
                {
                    throw new InvalidOperationException("Account could not be found.");
                }

                return Convert.ToDecimal(value);
            }
        }

        public static decimal Deposit(string accountNumber, decimal amount, DateTime occurredAt)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            using (SqlConnection connection = Database.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    using (SqlCommand update = new SqlCommand(
                        "UPDATE UserAccountDetails SET Balance = Balance + @Amount WHERE AccNo = @AccNo",
                        connection, transaction))
                    {
                        update.Parameters.AddWithValue("@Amount", amount);
                        update.Parameters.AddWithValue("@AccNo", accountNumber);

                        if (update.ExecuteNonQuery() != 1)
                        {
                            throw new InvalidOperationException("Account could not be found.");
                        }
                    }

                    InsertRecentTransaction(connection, transaction, accountNumber, "Deposit", occurredAt, amount);
                    decimal balance = GetBalance(connection, transaction, accountNumber);

                    transaction.Commit();
                    return balance;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static bool TryWithdraw(
            string accountNumber,
            decimal amount,
            string transactionType,
            DateTime occurredAt,
            out decimal newBalance)
        {
            newBalance = 0m;
            if (amount <= 0)
            {
                return false;
            }

            using (SqlConnection connection = Database.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    using (SqlCommand update = new SqlCommand(
                        @"UPDATE UserAccountDetails
                          SET Balance = Balance - @Amount
                          WHERE AccNo = @AccNo AND Balance >= @Amount",
                        connection, transaction))
                    {
                        update.Parameters.AddWithValue("@Amount", amount);
                        update.Parameters.AddWithValue("@AccNo", accountNumber);

                        if (update.ExecuteNonQuery() != 1)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }

                    InsertRecentTransaction(connection, transaction, accountNumber, transactionType, occurredAt, amount);
                    newBalance = GetBalance(connection, transaction, accountNumber);

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static bool TryTransfer(
            string senderAccountNumber,
            string recipientAccountNumber,
            decimal amount,
            DateTime occurredAt,
            out decimal senderBalance,
            out string error)
        {
            senderBalance = 0m;
            error = null;

            if (amount <= 0)
            {
                error = "Amount must be greater than zero.";
                return false;
            }

            if (string.Equals(senderAccountNumber, recipientAccountNumber, StringComparison.Ordinal))
            {
                error = "Choose a different recipient account.";
                return false;
            }

            using (SqlConnection connection = Database.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    using (SqlCommand recipient = new SqlCommand(
                        "SELECT COUNT(1) FROM UserAccountDetails WHERE AccNo = @AccNo",
                        connection, transaction))
                    {
                        recipient.Parameters.AddWithValue("@AccNo", recipientAccountNumber);
                        if (Convert.ToInt32(recipient.ExecuteScalar()) != 1)
                        {
                            transaction.Rollback();
                            error = "Recipient account could not be found.";
                            return false;
                        }
                    }

                    using (SqlCommand debit = new SqlCommand(
                        @"UPDATE UserAccountDetails
                          SET Balance = Balance - @Amount
                          WHERE AccNo = @AccNo AND Balance >= @Amount",
                        connection, transaction))
                    {
                        debit.Parameters.AddWithValue("@Amount", amount);
                        debit.Parameters.AddWithValue("@AccNo", senderAccountNumber);

                        if (debit.ExecuteNonQuery() != 1)
                        {
                            transaction.Rollback();
                            error = "Insufficient balance.";
                            return false;
                        }
                    }

                    using (SqlCommand credit = new SqlCommand(
                        "UPDATE UserAccountDetails SET Balance = Balance + @Amount WHERE AccNo = @AccNo",
                        connection, transaction))
                    {
                        credit.Parameters.AddWithValue("@Amount", amount);
                        credit.Parameters.AddWithValue("@AccNo", recipientAccountNumber);
                        credit.ExecuteNonQuery();
                    }

                    InsertRecentTransaction(connection, transaction, senderAccountNumber, "Fund Transfer", occurredAt, amount);
                    InsertRecentTransaction(connection, transaction, recipientAccountNumber, "Transfer Received", occurredAt, amount);

                    using (SqlCommand log = new SqlCommand(
                        @"INSERT INTO FundTransfer(AccNo, RAccNo, Date, Amount)
                          VALUES(@AccNo, @Recipient, @Date, @Amount)",
                        connection, transaction))
                    {
                        log.Parameters.AddWithValue("@AccNo", senderAccountNumber);
                        log.Parameters.AddWithValue("@Recipient", recipientAccountNumber);
                        log.Parameters.AddWithValue("@Date", occurredAt);
                        log.Parameters.AddWithValue("@Amount", amount);
                        log.ExecuteNonQuery();
                    }

                    senderBalance = GetBalance(connection, transaction, senderAccountNumber);
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static bool TryPayBill(
            string accountNumber,
            string billNumber,
            string provider,
            string transactionType,
            decimal amount,
            DateTime occurredAt,
            out decimal newBalance)
        {
            newBalance = 0m;

            using (SqlConnection connection = Database.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    using (SqlCommand debit = new SqlCommand(
                        @"UPDATE UserAccountDetails
                          SET Balance = Balance - @Amount
                          WHERE AccNo = @AccNo AND Balance >= @Amount",
                        connection, transaction))
                    {
                        debit.Parameters.AddWithValue("@Amount", amount);
                        debit.Parameters.AddWithValue("@AccNo", accountNumber);

                        if (debit.ExecuteNonQuery() != 1)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }

                    InsertRecentTransaction(connection, transaction, accountNumber, transactionType, occurredAt, amount);

                    using (SqlCommand log = new SqlCommand(
                        @"INSERT INTO BillPayment(AccNo, BillNo, Type, Date, Amount)
                          VALUES(@AccNo, @BillNo, @Type, @Date, @Amount)",
                        connection, transaction))
                    {
                        log.Parameters.AddWithValue("@AccNo", accountNumber);
                        log.Parameters.AddWithValue("@BillNo", billNumber);
                        log.Parameters.AddWithValue("@Type", provider);
                        log.Parameters.AddWithValue("@Date", occurredAt);
                        log.Parameters.AddWithValue("@Amount", amount);
                        log.ExecuteNonQuery();
                    }

                    newBalance = GetBalance(connection, transaction, accountNumber);
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static DataTable GetRecentTransactions(string accountNumber)
        {
            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                @"SELECT Type, Date, Amount
                  FROM RecentT
                  WHERE AccNo = @AccNo
                  ORDER BY Date DESC",
                connection))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public static bool IsEReceiptEnabled(string accountNumber, out DateTime? enabledAt)
        {
            enabledAt = null;

            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT Status, Date FROM EReceipt WHERE AccNo = @AccNo",
                connection))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return false;
                    }

                    bool enabled = string.Equals(
                        Convert.ToString(reader["Status"]),
                        "Yes",
                        StringComparison.OrdinalIgnoreCase);

                    if (reader["Date"] != DBNull.Value)
                    {
                        enabledAt = Convert.ToDateTime(reader["Date"]);
                    }

                    return enabled;
                }
            }
        }

        public static void SetEReceiptPreference(string accountNumber, bool enabled, DateTime changedAt)
        {
            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                @"MERGE EReceipt AS target
                  USING (SELECT @AccNo AS AccNo) AS source
                  ON target.AccNo = source.AccNo
                  WHEN MATCHED THEN
                    UPDATE SET Status = @Status, Date = @Date
                  WHEN NOT MATCHED THEN
                    INSERT (AccNo, Status, Date) VALUES (@AccNo, @Status, @Date);",
                connection))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                command.Parameters.AddWithValue("@Status", enabled ? (object)"Yes" : DBNull.Value);
                command.Parameters.AddWithValue("@Date", enabled ? (object)changedAt : DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        public static string GetAccountEmail(string accountNumber)
        {
            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT Email FROM UserAccountDetails WHERE AccNo = @AccNo",
                connection))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                object value = command.ExecuteScalar();
                return value == null || value == DBNull.Value ? null : Convert.ToString(value);
            }
        }

        public static void UpdatePin(string accountNumber, string hashedPin)
        {
            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                "UPDATE UserAccountDetails SET Pin = @Pin WHERE AccNo = @AccNo",
                connection))
            {
                command.Parameters.AddWithValue("@Pin", hashedPin);
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                command.ExecuteNonQuery();
            }
        }

        public static void RecordSecurityAlert(
            string accountNumber,
            string type,
            DateTime occurredAt,
            decimal? amount)
        {
            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                @"INSERT INTO SecurityAlerts(AccNo, Type, Date, Amount)
                  VALUES(@AccNo, @Type, @Date, @Amount)",
                connection))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Date", occurredAt);
                command.Parameters.AddWithValue("@Amount", amount.HasValue ? (object)amount.Value : DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        private static decimal GetBalance(
            SqlConnection connection,
            SqlTransaction transaction,
            string accountNumber)
        {
            using (SqlCommand command = new SqlCommand(
                "SELECT Balance FROM UserAccountDetails WHERE AccNo = @AccNo",
                connection, transaction))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                return Convert.ToDecimal(command.ExecuteScalar());
            }
        }

        private static void InsertRecentTransaction(
            SqlConnection connection,
            SqlTransaction transaction,
            string accountNumber,
            string type,
            DateTime occurredAt,
            decimal amount)
        {
            using (SqlCommand command = new SqlCommand(
                @"INSERT INTO RecentT(AccNo, Type, Date, Amount)
                  VALUES(@AccNo, @Type, @Date, @Amount)",
                connection, transaction))
            {
                command.Parameters.AddWithValue("@AccNo", accountNumber);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Date", occurredAt);
                command.Parameters.AddWithValue("@Amount", amount);
                command.ExecuteNonQuery();
            }
        }
    }
}
