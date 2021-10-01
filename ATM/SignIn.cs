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
    public partial class Home : Form
    {
        public static string signinName;
        public static string signinPin;
        public static int type;

        public Home()
        {
            InitializeComponent();
            txtaccname.Visible = false;
            txtpin.Visible = false;
            btnsignin.Visible = false;
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                string connectionString;
                SqlConnection cnn;

                connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string sql = "Select * from UserAccountDetails where Name = '" + txtaccname.Text + "' and Pin = '" + txtpin.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (MessageBox.Show("Login Successfully", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        signinName = txtaccname.Text;
                        signinPin = txtpin.Text;

                        this.Hide();
                        Dash1 dash = new Dash1();
                        dash.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Either your account name or pin number is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cnn.Close();
            }
            else if(type == 1) {

                string connectionString;
                SqlConnection cnn;

                connectionString = @"Data Source = SENITHUMESHA\SQLEXPRESS;Initial catalog = ZEMO_Bank;User ID=admin;Password=admin";

                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string sql = "Select * from ManagementAccountDetails where Name = '" + txtaccname.Text + "' and Password = '" + txtpin.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (MessageBox.Show("Login Successfully", "Management Login", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        signinName = txtaccname.Text;
                        signinPin = txtpin.Text;

                        this.Hide();
                        AdminDash Adash = new AdminDash();
                        Adash.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Either your account name or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cnn.Close();
            }
        }

        private void txtaccname_Enter(object sender, EventArgs e)
        {
            if (txtaccname.Text.Equals("     Account Name"))
            {
                txtaccname.Text = "";
            }
        }

        private void txtaccname_Leave(object sender, EventArgs e)
        {
            if (txtaccname.Text.Equals(""))
            {
                txtaccname.Text = "     Account Name";
            }
        }

        private void txtpin_Enter(object sender, EventArgs e)
        {
            if (txtpin.Text.Equals("     PIN Number") || txtpin.Text.Equals("     Password"))
            {
                txtpin.Text = "";
            }
        }

        private void txtpin_Leave(object sender, EventArgs e)
        {
            if (txtpin.Text.Equals(""))
            {
                if (type == 0)
                {
                    txtpin.Text = "     PIN Number";
                }
                else 
                {
                    txtpin.Text = "     Password";
                }
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    txtpin.Text = "     Password";
                }
                else 
                {
                    txtpin.Text = "     PIN Number";
                }

                txtaccname.Visible = true;
                txtpin.Visible = true;
                btnsignin.Visible = true;
            }

            type = comboBox1.SelectedIndex;
        }
    }
}
