using System;
using System.Windows.Forms;

namespace ATM
{
    public partial class FundTransfer : Form
    {
        public FundTransfer()
        {
            InitializeComponent();
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            string recipient = txtraccno.Text.Trim();

            if (string.IsNullOrWhiteSpace(recipient)
                || string.IsNullOrWhiteSpace(txtamount.Text)
                || string.IsNullOrWhiteSpace(txtcpin.Text))
            {
                MessageBox.Show("Fields can't be empty.", "Fund Transfer",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtcpin.Text != Home.signinPin)
            {
                MessageBox.Show("Incorrect PIN number.", "Fund Transfer",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!decimal.TryParse(txtamount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Enter an amount greater than zero.", "Fund Transfer",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!BankingService.TryTransfer(
                    Dash1.AccNo,
                    recipient,
                    amount,
                    DateTime.Now,
                    out decimal _,
                    out string error))
                {
                    MessageBox.Show(error, "Fund Transfer",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Transfer completed.", "Fund Transfer",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                new Dash1().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transfer could not be completed. " + ex.Message, "Fund Transfer",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtamount.Clear();
            txtcpin.Clear();
            txtraccno.Clear();
        }

        private void txtraccno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtcpin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Close();
            new Dash1().Show();
        }
    }
}
