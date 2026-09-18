using System;
using System.Windows.Forms;

namespace ATM
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Hide();
            new Dash1().ShowDialog();
        }

        private void btncpin_Click(object sender, EventArgs e)
        {
            nearbyATM1.Hide();
            changePIN1.Show();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
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

            try
            {
                bool enabled = BankingService.IsEReceiptEnabled(Dash1.AccNo, out DateTime? enabledAt);

                if (!enabled)
                {
                    if (MessageBox.Show(
                        "After enabling this feature you can't disable it within the next 30 days.",
                        "E-Receipts",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Close();
                        new EReceipts1().Show();
                    }

                    return;
                }

                DateTime startDate = enabledAt ?? DateTime.Now;
                int daysEnabled = Math.Max(0, (DateTime.Now.Date - startDate.Date).Days);

                if (daysEnabled >= 30)
                {
                    if (MessageBox.Show(
                        "E-Receipts are enabled. Do you want to disable them?",
                        "E-Receipts",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Hide();
                        new EReceipts2().Show();
                    }
                }
                else
                {
                    int remainingDays = 30 - daysEnabled;
                    MessageBox.Show(
                        "E-Receipts are enabled. Disable becomes available in " + remainingDays + " day(s).",
                        "E-Receipts",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-Receipt settings could not be loaded. " + ex.Message,
                    "E-Receipts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
