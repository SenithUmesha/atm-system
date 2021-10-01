using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class BillPayment : Form
    {
        public BillPayment()
        {
            InitializeComponent();
        }

        private void pbwater_Click(object sender, EventArgs e)
        {
            electricity1.Hide();
            water1.Show();
        }

        private void pbelectricity_Click(object sender, EventArgs e)
        {
            water1.Hide();
            electricity1.Show();
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

        private void BillPayment_Load(object sender, EventArgs e)
        {
            water1.Hide();
            electricity1.Hide();
        }
    }
}
