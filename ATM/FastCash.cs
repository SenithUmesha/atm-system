using System;
using System.Windows.Forms;

namespace ATM
{
    public partial class FastCash : Form
    {
        public FastCash()
        {
            InitializeComponent();
        }

        private void btn10_Click(object sender, EventArgs e) => ProcessFastCash(10m);
        private void btn20_Click(object sender, EventArgs e) => ProcessFastCash(20m);
        private void btn30_Click(object sender, EventArgs e) => ProcessFastCash(30m);
        private void btn50_Click(object sender, EventArgs e) => ProcessFastCash(50m);
        private void btn80_Click(object sender, EventArgs e) => ProcessFastCash(80m);
        private void btn100_Click(object sender, EventArgs e) => ProcessFastCash(100m);

        private void ProcessFastCash(decimal amount)
        {
            try
            {
                if (!BankingService.TryWithdraw(
                    Dash1.AccNo,
                    amount,
                    "Fast Cash",
                    DateTime.Now,
                    out decimal _))
                {
                    MessageBox.Show("Insufficient balance.", "Fast cash",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Fast cash completed.", "Fast cash",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fast cash could not be completed. " + ex.Message, "Fast cash",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
    }
}
