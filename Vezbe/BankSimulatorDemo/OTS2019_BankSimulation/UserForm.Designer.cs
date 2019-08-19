namespace OTS2019_BankSimulation
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFN = new System.Windows.Forms.Label();
            this.lblLN = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblMA = new System.Windows.Forms.Label();
            this.tbxFN = new System.Windows.Forms.TextBox();
            this.tbxMA = new System.Windows.Forms.TextBox();
            this.tbxBalance = new System.Windows.Forms.TextBox();
            this.tbxLN = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFN
            // 
            this.lblFN.AutoSize = true;
            this.lblFN.Location = new System.Drawing.Point(34, 47);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(58, 13);
            this.lblFN.TabIndex = 0;
            this.lblFN.Text = "First name:";
            // 
            // lblLN
            // 
            this.lblLN.AutoSize = true;
            this.lblLN.Location = new System.Drawing.Point(34, 76);
            this.lblLN.Name = "lblLN";
            this.lblLN.Size = new System.Drawing.Size(59, 13);
            this.lblLN.TabIndex = 1;
            this.lblLN.Text = "Last name:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(34, 107);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(49, 13);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "Balance:";
            // 
            // lblMA
            // 
            this.lblMA.AutoSize = true;
            this.lblMA.Location = new System.Drawing.Point(34, 137);
            this.lblMA.Name = "lblMA";
            this.lblMA.Size = new System.Drawing.Size(86, 13);
            this.lblMA.TabIndex = 3;
            this.lblMA.Text = "Monthly Amount:";
            // 
            // tbxFN
            // 
            this.tbxFN.Location = new System.Drawing.Point(137, 44);
            this.tbxFN.Name = "tbxFN";
            this.tbxFN.Size = new System.Drawing.Size(100, 20);
            this.tbxFN.TabIndex = 5;
            // 
            // tbxMA
            // 
            this.tbxMA.Location = new System.Drawing.Point(137, 134);
            this.tbxMA.Name = "tbxMA";
            this.tbxMA.Size = new System.Drawing.Size(100, 20);
            this.tbxMA.TabIndex = 6;
            // 
            // tbxBalance
            // 
            this.tbxBalance.Location = new System.Drawing.Point(137, 104);
            this.tbxBalance.Name = "tbxBalance";
            this.tbxBalance.Size = new System.Drawing.Size(100, 20);
            this.tbxBalance.TabIndex = 7;
            // 
            // tbxLN
            // 
            this.tbxLN.Location = new System.Drawing.Point(137, 73);
            this.tbxLN.Name = "tbxLN";
            this.tbxLN.Size = new System.Drawing.Size(100, 20);
            this.tbxLN.TabIndex = 8;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(162, 182);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 292);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbxLN);
            this.Controls.Add(this.tbxBalance);
            this.Controls.Add(this.tbxMA);
            this.Controls.Add(this.tbxFN);
            this.Controls.Add(this.lblMA);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblLN);
            this.Controls.Add(this.lblFN);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFN;
        private System.Windows.Forms.Label lblLN;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblMA;
        private System.Windows.Forms.TextBox tbxFN;
        private System.Windows.Forms.TextBox tbxMA;
        private System.Windows.Forms.TextBox tbxBalance;
        private System.Windows.Forms.TextBox tbxLN;
        private System.Windows.Forms.Button btnCreate;
    }
}