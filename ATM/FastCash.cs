using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class FastCash : Form
    {
        public static string type = "Fast Cash";
        public static double Balance,NewBalance;

        public FastCash()
        {
            InitializeComponent();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select Balance from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    Balance = Convert.ToDouble(reader1["Balance"]);
                }
            }
            cnn.Close();

            if (10 <= Balance)
            {
                NewBalance = Balance - 10;

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql2 = "Update UserAccountDetails set Balance='" + NewBalance + "' where Pin = '" + Home.signinPin + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.ExecuteNonQuery();

                cnn.Close();

                MessageBox.Show("Fast cash completed", "Fast cash", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql3 = "INSERT INTO RecentT(AccNo,Type,Date,Amount) VALUES('" + Dash1.AccNo + "','" + type + "','" + time.ToString(format) + "','" + 10 + "')";
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                cmd3.ExecuteNonQuery();

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select Balance from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    Balance = Convert.ToDouble(reader1["Balance"]);
                }
            }
            cnn.Close();

            if (20 <= Balance)
            {
                NewBalance = Balance - 20;

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql2 = "Update UserAccountDetails set Balance='" + NewBalance + "' where Pin = '" + Home.signinPin + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.ExecuteNonQuery();

                cnn.Close();

                MessageBox.Show("Fast cash completed", "Fast cash", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql3 = "INSERT INTO RecentT(AccNo,Type,Date,Amount) VALUES('" + Dash1.AccNo + "','" + type + "','" + time.ToString(format) + "','" + 20 + "')";
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                cmd3.ExecuteNonQuery();

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select Balance from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    Balance = Convert.ToDouble(reader1["Balance"]);
                }
            }
            cnn.Close();

            if (30 <= Balance)
            {
                NewBalance = Balance - 30;

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql2 = "Update UserAccountDetails set Balance='" + NewBalance + "' where Pin = '" + Home.signinPin + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.ExecuteNonQuery();

                cnn.Close();

                MessageBox.Show("Fast cash completed", "Fast cash", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql3 = "INSERT INTO RecentT(AccNo,Type,Date,Amount) VALUES('" + Dash1.AccNo + "','" + type + "','" + time.ToString(format) + "','" + 30 + "')";
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                cmd3.ExecuteNonQuery();

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select Balance from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    Balance = Convert.ToDouble(reader1["Balance"]);
                }
            }
            cnn.Close();

            if (50 <= Balance)
            {
                NewBalance = Balance - 50;

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql2 = "Update UserAccountDetails set Balance='" + NewBalance + "' where Pin = '" + Home.signinPin + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.ExecuteNonQuery();

                cnn.Close();

                MessageBox.Show("Fast cash completed", "Fast cash", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql3 = "INSERT INTO RecentT(AccNo,Type,Date,Amount) VALUES('" + Dash1.AccNo + "','" + type + "','" + time.ToString(format) + "','" + 50 + "')";
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                cmd3.ExecuteNonQuery();

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn80_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select Balance from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    Balance = Convert.ToDouble(reader1["Balance"]);
                }
            }
            cnn.Close();

            if (80 <= Balance)
            {
                NewBalance = Balance - 80;

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql2 = "Update UserAccountDetails set Balance='" + NewBalance + "' where Pin = '" + Home.signinPin + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.ExecuteNonQuery();

                cnn.Close();

                MessageBox.Show("Fast cash completed", "Fast cash", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql3 = "INSERT INTO RecentT(AccNo,Type,Date,Amount) VALUES('" + Dash1.AccNo + "','" + type + "','" + time.ToString(format) + "','" + 80 + "')";
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                cmd3.ExecuteNonQuery();

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select Balance from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    Balance = Convert.ToDouble(reader1["Balance"]);
                }
            }
            cnn.Close();

            if (100 <= Balance)
            {
                NewBalance = Balance - 100;

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql2 = "Update UserAccountDetails set Balance='" + NewBalance + "' where Pin = '" + Home.signinPin + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.ExecuteNonQuery();

                cnn.Close();

                MessageBox.Show("Fast cash completed", "Fast cash", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cnn = new SqlConnection(connectionString);
                cnn.Open();

                string sql3 = "INSERT INTO RecentT(AccNo,Type,Date,Amount) VALUES('" + Dash1.AccNo + "','" + type + "','" + time.ToString(format) + "','" + 100 + "')";
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                cmd3.ExecuteNonQuery();

                cnn.Close();
            }
            else
            {
                MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Dash1 dash = new Dash1();
            dash.Show();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
