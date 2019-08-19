using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTS2019_ConvertorDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rbtnMass_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Text = "pounds";
            lblOutput.Text = "kg";
            gboxTime.Visible = false;
        }

        private void rbtnLength_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Text = "feet";
            lblOutput.Text = "m";
            gboxTime.Visible = false;
        }

        private void rbtnMoney_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Text = "eur";
            lblOutput.Text = "rsd";
            gboxTime.Visible = false;
        }

        private void rbtnTime_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Text = "days";
            lblOutput.Text = "hours";
            gboxTime.Visible = true;
            rbtnHours.Checked = true;
        }

        private void rbtnHours_CheckedChanged(object sender, EventArgs e)
        {
            lblOutput.Text = "hours";
        }

        private void rbtnMinutes_CheckedChanged(object sender, EventArgs e)
        {
            lblOutput.Text = "minutes";
        }

        private void rbtnSeconds_CheckedChanged(object sender, EventArgs e)
        {
            lblOutput.Text = "seconds";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;

            if (rbtnMass.Checked)
            {
                MassConverter massConverter = new MassConverter();
                txtOutput.Text = Math.Round(massConverter.Convert(Double.Parse(input)), 2).ToString();
            }
            else if (rbtnLength.Checked)
            {
                LengthConverter massConverter = new LengthConverter();
                txtOutput.Text = Math.Round(massConverter.Convert(Double.Parse(input)), 2).ToString();
            }
            else if (rbtnMoney.Checked)
            {
                MoneyConvertor money = new MoneyConvertor();
                txtOutput.Text = money.Convert(Decimal.Parse(input)).ToString();
            }
            else if (rbtnTime.Checked && rbtnHours.Checked)
            {
                TimeConvertor time = new TimeConvertor();
                txtOutput.Text = time.DaysToHours(Int32.Parse(input)).ToString();
            }
            else if (rbtnTime.Checked && rbtnMinutes.Checked)
            {
                TimeConvertor time = new TimeConvertor();
                txtOutput.Text = time.DaysToMinutes(Int32.Parse(input)).ToString();
            }
            else if (rbtnTime.Checked && rbtnSeconds.Checked)
            {
                TimeConvertor time = new TimeConvertor();
                txtOutput.Text = time.DaysToSeconds(Int32.Parse(input)).ToString();
            }
            else if (rbtnCustomMoney.Checked)
            {
                CustomMoneyConvertor custom = new CustomMoneyConvertor(input);
                txtOutput.Text = custom.Convert(Decimal.Parse(custom.inputAmount)).ToString();
            }
        }

        private void rbtnCustomMoney_CheckedChanged(object sender, EventArgs e)
        {
            lblInput.Text = "custom expression";
            lblOutput.Text = "result";
            gboxTime.Visible = false;
        }
    }
}
