using OTS2019_BankSimulation.Models;
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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.CreatingUser(tbxFN.Text, tbxLN.Text, decimal.Parse(tbxMA.Text), decimal.Parse(tbxBalance.Text));
            tbxBalance.Text = "";
            tbxFN.Text = "";
            tbxLN.Text = "";
            tbxMA.Text = "";
        }

        public string getFN()
        {
            return tbxFN.Text;
        }

        public string getLN()
        {
            return tbxLN.Text;
        }

        public decimal getMA()
        {
            return decimal.Parse(tbxMA.Text);
        }

        public decimal getBalance()
        {
            return decimal.Parse(tbxBalance.Text);
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1.disableElements();
        }
    }
}
