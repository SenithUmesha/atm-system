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
    public partial class RecentT : Form
    {
        public RecentT()
        {
            InitializeComponent();
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Dash1 dash = new Dash1();
            dash.Show();
        }

        private void RecentT_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                SqlConnection cnn;

                connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS; Initial Catalog = ZEMO_Bank; User ID = admin; Password = admin";

                cnn = new SqlConnection(connectionString);

                cnn.Open();
                String sql = "Select*from RecentT where AccNo = '" + Dash1.AccNo + "'";
                SqlCommand cmd = new SqlCommand(sql, cnn);

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                ada.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                cnn.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
        }
    }
}
