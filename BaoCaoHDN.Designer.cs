namespace QuanLyTiVi
{
    partial class BaoCaoHDN
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
            this.grvBaoCaoHDB = new System.Windows.Forms.DataGridView();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBangChu = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbHienThiTT = new System.Windows.Forms.GroupBox();
            this.cbbMaNCC = new System.Windows.Forms.ComboBox();
            this.grbNhapTT = new System.Windows.Forms.GroupBox();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTimLai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbHDN = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoHDB)).BeginInit();
            this.panel2.SuspendLayout();
            this.grbHienThiTT.SuspendLayout();
            this.grbNhapTT.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvBaoCaoHDB
            // 
            this.grvBaoCaoHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvBaoCaoHDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvBaoCaoHDB.Location = new System.Drawing.Point(3, 18);
            this.grvBaoCaoHDB.Name = "grvBaoCaoHDB";
            this.grvBaoCaoHDB.Size = new System.Drawing.Size(623, 169);
            this.grvBaoCaoHDB.TabIndex = 0;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(493, 197);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(113, 20);
            this.txtTongTien.TabIndex = 18;
         
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(414, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tổng Tiền:";
         
            // 
            // lbBangChu
            // 
            this.lbBangChu.AutoSize = true;
            this.lbBangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBangChu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbBangChu.Location = new System.Drawing.Point(35, 201);
            this.lbBangChu.Name = "lbBangChu";
            this.lbBangChu.Size = new System.Drawing.Size(69, 16);
            this.lbBangChu.TabIndex = 19;
            this.lbBangChu.Text = "Bằng Chữ:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbBangChu);
            this.panel2.Controls.Add(this.txtTongTien);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.grbHienThiTT);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 227);
            this.panel2.TabIndex = 3;
            // 
            // grbHienThiTT
            // 
            this.grbHienThiTT.Controls.Add(this.grvBaoCaoHDB);
            this.grbHienThiTT.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbHienThiTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHienThiTT.Location = new System.Drawing.Point(0, 0);
            this.grbHienThiTT.Name = "grbHienThiTT";
            this.grbHienThiTT.Size = new System.Drawing.Size(629, 190);
            this.grbHienThiTT.TabIndex = 0;
            this.grbHienThiTT.TabStop = false;
            this.grbHienThiTT.Text = "Thông Tin Hiển Thị";
            // 
            // cbbMaNCC
            // 
            this.cbbMaNCC.FormattingEnabled = true;
            this.cbbMaNCC.Location = new System.Drawing.Point(213, 50);
            this.cbbMaNCC.Name = "cbbMaNCC";
            this.cbbMaNCC.Size = new System.Drawing.Size(122, 24);
            this.cbbMaNCC.TabIndex = 2;
            // 
            // grbNhapTT
            // 
            this.grbNhapTT.Controls.Add(this.btnBaoCao);
            this.grbNhapTT.Controls.Add(this.btnTimLai);
            this.grbNhapTT.Controls.Add(this.btnDong);
            this.grbNhapTT.Controls.Add(this.btnIn);
            this.grbNhapTT.Controls.Add(this.cbbMaNCC);
            this.grbNhapTT.Controls.Add(this.label1);
            this.grbNhapTT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbNhapTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNhapTT.Location = new System.Drawing.Point(0, 45);
            this.grbNhapTT.Name = "grbNhapTT";
            this.grbNhapTT.Size = new System.Drawing.Size(629, 173);
            this.grbNhapTT.TabIndex = 0;
            this.grbNhapTT.TabStop = false;
            this.grbNhapTT.Text = "Nhập Thông Tin";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Image = global::QuanLyTiVi.Properties.Resources.icon_Báo_cáo___OK;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(365, 50);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(92, 31);
            this.btnBaoCao.TabIndex = 23;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnTimLai
            // 
            this.btnTimLai.Image = global::QuanLyTiVi.Properties.Resources.btnTimKiem;
            this.btnTimLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimLai.Location = new System.Drawing.Point(114, 115);
            this.btnTimLai.Name = "btnTimLai";
            this.btnTimLai.Size = new System.Drawing.Size(93, 31);
            this.btnTimLai.TabIndex = 19;
            this.btnTimLai.Text = "Tìm Lại";
            this.btnTimLai.UseVisualStyleBackColor = true;
            this.btnTimLai.Click += new System.EventHandler(this.btnTimLai_Click);
            // 
            // btnDong
            // 
            this.btnDong.Image = global::QuanLyTiVi.Properties.Resources.icon_thoát;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(452, 115);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(81, 31);
            this.btnDong.TabIndex = 21;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDong.UseVisualStyleBackColor = true;
    
            // 
            // btnIn
            // 
            this.btnIn.Image = global::QuanLyTiVi.Properties.Resources.btnIn;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(283, 115);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(105, 31);
            this.btnIn.TabIndex = 20;
            this.btnIn.Text = "In Báo Cáo";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhà Cung Cấp";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbHDN);
            this.panel1.Controls.Add(this.grbNhapTT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 218);
            this.panel1.TabIndex = 2;
            // 
            // lbHDN
            // 
            this.lbHDN.AutoSize = true;
            this.lbHDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbHDN.Location = new System.Drawing.Point(206, 15);
            this.lbHDN.Name = "lbHDN";
            this.lbHDN.Size = new System.Drawing.Size(248, 24);
            this.lbHDN.TabIndex = 1;
            this.lbHDN.Text = "BÁO CÁO HÓA ĐƠN NHẬP";
            // 
            // BaoCaoHDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 445);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BaoCaoHDN";
            this.Text = "Báo Cáo HDN";
            this.Load += new System.EventHandler(this.BaoCaoHDN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoHDB)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbHienThiTT.ResumeLayout(false);
            this.grbNhapTT.ResumeLayout(false);
            this.grbNhapTT.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvBaoCaoHDB;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnTimLai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label lbBangChu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grbHienThiTT;
        private System.Windows.Forms.ComboBox cbbMaNCC;
        private System.Windows.Forms.GroupBox grbNhapTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbHDN;
    }
}