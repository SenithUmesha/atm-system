using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATM
{
    public partial class ChangePIN : UserControl
    {
        public ChangePIN()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtcnewpin.Clear();
            txtcpin.Clear();
            txtnewpin.Clear();
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            string currentPin = txtcpin.Text.Trim();
            string newPin = txtnewpin.Text.Trim();
            string confirmation = txtcnewpin.Text.Trim();

            if (string.IsNullOrWhiteSpace(currentPin)
                || string.IsNullOrWhiteSpace(newPin)
                || string.IsNullOrWhiteSpace(confirmation))
            {
                MessageBox.Show("Fields can't be empty.", "Settings and Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentPin != Home.signinPin)
            {
                MessageBox.Show("Your current PIN number is incorrect.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (newPin.Length != 4 || !int.TryParse(newPin, out int _)
                || newPin != confirmation
                || newPin == currentPin)
            {
                MessageBox.Show("Choose a different four-digit PIN and confirm it.", "Settings and Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                BankingService.UpdatePin(Dash1.AccNo, CredentialHasher.Hash(newPin));
                Home.signinPin = newPin;

                SendSecurityAlert();

                MessageBox.Show("PIN number changed.", "Settings and Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PIN could not be changed. " + ex.Message, "Settings and Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void SendSecurityAlert()
        {
            DateTime occurredAt = DateTime.Now;
            BankingService.RecordSecurityAlert(Dash1.AccNo, "Profile", occurredAt, null);

            if (!EmailService.IsConfigured)
            {
                return;
            }

            string email = BankingService.GetAccountEmail(Dash1.AccNo);
            var values = new Dictionary<string, string>
            {
                ["Name"] = Home.signinName,
                ["Date"] = occurredAt.ToString("yyyy-MM-dd HH:mm:ss")
            };

            EmailService.TrySendTemplate(
                email,
                "ZEMO Bank account alert [PIN changed]",
                "ProfileAlert.html",
                values,
                out string _);
        }

        private void txtcpin_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigits(e);
        }

        private void txtnewpin_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigits(e);
        }

        private void txtcnewpin_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigits(e);
        }

        private static void RestrictToDigits(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
