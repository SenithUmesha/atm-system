using DGVPrinterHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATM
{
    public partial class AdminRecentTransaction : Form
    {
        public AdminRecentTransaction()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Hide();
            new AdminDash().ShowDialog();
        }

        private void AdminRecentTransaction_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintGrid("Recent Transactions - Admin", "Admin - Recent Transactions");
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtsearchbar.Clear();
            LoadData();
        }

        private void txtsearchbar_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtsearchbar.Text.Trim());
        }

        private void LoadData(string prefix = "")
        {
            try
            {
                dataGridView1.DataSource = GridData.LoadRecentTransactions(prefix);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transactions could not be loaded. " + ex.Message,
                    "Admin - Recent Transactions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrintGrid(string subtitle, string title)
        {
            DGVPrinter printer = new DGVPrinter
            {
                Title = "\r\n\r\n\r\n ZEMO Bank \r\n\r\n",
                SubTitle = subtitle + " \r\n\r\n\r\n",
                SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip,
                PageNumbers = false,
                PageNumberInHeader = false,
                PorportionalColumns = true,
                HeaderCellAlignment = StringAlignment.Near,
                Footer = "Admin - ZEMO Bank",
                FooterSpacing = 15
            };
            printer.PrintDataGridView(dataGridView1);
            MessageBox.Show("Successfully printed.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
