namespace OTS2019_ConvertorDemo
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
            this.gboxConverter = new System.Windows.Forms.GroupBox();
            this.rbtnTime = new System.Windows.Forms.RadioButton();
            this.rbtnMoney = new System.Windows.Forms.RadioButton();
            this.rbtnLength = new System.Windows.Forms.RadioButton();
            this.rbtnMass = new System.Windows.Forms.RadioButton();
            this.gboxTime = new System.Windows.Forms.GroupBox();
            this.rbtnSeconds = new System.Windows.Forms.RadioButton();
            this.rbtnMinutes = new System.Windows.Forms.RadioButton();
            this.rbtnHours = new System.Windows.Forms.RadioButton();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.rbtnCustomMoney = new System.Windows.Forms.RadioButton();
            this.gboxConverter.SuspendLayout();
            this.gboxTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxConverter
            // 
            this.gboxConverter.Controls.Add(this.rbtnCustomMoney);
            this.gboxConverter.Controls.Add(this.rbtnTime);
            this.gboxConverter.Controls.Add(this.rbtnMoney);
            this.gboxConverter.Controls.Add(this.rbtnLength);
            this.gboxConverter.Controls.Add(this.rbtnMass);
            this.gboxConverter.Location = new System.Drawing.Point(23, 26);
            this.gboxConverter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gboxConverter.Name = "gboxConverter";
            this.gboxConverter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gboxConverter.Size = new System.Drawing.Size(131, 81);
            this.gboxConverter.TabIndex = 0;
            this.gboxConverter.TabStop = false;
            this.gboxConverter.Text = "Converter type";
            // 
            // rbtnTime
            // 
            this.rbtnTime.AutoSize = true;
            this.rbtnTime.Location = new System.Drawing.Point(69, 41);
            this.rbtnTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnTime.Name = "rbtnTime";
            this.rbtnTime.Size = new System.Drawing.Size(48, 17);
            this.rbtnTime.TabIndex = 3;
            this.rbtnTime.TabStop = true;
            this.rbtnTime.Text = "Time";
            this.rbtnTime.UseVisualStyleBackColor = true;
            this.rbtnTime.CheckedChanged += new System.EventHandler(this.rbtnTime_CheckedChanged);
            // 
            // rbtnMoney
            // 
            this.rbtnMoney.AutoSize = true;
            this.rbtnMoney.Location = new System.Drawing.Point(69, 18);
            this.rbtnMoney.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnMoney.Name = "rbtnMoney";
            this.rbtnMoney.Size = new System.Drawing.Size(57, 17);
            this.rbtnMoney.TabIndex = 2;
            this.rbtnMoney.TabStop = true;
            this.rbtnMoney.Text = "Money";
            this.rbtnMoney.UseVisualStyleBackColor = true;
            this.rbtnMoney.CheckedChanged += new System.EventHandler(this.rbtnMoney_CheckedChanged);
            // 
            // rbtnLength
            // 
            this.rbtnLength.AutoSize = true;
            this.rbtnLength.Location = new System.Drawing.Point(5, 41);
            this.rbtnLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnLength.Name = "rbtnLength";
            this.rbtnLength.Size = new System.Drawing.Size(58, 17);
            this.rbtnLength.TabIndex = 1;
            this.rbtnLength.TabStop = true;
            this.rbtnLength.Text = "Length";
            this.rbtnLength.UseVisualStyleBackColor = true;
            this.rbtnLength.CheckedChanged += new System.EventHandler(this.rbtnLength_CheckedChanged);
            // 
            // rbtnMass
            // 
            this.rbtnMass.AutoSize = true;
            this.rbtnMass.Location = new System.Drawing.Point(5, 18);
            this.rbtnMass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnMass.Name = "rbtnMass";
            this.rbtnMass.Size = new System.Drawing.Size(50, 17);
            this.rbtnMass.TabIndex = 0;
            this.rbtnMass.TabStop = true;
            this.rbtnMass.Text = "Mass";
            this.rbtnMass.UseVisualStyleBackColor = true;
            this.rbtnMass.CheckedChanged += new System.EventHandler(this.rbtnMass_CheckedChanged);
            // 
            // gboxTime
            // 
            this.gboxTime.Controls.Add(this.rbtnSeconds);
            this.gboxTime.Controls.Add(this.rbtnMinutes);
            this.gboxTime.Controls.Add(this.rbtnHours);
            this.gboxTime.Location = new System.Drawing.Point(169, 26);
            this.gboxTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gboxTime.Name = "gboxTime";
            this.gboxTime.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gboxTime.Size = new System.Drawing.Size(150, 90);
            this.gboxTime.TabIndex = 1;
            this.gboxTime.TabStop = false;
            this.gboxTime.Text = "Time output";
            this.gboxTime.Visible = false;
            // 
            // rbtnSeconds
            // 
            this.rbtnSeconds.AutoSize = true;
            this.rbtnSeconds.Location = new System.Drawing.Point(5, 64);
            this.rbtnSeconds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnSeconds.Name = "rbtnSeconds";
            this.rbtnSeconds.Size = new System.Drawing.Size(67, 17);
            this.rbtnSeconds.TabIndex = 2;
            this.rbtnSeconds.TabStop = true;
            this.rbtnSeconds.Text = "Seconds";
            this.rbtnSeconds.UseVisualStyleBackColor = true;
            this.rbtnSeconds.CheckedChanged += new System.EventHandler(this.rbtnSeconds_CheckedChanged);
            // 
            // rbtnMinutes
            // 
            this.rbtnMinutes.AutoSize = true;
            this.rbtnMinutes.Location = new System.Drawing.Point(5, 41);
            this.rbtnMinutes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnMinutes.Name = "rbtnMinutes";
            this.rbtnMinutes.Size = new System.Drawing.Size(62, 17);
            this.rbtnMinutes.TabIndex = 1;
            this.rbtnMinutes.TabStop = true;
            this.rbtnMinutes.Text = "Minutes";
            this.rbtnMinutes.UseVisualStyleBackColor = true;
            this.rbtnMinutes.CheckedChanged += new System.EventHandler(this.rbtnMinutes_CheckedChanged);
            // 
            // rbtnHours
            // 
            this.rbtnHours.AutoSize = true;
            this.rbtnHours.Location = new System.Drawing.Point(5, 18);
            this.rbtnHours.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtnHours.Name = "rbtnHours";
            this.rbtnHours.Size = new System.Drawing.Size(53, 17);
            this.rbtnHours.TabIndex = 0;
            this.rbtnHours.TabStop = true;
            this.rbtnHours.Text = "Hours";
            this.rbtnHours.UseVisualStyleBackColor = true;
            this.rbtnHours.CheckedChanged += new System.EventHandler(this.rbtnHours_CheckedChanged);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(115, 161);
            this.lblInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(35, 13);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "label1";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(115, 188);
            this.lblOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(35, 13);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.Text = "label2";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(170, 156);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(76, 20);
            this.txtInput.TabIndex = 4;
            // 
            // txtOutput
            // 
            this.txtOutput.Enabled = false;
            this.txtOutput.Location = new System.Drawing.Point(170, 188);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(76, 20);
            this.txtOutput.TabIndex = 5;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(172, 226);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(68, 26);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // rbtnCustomMoney
            // 
            this.rbtnCustomMoney.AutoSize = true;
            this.rbtnCustomMoney.Location = new System.Drawing.Point(21, 63);
            this.rbtnCustomMoney.Name = "rbtnCustomMoney";
            this.rbtnCustomMoney.Size = new System.Drawing.Size(95, 17);
            this.rbtnCustomMoney.TabIndex = 4;
            this.rbtnCustomMoney.TabStop = true;
            this.rbtnCustomMoney.Text = "Custom Money";
            this.rbtnCustomMoney.UseVisualStyleBackColor = true;
            this.rbtnCustomMoney.CheckedChanged += new System.EventHandler(this.rbtnCustomMoney_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 366);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.gboxTime);
            this.Controls.Add(this.gboxConverter);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gboxConverter.ResumeLayout(false);
            this.gboxConverter.PerformLayout();
            this.gboxTime.ResumeLayout(false);
            this.gboxTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxConverter;
        private System.Windows.Forms.RadioButton rbtnTime;
        private System.Windows.Forms.RadioButton rbtnMoney;
        private System.Windows.Forms.RadioButton rbtnLength;
        private System.Windows.Forms.RadioButton rbtnMass;
        private System.Windows.Forms.GroupBox gboxTime;
        private System.Windows.Forms.RadioButton rbtnSeconds;
        private System.Windows.Forms.RadioButton rbtnMinutes;
        private System.Windows.Forms.RadioButton rbtnHours;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.RadioButton rbtnCustomMoney;
    }
}

