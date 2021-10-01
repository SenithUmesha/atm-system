using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class AdminNearbyATMs : Form
    {
        public AdminNearbyATMs()
        {
            InitializeComponent();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "\r\n\r\n\r\n ZEMO Bank \r\n\r\n";
            printer.SubTitle = "Nearby ATMs - Admin \r\n\r\n\r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = false;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Admin - ZEMO Bank";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

            MessageBox.Show("Successfully printed", "Admin - Nearby ATMs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDash adminDash = new AdminDash();
            adminDash.ShowDialog();
        }

        private void AdminNearbyATMs_Load(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            String sql = "Select*from NearbyATMs ";
            SqlCommand cmd = new SqlCommand(sql, cnn);

            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            ada.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            cnn.Close();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtsearchbar.Clear();
        }

        private void txtsearchbar_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchbar.Text != "")
            {
                string connectionString;
                SqlConnection cnn;

                connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                String sql = "Select*from NearbyATMs where ATMNo LIKE '" + txtsearchbar.Text + "%'";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                ada.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                cnn.Close();
            }
            else
            {
                string connectionString;
                SqlConnection cnn;

                connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                String sql = "Select*from NearbyATMs ";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                ada.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                cnn.Close();
            }
        }
    }
}
