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
    public partial class Dash1 : Form
    {
        public static string AccNo ;

        public Dash1()
        {
            InitializeComponent();
            lblwel2.Text = "" + Home.signinName;

            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select AccNo from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    AccNo = Convert.ToString(reader1["AccNo"]);
                }
            }
            cnn.Close();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnwith_Click(object sender, EventArgs e)
        {
            this.Hide();
            Withdrawal withdrawal = new Withdrawal();
            withdrawal.ShowDialog();
        }

        private void btndep_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deposit deposit = new Deposit();
            deposit.ShowDialog();
        }

        private void btnbalance_Click(object sender, EventArgs e)
        {
            this.Hide();
            Balance balance = new Balance();
            balance.ShowDialog();
        }

        private void btnrecent_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecentT recentT = new RecentT();
            recentT.ShowDialog();
        }

        private void btnbill_Click(object sender, EventArgs e)
        {
            this.Hide();
            BillPayment billPayment = new BillPayment();
            billPayment.ShowDialog();
        }

        private void btnfast_Click(object sender, EventArgs e)
        {
            this.Hide();
            FastCash fastCash = new FastCash();
            fastCash.ShowDialog();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.ShowDialog();

        }

        private void btndon_Click(object sender, EventArgs e)
        {
            this.Hide();
            FundTransfer fundTransfer = new FundTransfer();
            fundTransfer.ShowDialog();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to sign out ?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
        }
    }
}
