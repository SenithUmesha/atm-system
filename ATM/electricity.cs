using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace ATM
{
    public partial class electricity : UserControl
    {
        private const string TransactionType = "Electricity Bill Payment";
        private const string Provider = "Ceylon Electricity Board";

        public electricity()
        {
            InitializeComponent();
            ResetFields();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            ProcessPayment();
        }

        private void ProcessPayment()
        {
            string billNumber = txtbillno.Text.Trim();

            if (string.IsNullOrWhiteSpace(billNumber)
                || string.IsNullOrWhiteSpace(txtamount.Text)
                || string.IsNullOrWhiteSpace(txtcpin.Text))
            {
                MessageBox.Show("Fields can't be empty.", "Bill Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtcpin.Text != Home.signinPin)
            {
                MessageBox.Show("Incorrect PIN number.", "Bill Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!decimal.TryParse(txtamount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Enter an amount greater than zero.", "Bill Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime occurredAt = DateTime.Now;

            try
            {
                if (!BankingService.TryPayBill(
                    Dash1.AccNo,
                    billNumber,
                    Provider,
                    TransactionType,
                    amount,
                    occurredAt,
                    out decimal _))
                {
                    MessageBox.Show("Insufficient balance.", "Bill Payment",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable receipt = BuildReceipt(Dash1.AccNo, billNumber, occurredAt, amount);
                dgv.DataSource = receipt;

                bool eReceiptEnabled = BankingService.IsEReceiptEnabled(Dash1.AccNo, out DateTime? _);
                bool emailed = false;

                if (eReceiptEnabled && EmailService.IsConfigured)
                {
                    string email = BankingService.GetAccountEmail(Dash1.AccNo);
                    var replacements = new Dictionary<string, string>
                    {
                        ["BillNumber"] = billNumber,
                        ["AccountNumber"] = Dash1.AccNo,
                        ["Date"] = occurredAt.ToString("yyyy-MM-dd HH:mm:ss"),
                        ["Amount"] = amount.ToString("0.00")
                    };

                    emailed = EmailService.TrySendTemplate(
                        email,
                        "Electricity bill payment receipt - ZEMO Bank",
                        "index.html",
                        replacements,
                        out string error);

                    if (!emailed && !string.IsNullOrWhiteSpace(error))
                    {
                        MessageBox.Show(
                            "Payment completed, but the email receipt could not be sent. A printable receipt will be shown instead. "
                            + error,
                            "Bill Payment",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }

                if (!emailed)
                {
                    PrintReceipt("Payments - Ceylon Electricity Board");
                }

                MessageBox.Show("Payment completed.", "Bill Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Payment could not be completed. " + ex.Message,
                    "Bill Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataTable BuildReceipt(string accountNumber, string billNumber, DateTime date, decimal amount)
        {
            DataTable table = new DataTable();
            table.Columns.Add("AccNo");
            table.Columns.Add("BillNo");
            table.Columns.Add("Type");
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("Amount", typeof(decimal));
            table.Rows.Add(accountNumber, billNumber, Provider, date, amount);
            return table;
        }

        private void PrintReceipt(string subtitle)
        {
            DGVPrinter printer = new DGVPrinter
            {
                Title = "\r\n\r\n\r\n ZEMO Bank \r\n\r\n",
                SubTitle = subtitle + " \r\n\r\n",
                SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip,
                PageNumbers = false,
                PageNumberInHeader = false,
                PorportionalColumns = true,
                HeaderCellAlignment = StringAlignment.Near,
                Footer = "Thank you - ZEMO Bank",
                FooterSpacing = 15
            };

            printer.PrintDataGridView(dgv);
        }

        private void txtbillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            RestrictToDigits(e);
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
            RestrictToDigits(e);
        }

        private void electricity_Load(object sender, EventArgs e)
        {
            dgv.Hide();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Hide();
            ResetFields();
        }

        private void ResetFields()
        {
            txtbillno.Clear();
            txtamount.Clear();
            txtcpin.Clear();
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
