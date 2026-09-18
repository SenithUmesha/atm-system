using System;
using System.Windows.Forms;

namespace ATM
{
    public partial class Dash1 : Form
    {
        public static string AccNo;

        public Dash1()
        {
            InitializeComponent();
            lblwel2.Text = Home.signinName ?? string.Empty;
            AccNo = Home.signinAccNo;
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnwith_Click(object sender, EventArgs e)
        {
            Hide();
            new Withdrawal().ShowDialog();
        }

        private void btndep_Click(object sender, EventArgs e)
        {
            Hide();
            new Deposit().ShowDialog();
        }

        private void btnbalance_Click(object sender, EventArgs e)
        {
            Hide();
            new Balance().ShowDialog();
        }

        private void btnrecent_Click(object sender, EventArgs e)
        {
            Hide();
            new RecentT().ShowDialog();
        }

        private void btnbill_Click(object sender, EventArgs e)
        {
            Hide();
            new BillPayment().ShowDialog();
        }

        private void btnfast_Click(object sender, EventArgs e)
        {
            Hide();
            new FastCash().ShowDialog();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Hide();
            new Settings().ShowDialog();
        }

        private void btndon_Click(object sender, EventArgs e)
        {
            Hide();
            new FundTransfer().ShowDialog();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to sign out ?", "Sign Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Home.signinName = null;
                Home.signinPin = null;
                Home.signinAccNo = null;
                AccNo = null;
                Close();
            }
        }
    }
}
