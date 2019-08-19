namespace OTS2019_BankSimulation
{
    partial class CompanyForm
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
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblCompanyMA = new System.Windows.Forms.Label();
            this.lblCompanyBalance = new System.Windows.Forms.Label();
            this.tbxCompanyName = new System.Windows.Forms.TextBox();
            this.tbxCompanyMA = new System.Windows.Forms.TextBox();
            this.tbxCompanyBalance = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(38, 61);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(38, 13);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Name:";
            // 
            // lblCompanyMA
            // 
            this.lblCompanyMA.AutoSize = true;
            this.lblCompanyMA.Location = new System.Drawing.Point(38, 92);
            this.lblCompanyMA.Name = "lblCompanyMA";
            this.lblCompanyMA.Size = new System.Drawing.Size(86, 13);
            this.lblCompanyMA.TabIndex = 1;
            this.lblCompanyMA.Text = "Monthly Amount:";
            // 
            // lblCompanyBalance
            // 
            this.lblCompanyBalance.AutoSize = true;
            this.lblCompanyBalance.Location = new System.Drawing.Point(38, 120);
            this.lblCompanyBalance.Name = "lblCompanyBalance";
            this.lblCompanyBalance.Size = new System.Drawing.Size(49, 13);
            this.lblCompanyBalance.TabIndex = 2;
            this.lblCompanyBalance.Text = "Balance:";
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Location = new System.Drawing.Point(135, 58);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.Size = new System.Drawing.Size(100, 20);
            this.tbxCompanyName.TabIndex = 4;
            // 
            // tbxCompanyMA
            // 
            this.tbxCompanyMA.Location = new System.Drawing.Point(135, 89);
            this.tbxCompanyMA.Name = "tbxCompanyMA";
            this.tbxCompanyMA.Size = new System.Drawing.Size(100, 20);
            this.tbxCompanyMA.TabIndex = 5;
            // 
            // tbxCompanyBalance
            // 
            this.tbxCompanyBalance.Location = new System.Drawing.Point(135, 117);
            this.tbxCompanyBalance.Name = "tbxCompanyBalance";
            this.tbxCompanyBalance.Size = new System.Drawing.Size(100, 20);
            this.tbxCompanyBalance.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(159, 170);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 290);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbxCompanyBalance);
            this.Controls.Add(this.tbxCompanyMA);
            this.Controls.Add(this.tbxCompanyName);
            this.Controls.Add(this.lblCompanyBalance);
            this.Controls.Add(this.lblCompanyMA);
            this.Controls.Add(this.lblCompanyName);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblCompanyMA;
        private System.Windows.Forms.Label lblCompanyBalance;
        private System.Windows.Forms.TextBox tbxCompanyName;
        private System.Windows.Forms.TextBox tbxCompanyMA;
        private System.Windows.Forms.TextBox tbxCompanyBalance;
        private System.Windows.Forms.Button btnCreate;
    }
}