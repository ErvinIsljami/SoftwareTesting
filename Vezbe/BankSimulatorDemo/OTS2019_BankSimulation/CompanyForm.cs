using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS2019_BankSimulation
{
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.CreatingCompany(tbxCompanyName.Text, decimal.Parse(tbxCompanyMA.Text), decimal.Parse(tbxCompanyBalance.Text));
            tbxCompanyBalance.Text = "";
            tbxCompanyName.Text = "";
            tbxCompanyMA.Text = "";
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1.disableElements();
        }
    }
}
