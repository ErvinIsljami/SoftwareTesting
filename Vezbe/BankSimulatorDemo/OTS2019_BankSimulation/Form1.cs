using OTS2019_BankSimulation.Class;
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
    public partial class Form1 : Form
    {
        public static UserType user;
        public static bool isChecked_rbtnCash = true;
        public static bool isChecked_rbtnRevolving = false;
        public static bool isChecked_rbtnOpen = false;

        public Form1()
        {
            InitializeComponent();
            gboxCreditType.Visible = false;
            gboxTransactionType.Visible = false;
            lblInput.Visible = false;
            lblOutput.Visible = false;
            tbxInput.Visible = false;
            tbxOutput.Visible = false;
            btnCheck.Visible = false;
            dtpDate.Visible = false;
            tbxOutput.Enabled = false;
        }

        private void rbtnCredit_CheckedChanged(object sender, EventArgs e)
        {
            gboxCreditType.Visible = true;
            tbxInput.Text = "";
            tbxOutput.Text = "";
            lblInput.Visible = false;
            lblOutput.Visible = false;
            tbxInput.Visible = false;
            tbxOutput.Visible = false;
            btnCheck.Visible = false;
            dtpDate.Visible = false;

        }

        private void rbtnPayment_CheckedChanged(object sender, EventArgs e)
        {
            gboxCreditType.Visible = false;
            lblInput.Visible = true;
            lblOutput.Visible = true;
            tbxInput.Visible = true;
            tbxOutput.Visible = true;
            btnCheck.Visible = true;
            dtpDate.Visible = false;
            tbxInput.Text = "";
            tbxOutput.Text = "";
        }

        private void rbtnTransfer_CheckedChanged(object sender, EventArgs e)
        {
            gboxCreditType.Visible = false;
            lblInput.Visible = true;
            lblOutput.Visible = true;
            tbxInput.Visible = true;
            tbxOutput.Visible = true;
            btnCheck.Visible = true;
            dtpDate.Visible = false;
            tbxInput.Text = "";
            tbxOutput.Text = "";
        }

        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Visible = true;
            lblOutput.Visible = true;
            tbxInput.Visible = true;
            tbxOutput.Visible = true;
            btnCheck.Visible = true;
            dtpDate.Visible = true;

            isChecked_rbtnCash = true;
            isChecked_rbtnRevolving = false;
            isChecked_rbtnOpen = false;
            tbxInput.Text = "";
            tbxOutput.Text = "";
        }

        private void rbtnRevolving_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Visible = true;
            lblOutput.Visible = true;
            tbxInput.Visible = true;
            tbxOutput.Visible = true;
            btnCheck.Visible = true;
            dtpDate.Visible = true;

            isChecked_rbtnCash = false;
            isChecked_rbtnRevolving = true;
            isChecked_rbtnOpen = false;
            tbxInput.Text = "";
            tbxOutput.Text = "";
        }

        private void rbtnOpen_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Visible = true;
            lblOutput.Visible = true;
            tbxInput.Visible = true;
            tbxOutput.Visible = true;
            btnCheck.Visible = true;
            dtpDate.Visible = true;

            isChecked_rbtnCash = false;
            isChecked_rbtnRevolving = false;
            isChecked_rbtnOpen = true;
            tbxInput.Text = "";
            tbxOutput.Text = "";
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserForm form2 = new UserForm();
            form2.Show();

            gboxTransactionType.Visible = true;
            btnUser.Visible = false;
            btnCompany.Visible = false;
        }

        public static void CreatingUser(string firstName, string lastName, decimal monthlyAmount, decimal balance)
        {
            user = new User(firstName, lastName, monthlyAmount, balance, false);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (rbtnPayment.Checked)
            {
                UserBanking banking = new UserBanking();
                banking.Payment(user, decimal.Parse(tbxInput.Text));
                tbxOutput.Text = "Payment was successfully made!";
            }
            else if (rbtnTransfer.Checked)
            {
                UserBanking banking = new UserBanking();
                if (banking.Transfer(user, decimal.Parse(tbxInput.Text)))
                {
                    tbxOutput.Text = "Transfer was successfully done!";
                }
                else
                {
                    tbxOutput.Text = "You don't have enough money on your account!";
                }
            }
            else if (rbtnCredit.Checked)
            {
                UserBanking banking = new UserBanking();
                if (banking.Credit(user, decimal.Parse(tbxInput.Text), dtpDate.Value))
                {
                    Console.WriteLine(dtpDate.Value);
                    tbxOutput.Text = "Credit has been successfully approved!";
                } else
                {
                    Console.WriteLine(dtpDate.Value);
                    tbxOutput.Text = "Credit request has been rejected!";
                }
            }
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            CompanyForm form3 = new CompanyForm();
            form3.Show();

            gboxTransactionType.Visible = true;
            btnUser.Visible = false;
            btnCompany.Visible = false;
        }

        public static void CreatingCompany(string name, decimal monthlyAmount, decimal balance)
        {
            user = new Company(name, monthlyAmount, balance, false);
        }

        public static void disableElements()
        {
            gboxCreditType.Visible = false;
            gboxTransactionType.Visible = false;
            lblInput.Visible = false;
            lblOutput.Visible = false;
            tbxInput.Visible = false;
            tbxOutput.Visible = false;
            btnCheck.Visible = false;

            btnCompany.Visible = true;
            btnUser.Visible = true;
        }
    }
}
