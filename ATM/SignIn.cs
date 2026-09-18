using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATM
{
    public partial class Home : Form
    {
        public static string signinName;
        public static string signinPin;
        public static string signinAccNo;
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
            Close();
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            string accountName = txtaccname.Text.Trim();
            string credential = txtpin.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountName) || string.IsNullOrWhiteSpace(credential))
            {
                MessageBox.Show("Account name and credential are required.", "Sign in",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (type == 0)
                {
                    if (!TryAuthenticateCustomer(accountName, credential, out string accountNumber))
                    {
                        MessageBox.Show("Either your account name or PIN number is incorrect.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    signinName = accountName;
                    signinPin = credential;
                    signinAccNo = accountNumber;

                    Hide();
                    using (Dash1 dash = new Dash1())
                    {
                        dash.ShowDialog();
                    }
                    Show();
                }
                else if (type == 1)
                {
                    if (!TryAuthenticateManager(accountName, credential))
                    {
                        MessageBox.Show("Either your account name or password is incorrect.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    signinName = accountName;
                    signinPin = null;
                    signinAccNo = null;

                    Hide();
                    using (AdminDash adminDash = new AdminDash())
                    {
                        adminDash.ShowDialog();
                    }
                    Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sign in could not be completed. " + ex.Message, "Sign in",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static bool TryAuthenticateCustomer(string name, string pin, out string accountNumber)
        {
            accountNumber = null;

            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT AccNo, Pin FROM UserAccountDetails WHERE Name = @Name",
                connection))
            {
                command.Parameters.AddWithValue("@Name", name);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string storedPin = Convert.ToString(reader["Pin"]);
                        if (CredentialHasher.Verify(pin, storedPin, out bool legacyPlaintext))
                        {
                            accountNumber = Convert.ToString(reader["AccNo"]);
                            reader.Close();

                            if (legacyPlaintext)
                            {
                                UpgradeCustomerPin(connection, accountNumber, pin);
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static bool TryAuthenticateManager(string name, string password)
        {
            using (SqlConnection connection = Database.OpenConnection())
            using (SqlCommand command = new SqlCommand(
                "SELECT AccNo, Password FROM ManagementAccountDetails WHERE Name = @Name",
                connection))
            {
                command.Parameters.AddWithValue("@Name", name);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string storedPassword = Convert.ToString(reader["Password"]);
                        if (CredentialHasher.Verify(password, storedPassword, out bool legacyPlaintext))
                        {
                            string accountNumber = Convert.ToString(reader["AccNo"]);
                            reader.Close();

                            if (legacyPlaintext)
                            {
                                using (SqlCommand update = new SqlCommand(
                                    "UPDATE ManagementAccountDetails SET Password = @Password WHERE AccNo = @AccNo",
                                    connection))
                                {
                                    update.Parameters.AddWithValue("@Password", CredentialHasher.Hash(password));
                                    update.Parameters.AddWithValue("@AccNo", accountNumber);
                                    update.ExecuteNonQuery();
                                }
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static void UpgradeCustomerPin(SqlConnection connection, string accountNumber, string pin)
        {
            using (SqlCommand update = new SqlCommand(
                "UPDATE UserAccountDetails SET Pin = @Pin WHERE AccNo = @AccNo",
                connection))
            {
                update.Parameters.AddWithValue("@Pin", CredentialHasher.Hash(pin));
                update.Parameters.AddWithValue("@AccNo", accountNumber);
                update.ExecuteNonQuery();
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
                txtpin.Text = type == 0 ? "     PIN Number" : "     Password";
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                type = comboBox1.SelectedIndex;
                txtpin.Text = type == 0 ? "     PIN Number" : "     Password";
                txtaccname.Visible = true;
                txtpin.Visible = true;
                btnsignin.Visible = true;
            }
        }
    }
}
