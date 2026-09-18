using DGVPrinterHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATM
{
    public partial class AdminAlerts : Form
    {
        public AdminAlerts()
        {
            InitializeComponent();
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = CreatePrinter("Security Alerts - Admin");
            printer.PrintDataGridView(dataGridView1);
            MessageBox.Show("Successfully printed.", "Admin - Security Alerts",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Hide();
            new AdminDash().ShowDialog();
        }

        private void AdminAlerts_Load(object sender, EventArgs e)
        {
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
                dataGridView1.DataSource = GridData.LoadSecurityAlerts(prefix);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Security alerts could not be loaded. " + ex.Message,
                    "Admin - Security Alerts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static DGVPrinter CreatePrinter(string subtitle)
        {
            return new DGVPrinter
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
        }
    }
}
