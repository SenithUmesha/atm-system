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
    public partial class Balance : Form
    {
        public static double Balance1;

        public Balance()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Dash1 dash = new Dash1();
            dash.Show();
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;

            connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string sql1 = "Select Balance from UserAccountDetails where Pin = '" + Home.signinPin + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, cnn);

            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    Balance1 = Convert.ToDouble(reader1["Balance"]);
                }
            }
            cnn.Close();

            lblbalance.Text = "$ " + Balance1;
        }
    }
}
