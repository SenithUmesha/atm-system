using System;
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
            if (string.IsNullOrWhiteSpace(txtcpin.Text))
            {
                MessageBox.Show("PIN is required.", "E-Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtcpin.Text != Home.signinPin)
            {
                MessageBox.Show("Your current PIN number is incorrect.", "E-Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                BankingService.SetEReceiptPreference(Dash1.AccNo, true, DateTime.Now);

                MessageBox.Show("You've successfully enabled the E-Receipt service.", "E-Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
                new Settings().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-Receipts could not be enabled. " + ex.Message,
                    "E-Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Close();
            new Settings().Show();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
