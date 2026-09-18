using System;
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
            if (txtcpin.Text != Home.signinPin)
            {
                MessageBox.Show("Entered PIN number is incorrect.", "E-Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                BankingService.SetEReceiptPreference(Dash1.AccNo, false, DateTime.Now);

                MessageBox.Show("You've successfully disabled the E-Receipt service.", "E-Receipt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
                new Settings().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-Receipts could not be disabled. " + ex.Message,
                    "E-Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtcpin.Clear();
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
