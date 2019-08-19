using Client.Objects;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    partial class Canvas
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
            pnlCenter = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnDeleteLabel = new System.Windows.Forms.Button();
            this.btnAddLabel = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnRelation = new System.Windows.Forms.Button();
            this.btnEvent_Two = new System.Windows.Forms.Button();
            this.btnEvent_One = new System.Windows.Forms.Button();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            pnlCenter.BackColor = System.Drawing.SystemColors.Window;
            pnlCenter.Location = new System.Drawing.Point(110, 12);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new System.Drawing.Size(755, 374);
            pnlCenter.TabIndex = 3;
            pnlCenter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlCenter_MouseClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnDeleteLabel);
            this.pnlLeft.Controls.Add(this.btnAddLabel);
            this.pnlLeft.Controls.Add(this.btnRedo);
            this.pnlLeft.Controls.Add(this.btnUndo);
            this.pnlLeft.Controls.Add(this.btnMove);
            this.pnlLeft.Controls.Add(this.btnDelete);
            this.pnlLeft.Controls.Add(this.btnSelect);
            this.pnlLeft.Controls.Add(this.btnRelation);
            this.pnlLeft.Controls.Add(this.btnEvent_Two);
            this.pnlLeft.Controls.Add(this.btnEvent_One);
            this.pnlLeft.Location = new System.Drawing.Point(2, 12);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(102, 452);
            this.pnlLeft.TabIndex = 4;
            // 
            // btnDeleteLabel
            // 
            this.btnDeleteLabel.Location = new System.Drawing.Point(3, 317);
            this.btnDeleteLabel.Name = "btnDeleteLabel";
            this.btnDeleteLabel.Size = new System.Drawing.Size(91, 34);
            this.btnDeleteLabel.TabIndex = 9;
            this.btnDeleteLabel.Text = "Delete Label";
            this.btnDeleteLabel.UseVisualStyleBackColor = true;
            this.btnDeleteLabel.Click += new System.EventHandler(this.btnDeleteLabel_Click);
            // 
            // btnAddLabel
            // 
            this.btnAddLabel.Location = new System.Drawing.Point(0, 277);
            this.btnAddLabel.Name = "btnAddLabel";
            this.btnAddLabel.Size = new System.Drawing.Size(91, 34);
            this.btnAddLabel.TabIndex = 8;
            this.btnAddLabel.Text = "Add Label";
            this.btnAddLabel.UseVisualStyleBackColor = true;
            this.btnAddLabel.Click += new System.EventHandler(this.btnAddLabel_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(4, 412);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(91, 34);
            this.btnRedo.TabIndex = 7;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(4, 372);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(91, 34);
            this.btnUndo.TabIndex = 6;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(4, 83);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(91, 34);
            this.btnMove.TabIndex = 5;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(4, 43);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(4, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(91, 34);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRelation
            // 
            this.btnRelation.Location = new System.Drawing.Point(3, 222);
            this.btnRelation.Name = "btnRelation";
            this.btnRelation.Size = new System.Drawing.Size(91, 34);
            this.btnRelation.TabIndex = 2;
            this.btnRelation.Text = "Relation";
            this.btnRelation.UseVisualStyleBackColor = true;
            this.btnRelation.Click += new System.EventHandler(this.btnRelation_Click);
            // 
            // btnEvent_Two
            // 
            this.btnEvent_Two.Location = new System.Drawing.Point(4, 182);
            this.btnEvent_Two.Name = "btnEvent_Two";
            this.btnEvent_Two.Size = new System.Drawing.Size(91, 34);
            this.btnEvent_Two.TabIndex = 1;
            this.btnEvent_Two.Text = "Rectangle Blue";
            this.btnEvent_Two.UseVisualStyleBackColor = true;
            this.btnEvent_Two.Click += new System.EventHandler(this.btnEvent_Two_Click);
            // 
            // btnEvent_One
            // 
            this.btnEvent_One.Location = new System.Drawing.Point(4, 142);
            this.btnEvent_One.Name = "btnEvent_One";
            this.btnEvent_One.Size = new System.Drawing.Size(91, 34);
            this.btnEvent_One.TabIndex = 0;
            this.btnEvent_One.Text = "Rectangle Red";
            this.btnEvent_One.UseVisualStyleBackColor = true;
            this.btnEvent_One.Click += new System.EventHandler(this.btnEvent_One_Click);
            // 
            // tbxLog
            // 
            this.tbxLog.Location = new System.Drawing.Point(110, 392);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.Size = new System.Drawing.Size(755, 72);
            this.tbxLog.TabIndex = 5;
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 471);
            this.Controls.Add(this.tbxLog);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(pnlCenter);
            this.Name = "Canvas";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Canvas_Load);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnEvent_Two;
        private System.Windows.Forms.Button btnEvent_One;
        private System.Windows.Forms.Button btnRelation;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        public System.Windows.Forms.TextBox tbxLog;
        private System.Windows.Forms.Button btnDeleteLabel;
        private System.Windows.Forms.Button btnAddLabel;
        public static System.Windows.Forms.Panel pnlCenter;

        public Button BtnRedo { get => btnRedo; set => btnRedo = value; }
        public Button BtnUndo { get => btnUndo; set => btnUndo = value; }
    }
}

