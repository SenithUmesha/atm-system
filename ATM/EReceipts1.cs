using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class EReceipts1 : Form
    {
        public EReceipts1()
        {
            InitializeComponent();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtcpin.Clear();
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            if (txtcpin.Text == "")
            {
                MessageBox.Show("Above field can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtcpin.Text == Home.signinPin)
                {
                    try
                    {
                        DateTime time = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss";

                        string connectionString;
                        SqlConnection cnn;

                        connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

                        cnn = new SqlConnection(connectionString);
                        cnn.Open();
                        string sql1 = "Select AccNo from EReceipt where AccNo = '" + Dash1.AccNo + "'";
                        SqlCommand cmd1 = new SqlCommand(sql1, cnn);
                        SqlDataReader reader1 = cmd1.ExecuteReader();

                        if (reader1.HasRows)
                        {
                            cnn = new SqlConnection(connectionString);
                            cnn.Open();
                            string sql2 = "Update EReceipt set Status='" + "Yes" + "' where AccNo = '" + Dash1.AccNo + "' ";
                            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                            cmd2.ExecuteNonQuery();

                            cnn.Close();

                            cnn = new SqlConnection(connectionString);
                            cnn.Open();
                            string sql3 = "Update EReceipt set Date='" + time.ToString(format) + "' where AccNo = '" + Dash1.AccNo + "' ";
                            SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                            cmd3.ExecuteNonQuery();

                            cnn.Close();
                        }
                        else
                        {
                            cnn = new SqlConnection(connectionString);
                            cnn.Open();

                            string sql4 = "INSERT INTO EReceipt(AccNo,Status,Date) VALUES('" + Dash1.AccNo + "','" + "Yes" + "','" + time.ToString(format) + "')";
                            SqlCommand cmd4 = new SqlCommand(sql4, cnn);
                            cmd4.ExecuteNonQuery();

                            cnn.Close();
                        }

                        cnn.Close();

                        if (MessageBox.Show("You've successfully enabled our E-Receipt service", "E-Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            this.Close();
                            Settings settings = new Settings();
                            settings.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Your current PIN number is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Settings se = new Settings();
            se.Show();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
