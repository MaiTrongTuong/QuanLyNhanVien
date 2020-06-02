namespace PhanMemQuanLyNhanSu
{
    partial class FormPhanCong
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
            this.label1 = new System.Windows.Forms.Label();
            this.gBInfo = new System.Windows.Forms.GroupBox();
            this.dtpThoiGianHT = new System.Windows.Forms.DateTimePicker();
            this.dtpThoiGianBD = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaDA = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gBTacVu = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvPhanCong = new System.Windows.Forms.DataGridView();
            this.MaNhanVienDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDuAnDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDauPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianHoanThanhPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBInfo.SuspendLayout();
            this.gBTacVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 56);
            this.label1.TabIndex = 15;
            this.label1.Tag = "1";
            this.label1.Text = "Quản Lý Phân Công";
            // 
            // gBInfo
            // 
            this.gBInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gBInfo.Controls.Add(this.dtpThoiGianHT);
            this.gBInfo.Controls.Add(this.dtpThoiGianBD);
            this.gBInfo.Controls.Add(this.label4);
            this.gBInfo.Controls.Add(this.label7);
            this.gBInfo.Controls.Add(this.txtMaDA);
            this.gBInfo.Controls.Add(this.txtMaNV);
            this.gBInfo.Controls.Add(this.label3);
            this.gBInfo.Controls.Add(this.label2);
            this.gBInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gBInfo.Location = new System.Drawing.Point(12, 61);
            this.gBInfo.Name = "gBInfo";
            this.gBInfo.Size = new System.Drawing.Size(370, 174);
            this.gBInfo.TabIndex = 14;
            this.gBInfo.TabStop = false;
            this.gBInfo.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // dtpThoiGianHT
            // 
            this.dtpThoiGianHT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThoiGianHT.Location = new System.Drawing.Point(133, 136);
            this.dtpThoiGianHT.Name = "dtpThoiGianHT";
            this.dtpThoiGianHT.Size = new System.Drawing.Size(200, 22);
            this.dtpThoiGianHT.TabIndex = 16;
            // 
            // dtpThoiGianBD
            // 
            this.dtpThoiGianBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThoiGianBD.Location = new System.Drawing.Point(133, 101);
            this.dtpThoiGianBD.Name = "dtpThoiGianBD";
            this.dtpThoiGianBD.Size = new System.Drawing.Size(200, 22);
            this.dtpThoiGianBD.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Thời Gian HT(DK) :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Thời Gian BĐ(DK) :";
            // 
            // txtMaDA
            // 
            this.txtMaDA.Location = new System.Drawing.Point(133, 59);
            this.txtMaDA.Multiline = true;
            this.txtMaDA.Name = "txtMaDA";
            this.txtMaDA.Size = new System.Drawing.Size(200, 24);
            this.txtMaDA.TabIndex = 6;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(133, 26);
            this.txtMaNV.Multiline = true;
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(200, 24);
            this.txtMaNV.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Dự Án :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Nhân Viên :";
            // 
            // gBTacVu
            // 
            this.gBTacVu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gBTacVu.Controls.Add(this.btnThoat);
            this.gBTacVu.Controls.Add(this.btnReload);
            this.gBTacVu.Controls.Add(this.btnHuy);
            this.gBTacVu.Controls.Add(this.btnLuu);
            this.gBTacVu.Controls.Add(this.btnSua);
            this.gBTacVu.Controls.Add(this.btnXoa);
            this.gBTacVu.Controls.Add(this.btnThem);
            this.gBTacVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBTacVu.Location = new System.Drawing.Point(398, 61);
            this.gBTacVu.Name = "gBTacVu";
            this.gBTacVu.Size = new System.Drawing.Size(940, 174);
            this.gBTacVu.TabIndex = 12;
            this.gBTacVu.TabStop = false;
            this.gBTacVu.Text = "TÁC VỤ";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(254, 122);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(192, 40);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(20, 122);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(192, 40);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(254, 72);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(122, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(88, 72);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(124, 40);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(176, 21);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(122, 40);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(330, 21);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(116, 40);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(20, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(124, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvPhanCong
            // 
            this.dgvPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVienDA,
            this.MaDuAnDA,
            this.ThoiGianBatDauPC,
            this.ThoiGianHoanThanhPC});
            this.dgvPhanCong.Location = new System.Drawing.Point(12, 241);
            this.dgvPhanCong.Name = "dgvPhanCong";
            this.dgvPhanCong.Size = new System.Drawing.Size(1326, 483);
            this.dgvPhanCong.TabIndex = 16;
            this.dgvPhanCong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhanCong_CellClick);
            // 
            // MaNhanVienDA
            // 
            this.MaNhanVienDA.DataPropertyName = "MaNV";
            this.MaNhanVienDA.HeaderText = "MaNV";
            this.MaNhanVienDA.Name = "MaNhanVienDA";
            // 
            // MaDuAnDA
            // 
            this.MaDuAnDA.DataPropertyName = "MaDA";
            this.MaDuAnDA.HeaderText = "Mã dự án";
            this.MaDuAnDA.Name = "MaDuAnDA";
            // 
            // ThoiGianBatDauPC
            // 
            this.ThoiGianBatDauPC.DataPropertyName = "ThoiGianStart";
            this.ThoiGianBatDauPC.HeaderText = "Thời gian bắt đầu";
            this.ThoiGianBatDauPC.Name = "ThoiGianBatDauPC";
            // 
            // ThoiGianHoanThanhPC
            // 
            this.ThoiGianHoanThanhPC.DataPropertyName = "ThoiGianEnd";
            this.ThoiGianHoanThanhPC.HeaderText = "Thời gian dự kiến hoàn thành";
            this.ThoiGianHoanThanhPC.Name = "ThoiGianHoanThanhPC";
            // 
            // FormPhanCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.dgvPhanCong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gBInfo);
            this.Controls.Add(this.gBTacVu);
            this.Name = "FormPhanCong";
            this.Text = "FormPhanCong";
            this.Load += new System.EventHandler(this.FormPhanCong_Load);
            this.gBInfo.ResumeLayout(false);
            this.gBInfo.PerformLayout();
            this.gBTacVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaDA;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gBTacVu;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvPhanCong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpThoiGianHT;
        private System.Windows.Forms.DateTimePicker dtpThoiGianBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVienDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDuAnDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDauPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianHoanThanhPC;
    }
}