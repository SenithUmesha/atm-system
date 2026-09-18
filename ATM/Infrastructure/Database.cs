using System;
using System.Data.SqlClient;

namespace ATM
{
    internal static class Database
    {
        private const string ConnectionEnvironmentVariable = "ZEMO_DB_CONNECTION_STRING";

        public static string ConnectionString
        {
            get
            {
                string configured = Environment.GetEnvironmentVariable(ConnectionEnvironmentVariable);
                if (!string.IsNullOrWhiteSpace(configured))
                {
                    return configured;
                }

                return @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ZEMO_Bank;Integrated Security=True";
            }
        }

        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
