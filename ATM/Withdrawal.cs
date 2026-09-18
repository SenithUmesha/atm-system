using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATM
{
    public partial class Withdrawal : Form
    {
        private const decimal AlertThreshold = 1000m;

        public Withdrawal()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Close();
            new Dash1().Show();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtwamount.Clear();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtwamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtwamount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Enter an amount greater than zero.", "Withdrawal",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!BankingService.TryWithdraw(
                    Dash1.AccNo,
                    amount,
                    "Withdrawal",
                    DateTime.Now,
                    out decimal newBalance))
                {
                    MessageBox.Show("Insufficient balance.", "Withdrawal",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (amount > AlertThreshold)
                {
                    SendSecurityAlert(amount, newBalance);
                }

                MessageBox.Show("Withdrawal completed.", "Withdrawal",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                new Dash1().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Withdrawal could not be completed. " + ex.Message, "Withdrawal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void SendSecurityAlert(decimal amount, decimal newBalance)
        {
            DateTime occurredAt = DateTime.Now;
            BankingService.RecordSecurityAlert(Dash1.AccNo, "Transaction", occurredAt, amount);

            if (!EmailService.IsConfigured)
            {
                return;
            }

            string email = BankingService.GetAccountEmail(Dash1.AccNo);
            var values = new Dictionary<string, string>
            {
                ["AccountNumber"] = Dash1.AccNo,
                ["Name"] = Home.signinName,
                ["Date"] = occurredAt.ToString("yyyy-MM-dd HH:mm:ss"),
                ["Amount"] = amount.ToString("0.00"),
                ["Balance"] = newBalance.ToString("0.00")
            };

            if (!EmailService.TrySendTemplate(
                email,
                "ZEMO Bank account alert [withdrawal]",
                "TransactionAlert.html",
                values,
                out string error))
            {
                MessageBox.Show("The withdrawal succeeded, but the optional email alert could not be sent. " + error,
                    "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
