namespace Paint
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
            this.btzom = new System.Windows.Forms.Button();
            this.btFill = new System.Windows.Forms.Button();
            this.btZoom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btmove = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btdel = new System.Windows.Forms.Button();
            this.btselec = new System.Windows.Forms.Button();
            this.btcir = new System.Windows.Forms.Button();
            this.btsqr = new System.Windows.Forms.Button();
            this.btrect = new System.Windows.Forms.Button();
            this.btline = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.btzom);
            this.panel1.Controls.Add(this.btFill);
            this.panel1.Controls.Add(this.btZoom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btmove);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.btdel);
            this.panel1.Controls.Add(this.btselec);
            this.panel1.Location = new System.Drawing.Point(9, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 318);
            this.panel1.TabIndex = 0;
            // 
            // btzom
            // 
            this.btzom.BackColor = System.Drawing.Color.Gray;
            this.btzom.Location = new System.Drawing.Point(104, 191);
            this.btzom.Name = "btzom";
            this.btzom.Size = new System.Drawing.Size(61, 45);
            this.btzom.TabIndex = 19;
            this.btzom.Text = "Zoom Out";
            this.btzom.UseVisualStyleBackColor = false;
            this.btzom.Click += new System.EventHandler(this.btzom_Click);
            // 
            // btFill
            // 
            this.btFill.Location = new System.Drawing.Point(104, 256);
            this.btFill.Name = "btFill";
            this.btFill.Size = new System.Drawing.Size(61, 45);
            this.btFill.TabIndex = 18;
            this.btFill.Text = "Fill";
            this.btFill.UseVisualStyleBackColor = true;
            this.btFill.Click += new System.EventHandler(this.btFill_Click);
            // 
            // btZoom
            // 
            this.btZoom.BackColor = System.Drawing.Color.Gray;
            this.btZoom.Location = new System.Drawing.Point(24, 191);
            this.btZoom.Name = "btZoom";
            this.btZoom.Size = new System.Drawing.Size(60, 45);
            this.btZoom.TabIndex = 17;
            this.btZoom.Text = "Zoom In";
            this.btZoom.UseVisualStyleBackColor = false;
            this.btZoom.Click += new System.EventHandler(this.btZoom_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(510, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Double Click to Select and Delete";
            // 
            // btmove
            // 
            this.btmove.BackColor = System.Drawing.Color.Gray;
            this.btmove.Location = new System.Drawing.Point(24, 256);
            this.btmove.Name = "btmove";
            this.btmove.Size = new System.Drawing.Size(61, 45);
            this.btmove.TabIndex = 15;
            this.btmove.Text = "Move";
            this.btmove.UseVisualStyleBackColor = false;
            this.btmove.Click += new System.EventHandler(this.btmove_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Solid",
            "Dot",
            "Dash",
            "DashDot",
            "DashDotDot"});
            this.comboBox1.Location = new System.Drawing.Point(85, 9);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Text = "Solid";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btel
            // 
            this.btel.Location = new System.Drawing.Point(23, 147);
            this.btel.Margin = new System.Windows.Forms.Padding(2);
            this.btel.Name = "btel";
            this.btel.Size = new System.Drawing.Size(61, 45);
            this.btel.TabIndex = 13;
            this.btel.Text = "Ellipse";
            this.btel.UseVisualStyleBackColor = true;
            this.btel.Click += new System.EventHandler(this.btel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-9, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(117, 84);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(85, 47);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(82, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btdel
            // 
            this.btdel.BackColor = System.Drawing.Color.Gray;
            this.btdel.Location = new System.Drawing.Point(104, 127);
            this.btdel.Margin = new System.Windows.Forms.Padding(2);
            this.btdel.Name = "btdel";
            this.btdel.Size = new System.Drawing.Size(61, 45);
            this.btdel.TabIndex = 7;
            this.btdel.Text = "Del";
            this.btdel.UseVisualStyleBackColor = false;
            this.btdel.Click += new System.EventHandler(this.btdel_Click);
            // 
            // btselec
            // 
            this.btselec.BackColor = System.Drawing.Color.Gray;
            this.btselec.Location = new System.Drawing.Point(23, 127);
            this.btselec.Margin = new System.Windows.Forms.Padding(2);
            this.btselec.Name = "btselec";
            this.btselec.Size = new System.Drawing.Size(61, 45);
            this.btselec.TabIndex = 6;
            this.btselec.Text = "Select";
            this.btselec.UseVisualStyleBackColor = false;
            this.btselec.Click += new System.EventHandler(this.btselec_Click);
            // 
            // btcir
            // 
            this.btcir.Location = new System.Drawing.Point(104, 82);
            this.btcir.Margin = new System.Windows.Forms.Padding(2);
            this.btcir.Name = "btcir";
            this.btcir.Size = new System.Drawing.Size(61, 45);
            this.btcir.TabIndex = 3;
            this.btcir.Text = "Circle";
            this.btcir.UseVisualStyleBackColor = true;
            this.btcir.Click += new System.EventHandler(this.btcir_Click);
            // 
            // btsqr
            // 
            this.btsqr.Location = new System.Drawing.Point(23, 82);
            this.btsqr.Margin = new System.Windows.Forms.Padding(2);
            this.btsqr.Name = "btsqr";
            this.btsqr.Size = new System.Drawing.Size(61, 45);
            this.btsqr.TabIndex = 2;
            this.btsqr.Text = "Square";
            this.btsqr.UseVisualStyleBackColor = true;
            this.btsqr.Click += new System.EventHandler(this.btsqr_Click);
            // 
            // btrect
            // 
            this.btrect.Location = new System.Drawing.Point(104, 19);
            this.btrect.Margin = new System.Windows.Forms.Padding(2);
            this.btrect.Name = "btrect";
            this.btrect.Size = new System.Drawing.Size(61, 45);
            this.btrect.TabIndex = 1;
            this.btrect.Text = "Rect";
            this.btrect.UseVisualStyleBackColor = true;
            this.btrect.Click += new System.EventHandler(this.btrect_Click);
            // 
            // btline
            // 
            this.btline.Location = new System.Drawing.Point(23, 19);
            this.btline.Margin = new System.Windows.Forms.Padding(2);
            this.btline.Name = "btline";
            this.btline.Size = new System.Drawing.Size(61, 45);
            this.btline.TabIndex = 0;
            this.btline.Text = "Line";
            this.btline.UseVisualStyleBackColor = true;
            this.btline.Click += new System.EventHandler(this.btline_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(221, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(918, 640);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDoubleClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(92, 169);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 2;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btline);
            this.panel2.Controls.Add(this.btClear);
            this.panel2.Controls.Add(this.btrect);
            this.panel2.Controls.Add(this.btsqr);
            this.panel2.Controls.Add(this.btcir);
            this.panel2.Controls.Add(this.btel);
            this.panel2.Location = new System.Drawing.Point(9, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 305);
            this.panel2.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(20, 17);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(45, 13);
            this.label.TabIndex = 20;
            this.label.Text = "Loại bút";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Độ dày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Màu sắc";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 668);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1180, 718);
            this.MinimumSize = new System.Drawing.Size(1180, 688);
            this.Name = "Form1";
            this.Text = "Paint Demo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btdel;
        private System.Windows.Forms.Button btselec;
        private System.Windows.Forms.Button btcir;
        private System.Windows.Forms.Button btsqr;
        private System.Windows.Forms.Button btrect;
        private System.Windows.Forms.Button btline;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btmove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btZoom;
        private System.Windows.Forms.Button btFill;
        private System.Windows.Forms.Button btzom;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

