namespace Composite
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnComposite = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btline = new System.Windows.Forms.Button();
            this.ptbBoard = new System.Windows.Forms.PictureBox();
            this.treeViewInfo = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnComposite);
            this.panel1.Controls.Add(this.btnCircle);
            this.panel1.Controls.Add(this.btline);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 439);
            this.panel1.TabIndex = 0;
            // 
            // btnComposite
            // 
            this.btnComposite.Location = new System.Drawing.Point(3, 197);
            this.btnComposite.Margin = new System.Windows.Forms.Padding(2);
            this.btnComposite.Name = "btnComposite";
            this.btnComposite.Size = new System.Drawing.Size(73, 45);
            this.btnComposite.TabIndex = 4;
            this.btnComposite.Text = "Composite";
            this.btnComposite.UseVisualStyleBackColor = true;
            this.btnComposite.Click += new System.EventHandler(this.btnComposite_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(2, 61);
            this.btnCircle.Margin = new System.Windows.Forms.Padding(2);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(61, 45);
            this.btnCircle.TabIndex = 2;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btline
            // 
            this.btline.Location = new System.Drawing.Point(2, 2);
            this.btline.Margin = new System.Windows.Forms.Padding(2);
            this.btline.Name = "btline";
            this.btline.Size = new System.Drawing.Size(61, 45);
            this.btline.TabIndex = 1;
            this.btline.Text = "Line";
            this.btline.UseVisualStyleBackColor = true;
            this.btline.Click += new System.EventHandler(this.btline_Click);
            // 
            // ptbBoard
            // 
            this.ptbBoard.BackColor = System.Drawing.Color.White;
            this.ptbBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbBoard.Location = new System.Drawing.Point(106, 21);
            this.ptbBoard.Margin = new System.Windows.Forms.Padding(2);
            this.ptbBoard.Name = "ptbBoard";
            this.ptbBoard.Size = new System.Drawing.Size(598, 440);
            this.ptbBoard.TabIndex = 2;
            this.ptbBoard.TabStop = false;
            this.ptbBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbBoard_MouseClick);
            // 
            // treeViewInfo
            // 
            this.treeViewInfo.Location = new System.Drawing.Point(709, 21);
            this.treeViewInfo.Name = "treeViewInfo";
            this.treeViewInfo.Size = new System.Drawing.Size(274, 439);
            this.treeViewInfo.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 476);
            this.Controls.Add(this.treeViewInfo);
            this.Controls.Add(this.ptbBoard);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptbBoard;
        private System.Windows.Forms.TreeView treeViewInfo;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btline;
        private System.Windows.Forms.Button btnComposite;
    }
}

