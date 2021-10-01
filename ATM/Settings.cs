using DGVPrinterHelper;
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
    public partial class Settings : Form
    {
        public static string randomcode2 , status;

        public Settings()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dash1 dash = new Dash1();
            dash.ShowDialog();
        }

        private void btncpin_Click(object sender, EventArgs e)
        {
            nearbyATM1.Hide();
            changePIN1.Show();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnatms_Click(object sender, EventArgs e)
        {
            changePIN1.Hide();
            nearbyATM1.Show();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            nearbyATM1.Hide();
            changePIN1.Hide();
        }

        private void btnereceipts_Click(object sender, EventArgs e)
        {
            nearbyATM1.Hide();
            changePIN1.Hide();

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql5 = "Select Status from EReceipt where AccNo = '" + Dash1.AccNo + "'";
            SqlCommand cmd5 = new SqlCommand(sql5, cnn);

            using (SqlDataReader reader = cmd5.ExecuteReader())
            {
                while (reader.Read())
                {
                    status = Convert.ToString(reader["Status"]);
                }
            }

            cnn.Close();

            if (status != "Yes")
            {

                if (MessageBox.Show("After enabling this feature you can't disable it within next 30 days!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {

                    this.Close();
                    EReceipts1 eReceipts1 = new EReceipts1();
                    eReceipts1.Show();

                }
            }
            else 
            {
                int days;
                DateTime startdate = DateTime.Now; //will be updated by next step , this is just a default value

                DateTime todaydate = DateTime.Now;

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string sql6 = "Select Date from EReceipt where AccNo = '" + Dash1.AccNo + "'";
                SqlCommand cmd6 = new SqlCommand(sql6, cnn);

                using (SqlDataReader reader = cmd6.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        startdate = (DateTime)reader["Date"];
                    }
                }

                cnn.Close();

                days = (todaydate.Date - startdate.Date).Days ;

                if (days > 30)
                {
                    if (MessageBox.Show("You've already enabled this feature!\n\nDo you want to DISABLE it ?", "Disable E-Receipts", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.Hide();
                        EReceipts2 eReceipts2 = new EReceipts2();
                        eReceipts2.Show();
                    }
                }
                else 
                {
                    int remainingdays = 30 - days;
                    MessageBox.Show("You've already enabled this feature!\n( DISABLE feature will be available in "+remainingdays+" days )", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
