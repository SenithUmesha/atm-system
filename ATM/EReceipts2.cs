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
    public partial class EReceipts2 : Form
    {
        public EReceipts2()
        {
            InitializeComponent();
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            if (txtcpin.Text == Home.signinPin)
            {
                string connectionString;
                SqlConnection cnn;

                connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string sql2 = "Update EReceipt set Status='" + DBNull.Value + "' where AccNo = '" + Dash1.AccNo + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.ExecuteNonQuery();

                cnn.Close();

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string sql3 = "Update EReceipt set Date='" + DBNull.Value + "' where AccNo = '" + Dash1.AccNo + "' ";
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                cmd3.ExecuteNonQuery();

                cnn.Close();

                if (MessageBox.Show("You've successfully disabled the E-Receipt service", "E-Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                    Settings settings = new Settings();
                    settings.Show();
                }
            }
            else 
            {
                MessageBox.Show("Entered PIN number is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtcpin.Clear();
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
