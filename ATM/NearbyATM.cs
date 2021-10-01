using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace ATM
{
    public partial class NearbyATM : UserControl
    {
        public NearbyATM()
        {
            InitializeComponent();
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

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtsearchbar.Clear();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "\r\n\r\n\r\n ZEMO Bank \r\n\r\n";
            printer.SubTitle = "Nearby ATMs \r\n\r\n ( Distance is in Km and the starting point is our Galle branch ) \r\n\r\n\r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = false;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Thank you - ZEMO Bank";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

            MessageBox.Show("Successfully printed", "Settings and Services", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
        }

        private void NearbyATM_Load(object sender, EventArgs e)
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
