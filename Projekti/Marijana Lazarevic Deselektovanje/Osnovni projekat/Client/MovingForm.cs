using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MovingForm : Form
    {

        public MovingForm()
        {
            InitializeComponent();
        }

        public string GetX()
        {
            return this.tbxX.Text;
        }
        
        public string GetY()
        {
            return this.tbxY.Text;
        }

        public void SetX(string s)
        {
            this.tbxX.Text = s;
        }

        public void SetY(string s)
        {
            this.tbxY.Text = s;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            this.Hide();

            Canvas.Moving(this.tbxX.Text, this.tbxY.Text);
            this.tbxX.Text = "";
            this.tbxY.Text = "";
        }
    }
}
