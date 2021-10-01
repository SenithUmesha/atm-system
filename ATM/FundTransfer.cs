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
    public partial class FundTransfer : Form
    {
        public static double Balance, NewBalance;
        public static string type = "Fund Transfer";

        public FundTransfer()
        {
            InitializeComponent();
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";

            if (txtamount.Text == "" || txtcpin.Text == "" || txtraccno.Text == "")
            {
                MessageBox.Show("Fields can't be empty", "Bill Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                double amount = Convert.ToDouble(txtamount.Text);

                if (amount <= 0)
                {
                    MessageBox.Show("Amount can't be 0", "Bill Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
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

                    if (Balance < amount)
                    {
                        MessageBox.Show("Insufficient balance", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (txtcpin.Text == Home.signinPin)
                        {
                            NewBalance = Balance - amount;

                            cnn = new SqlConnection(connectionString);
                            cnn.Open();

                            string sql2 = "Update UserAccountDetails set Balance='" + NewBalance + "' where Pin = '" + Home.signinPin + "' ";
                            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                            cmd2.ExecuteNonQuery();

                            cnn.Close();

                            cnn = new SqlConnection(connectionString);
                            cnn.Open();

                            string sql3 = "INSERT INTO RecentT(AccNo,Type,Date,Amount) VALUES('" + Dash1.AccNo + "','" + type + "','" + time.ToString(format) + "','" + amount + "')";
                            SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                            cmd3.ExecuteNonQuery();

                            cnn.Close();

                            cnn = new SqlConnection(connectionString);
                            cnn.Open();

                            string sql4 = "INSERT INTO FundTransfer(AccNo,RAccNo,Date,Amount) VALUES('" + Dash1.AccNo + "','" + txtraccno.Text + "','" + time.ToString(format) + "','" + amount + "')";
                            SqlCommand cmd4 = new SqlCommand(sql4, cnn);
                            cmd4.ExecuteNonQuery();

                            cnn.Close();

                            MessageBox.Show("Transfer completed", "Fund Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            Dash1 dash = new Dash1();
                            dash.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect PIN number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtamount.Clear();
            txtcpin.Clear();
            txtraccno.Clear();
        }

        private void txtraccno_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter A Valid Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!char.IsDigit(chr) && chr != 8 && chr != '.')
            {
                e.Handled = true;
                MessageBox.Show("Please Enter A Valid Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcpin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter A Valid Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Dash1 dash = new Dash1();
            dash.Show();
        }
    }
}
