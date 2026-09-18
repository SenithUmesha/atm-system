using System;
using System.Windows.Forms;

namespace ATM
{
    public partial class RecentT : Form
    {
        public RecentT()
        {
            InitializeComponent();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Close();
            new Dash1().Show();
        }

        private void RecentT_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = BankingService.GetRecentTransactions(Dash1.AccNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transactions could not be loaded. " + ex.Message, "Recent transactions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
