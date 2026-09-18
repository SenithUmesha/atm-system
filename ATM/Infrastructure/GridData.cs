using System;
using System.Data;
using System.Data.SqlClient;

namespace ATM
{
    internal static class GridData
    {
        public static DataTable LoadUserAccounts(string prefix)
        {
            return Load(
                @"SELECT Name, AccNo, Address, Contact_number, Birth_of_date, Email, Balance
                  FROM UserAccountDetails",
                "AccNo",
                prefix);
        }

        public static DataTable LoadRecentTransactions(string prefix)
        {
            return Load("SELECT AccNo, Type, Date, Amount FROM RecentT", "AccNo", prefix);
        }

        public static DataTable LoadFundTransfers(string prefix)
        {
            return Load("SELECT AccNo, RAccNo, Date, Amount FROM FundTransfer", "AccNo", prefix);
        }

        public static DataTable LoadBillPayments(string prefix)
        {
            return Load("SELECT AccNo, BillNo, Type, Date, Amount FROM BillPayment", "AccNo", prefix);
        }

        public static DataTable LoadEReceipts(string prefix)
        {
            return Load("SELECT AccNo, Status, Date FROM EReceipt", "AccNo", prefix);
        }

        public static DataTable LoadSecurityAlerts(string prefix)
        {
            return Load("SELECT AccNo, Type, Date, Amount FROM SecurityAlerts", "AccNo", prefix);
        }

        public static DataTable LoadNearbyAtms(string prefix)
        {
            return Load("SELECT ATMNo, Branch, Location, Distance FROM NearbyATMs", "ATMNo", prefix);
        }

        private static DataTable Load(string baseQuery, string searchColumn, string prefix)
        {
            string query = baseQuery;
            if (!string.IsNullOrWhiteSpace(prefix))
            {
                query += " WHERE " + searchColumn + " LIKE @Prefix";
            }

            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (!string.IsNullOrWhiteSpace(prefix))
                {
                    command.Parameters.AddWithValue("@Prefix", prefix + "%");
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
    }
}
