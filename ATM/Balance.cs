using System;
using System.Windows.Forms;

namespace ATM
{
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Close();
            new Dash1().Show();
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            try
            {
                decimal balance = BankingService.GetBalance(Dash1.AccNo);
                lblbalance.Text = "$ " + balance.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Balance could not be loaded. " + ex.Message, "Balance",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
