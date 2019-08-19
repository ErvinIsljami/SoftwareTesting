namespace OTS2019_BankSimulation
{
    partial class Form1
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
            gboxTransactionType = new System.Windows.Forms.GroupBox();
            this.rbtnCredit = new System.Windows.Forms.RadioButton();
            this.rbtnTransfer = new System.Windows.Forms.RadioButton();
            this.rbtnPayment = new System.Windows.Forms.RadioButton();
            gboxCreditType = new System.Windows.Forms.GroupBox();
            this.rbtnOpen = new System.Windows.Forms.RadioButton();
            this.rbtnRevolving = new System.Windows.Forms.RadioButton();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            lblInput = new System.Windows.Forms.Label();
            tbxInput = new System.Windows.Forms.TextBox();
            btnCheck = new System.Windows.Forms.Button();
            tbxOutput = new System.Windows.Forms.TextBox();
            lblOutput = new System.Windows.Forms.Label();
            btnUser = new System.Windows.Forms.Button();
            btnCompany = new System.Windows.Forms.Button();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            gboxTransactionType.SuspendLayout();
            gboxCreditType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxTransactionType
            // 
            gboxTransactionType.Controls.Add(this.rbtnCredit);
            gboxTransactionType.Controls.Add(this.rbtnTransfer);
            gboxTransactionType.Controls.Add(this.rbtnPayment);
            gboxTransactionType.Location = new System.Drawing.Point(215, 12);
            gboxTransactionType.Name = "gboxTransactionType";
            gboxTransactionType.Size = new System.Drawing.Size(173, 88);
            gboxTransactionType.TabIndex = 1;
            gboxTransactionType.TabStop = false;
            gboxTransactionType.Text = "Transaction Type";
            // 
            // rbtnCredit
            // 
            this.rbtnCredit.AutoSize = true;
            this.rbtnCredit.Location = new System.Drawing.Point(7, 65);
            this.rbtnCredit.Name = "rbtnCredit";
            this.rbtnCredit.Size = new System.Drawing.Size(52, 17);
            this.rbtnCredit.TabIndex = 2;
            this.rbtnCredit.TabStop = true;
            this.rbtnCredit.Text = "Credit";
            this.rbtnCredit.UseVisualStyleBackColor = true;
            this.rbtnCredit.CheckedChanged += new System.EventHandler(this.rbtnCredit_CheckedChanged);
            // 
            // rbtnTransfer
            // 
            this.rbtnTransfer.AutoSize = true;
            this.rbtnTransfer.Location = new System.Drawing.Point(7, 43);
            this.rbtnTransfer.Name = "rbtnTransfer";
            this.rbtnTransfer.Size = new System.Drawing.Size(84, 17);
            this.rbtnTransfer.TabIndex = 1;
            this.rbtnTransfer.TabStop = true;
            this.rbtnTransfer.Text = "Transfer Out";
            this.rbtnTransfer.UseVisualStyleBackColor = true;
            this.rbtnTransfer.CheckedChanged += new System.EventHandler(this.rbtnTransfer_CheckedChanged);
            // 
            // rbtnPayment
            // 
            this.rbtnPayment.AutoSize = true;
            this.rbtnPayment.Location = new System.Drawing.Point(7, 20);
            this.rbtnPayment.Name = "rbtnPayment";
            this.rbtnPayment.Size = new System.Drawing.Size(66, 17);
            this.rbtnPayment.TabIndex = 0;
            this.rbtnPayment.TabStop = true;
            this.rbtnPayment.Text = "Payment";
            this.rbtnPayment.UseVisualStyleBackColor = true;
            this.rbtnPayment.CheckedChanged += new System.EventHandler(this.rbtnPayment_CheckedChanged);
            // 
            // gboxCreditType
            // 
            gboxCreditType.Controls.Add(this.rbtnOpen);
            gboxCreditType.Controls.Add(this.rbtnRevolving);
            gboxCreditType.Controls.Add(this.rbtnCash);
            gboxCreditType.Location = new System.Drawing.Point(12, 120);
            gboxCreditType.Name = "gboxCreditType";
            gboxCreditType.Size = new System.Drawing.Size(376, 48);
            gboxCreditType.TabIndex = 2;
            gboxCreditType.TabStop = false;
            gboxCreditType.Text = "Credit Type";
            // 
            // rbtnOpen
            // 
            this.rbtnOpen.AutoSize = true;
            this.rbtnOpen.Location = new System.Drawing.Point(248, 20);
            this.rbtnOpen.Name = "rbtnOpen";
            this.rbtnOpen.Size = new System.Drawing.Size(81, 17);
            this.rbtnOpen.TabIndex = 2;
            this.rbtnOpen.TabStop = true;
            this.rbtnOpen.Text = "Open Credit";
            this.rbtnOpen.UseVisualStyleBackColor = true;
            this.rbtnOpen.CheckedChanged += new System.EventHandler(this.rbtnOpen_CheckedChanged);
            // 
            // rbtnRevolving
            // 
            this.rbtnRevolving.AutoSize = true;
            this.rbtnRevolving.Location = new System.Drawing.Point(127, 20);
            this.rbtnRevolving.Name = "rbtnRevolving";
            this.rbtnRevolving.Size = new System.Drawing.Size(103, 17);
            this.rbtnRevolving.TabIndex = 1;
            this.rbtnRevolving.TabStop = true;
            this.rbtnRevolving.Text = "Revolving Credit";
            this.rbtnRevolving.UseVisualStyleBackColor = true;
            this.rbtnRevolving.CheckedChanged += new System.EventHandler(this.rbtnRevolving_CheckedChanged);
            // 
            // rbtnCash
            // 
            this.rbtnCash.AutoSize = true;
            this.rbtnCash.Location = new System.Drawing.Point(7, 20);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.Size = new System.Drawing.Size(79, 17);
            this.rbtnCash.TabIndex = 0;
            this.rbtnCash.TabStop = true;
            this.rbtnCash.Text = "Cash Credit";
            this.rbtnCash.UseVisualStyleBackColor = true;
            this.rbtnCash.CheckedChanged += new System.EventHandler(this.rbtnCash_CheckedChanged);
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Location = new System.Drawing.Point(51, 199);
            lblInput.Name = "lblInput";
            lblInput.Size = new System.Drawing.Size(34, 13);
            lblInput.TabIndex = 3;
            lblInput.Text = "Input:";
            // 
            // tbxInput
            // 
            tbxInput.Location = new System.Drawing.Point(139, 196);
            tbxInput.Name = "tbxInput";
            tbxInput.Size = new System.Drawing.Size(100, 20);
            tbxInput.TabIndex = 5;
            // 
            // btnCheck
            // 
            btnCheck.Location = new System.Drawing.Point(289, 229);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new System.Drawing.Size(75, 23);
            btnCheck.TabIndex = 6;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // tbxOutput
            // 
            tbxOutput.Location = new System.Drawing.Point(139, 272);
            tbxOutput.Name = "tbxOutput";
            tbxOutput.Size = new System.Drawing.Size(249, 20);
            tbxOutput.TabIndex = 7;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new System.Drawing.Point(51, 272);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new System.Drawing.Size(42, 13);
            lblOutput.TabIndex = 8;
            lblOutput.Text = "Output:";
            // 
            // btnUser
            // 
            btnUser.Location = new System.Drawing.Point(35, 26);
            btnUser.Name = "btnUser";
            btnUser.Size = new System.Drawing.Size(99, 23);
            btnUser.TabIndex = 9;
            btnUser.Text = "Create User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnCompany
            // 
            btnCompany.Location = new System.Drawing.Point(35, 55);
            btnCompany.Name = "btnCompany";
            btnCompany.Size = new System.Drawing.Size(99, 23);
            btnCompany.TabIndex = 10;
            btnCompany.Text = "Create Company";
            btnCompany.UseVisualStyleBackColor = true;
            btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // dtpDate
            // 
            dtpDate.Location = new System.Drawing.Point(54, 232);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(188, 20);
            dtpDate.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 345);
            this.Controls.Add(dtpDate);
            this.Controls.Add(btnCompany);
            this.Controls.Add(btnUser);
            this.Controls.Add(lblOutput);
            this.Controls.Add(tbxOutput);
            this.Controls.Add(btnCheck);
            this.Controls.Add(tbxInput);
            this.Controls.Add(lblInput);
            this.Controls.Add(gboxCreditType);
            this.Controls.Add(gboxTransactionType);
            this.Name = "Form1";
            this.Text = "Form1";
            gboxTransactionType.ResumeLayout(false);
            gboxTransactionType.PerformLayout();
            gboxCreditType.ResumeLayout(false);
            gboxCreditType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbtnCredit;
        private System.Windows.Forms.RadioButton rbtnTransfer;
        private System.Windows.Forms.RadioButton rbtnPayment;
        private System.Windows.Forms.RadioButton rbtnOpen;
        private System.Windows.Forms.RadioButton rbtnRevolving;
        private System.Windows.Forms.RadioButton rbtnCash;
        private static System.Windows.Forms.DateTimePicker dtpDate;
        private static System.Windows.Forms.GroupBox gboxTransactionType;
        private static System.Windows.Forms.GroupBox gboxCreditType;
        private static System.Windows.Forms.Label lblInput;
        private static System.Windows.Forms.TextBox tbxInput;
        private static System.Windows.Forms.Button btnCheck;
        private static System.Windows.Forms.TextBox tbxOutput;
        private static System.Windows.Forms.Label lblOutput;
        private static System.Windows.Forms.Button btnUser;
        private static System.Windows.Forms.Button btnCompany;
    }
}

