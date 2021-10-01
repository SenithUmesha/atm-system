using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class AdminDash : Form
    {
        public AdminDash()
        {
            InitializeComponent();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaccdetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminAccDetails adminAccdetails = new AdminAccDetails();
            adminAccdetails.ShowDialog();
        }

        private void btnrt_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminRecentTransaction adminRecentTransaction = new AdminRecentTransaction();
            adminRecentTransaction.ShowDialog();
        }

        private void btnbillpayments_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminBillPayments adminBillPayments = new AdminBillPayments();
            adminBillPayments.ShowDialog();
        }

        private void btnfund_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminFundTransfers adminFundTransfers = new AdminFundTransfers();
            adminFundTransfers.ShowDialog();
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

        private void AdminDash_Load(object sender, EventArgs e)
        {
            lblwel2.Text = "" + Home.signinName;
        }

        private void btnnatms_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminNearbyATMs adminNearbyATMs = new AdminNearbyATMs();
            adminNearbyATMs.ShowDialog();
        }

        private void btnereceipts_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminEReceipts adminEReceipts = new AdminEReceipts();
            adminEReceipts.ShowDialog();
        }

        private void btnAlerts_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminAlerts adminAlerts = new AdminAlerts();
            adminAlerts.ShowDialog();
        }
    }
}
