using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
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
            LoadAtms(txtsearchbar.Text.Trim());
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtsearchbar.Clear();
            LoadAtms(string.Empty);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter
            {
                Title = "\r\n\r\n\r\n ZEMO Bank \r\n\r\n",
                SubTitle = "Nearby ATMs \r\n\r\n (Distance is in Km and the starting point is our Galle branch) \r\n\r\n\r\n",
                SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip,
                PageNumbers = false,
                PageNumberInHeader = false,
                PorportionalColumns = true,
                HeaderCellAlignment = StringAlignment.Near,
                Footer = "Thank you - ZEMO Bank",
                FooterSpacing = 15
            };

            printer.PrintDataGridView(dataGridView1);
            MessageBox.Show("Successfully printed.", "Settings and Services",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
        }

        private void NearbyATM_Load(object sender, EventArgs e)
        {
            LoadAtms(string.Empty);
        }

        private void LoadAtms(string prefix)
        {
            try
            {
                using (SqlConnection connection = Database.OpenConnection())
                using (SqlCommand command = new SqlCommand(
                    string.IsNullOrWhiteSpace(prefix)
                        ? "SELECT ATMNo, Branch, Location, Distance FROM NearbyATMs ORDER BY ATMNo"
                        : "SELECT ATMNo, Branch, Location, Distance FROM NearbyATMs WHERE ATMNo LIKE @Prefix ORDER BY ATMNo",
                    connection))
                {
                    if (!string.IsNullOrWhiteSpace(prefix))
                    {
                        command.Parameters.AddWithValue("@Prefix", prefix + "%");
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ATM locations could not be loaded. " + ex.Message,
                    "Nearby ATMs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
