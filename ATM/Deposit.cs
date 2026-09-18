using System;
using System.Windows.Forms;

namespace ATM
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Close();
            new Dash1().Show();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtdamount.Clear();
        }

        private void txtdamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!char.IsDigit(character) && character != 8 && character != '.')
            {
                e.Handled = true;
            }
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtdamount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Enter an amount greater than zero.", "Deposit",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                BankingService.Deposit(Dash1.AccNo, amount, DateTime.Now);
                MessageBox.Show("Deposit completed.", "Deposit",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                new Dash1().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deposit could not be completed. " + ex.Message, "Deposit",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
