namespace QuanLyTiVi
{
    partial class FrmBaoCaoHDB
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
            this.lbHDB = new System.Windows.Forms.Label();
            this.grbNhapTT = new System.Windows.Forms.GroupBox();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTimLai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.cbbQuy = new System.Windows.Forms.ComboBox();
            this.cbbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbBangChu = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grbHienThiTT = new System.Windows.Forms.GroupBox();
            this.grvBaoCaoHDB = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.grbNhapTT.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbHienThiTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbHDB);
            this.panel1.Controls.Add(this.grbNhapTT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 218);
            this.panel1.TabIndex = 0;
            // 
            // lbHDB
            // 
            this.lbHDB.AutoSize = true;
            this.lbHDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbHDB.Location = new System.Drawing.Point(207, 18);
            this.lbHDB.Name = "lbHDB";
            this.lbHDB.Size = new System.Drawing.Size(234, 24);
            this.lbHDB.TabIndex = 1;
            this.lbHDB.Text = "BÁO CÁO HÓA ĐƠN BÁN";
            // 
            // grbNhapTT
            // 
            this.grbNhapTT.Controls.Add(this.btnBaoCao);
            this.grbNhapTT.Controls.Add(this.btnTimLai);
            this.grbNhapTT.Controls.Add(this.btnDong);
            this.grbNhapTT.Controls.Add(this.btnIn);
            this.grbNhapTT.Controls.Add(this.cbbQuy);
            this.grbNhapTT.Controls.Add(this.cbbNam);
            this.grbNhapTT.Controls.Add(this.label2);
            this.grbNhapTT.Controls.Add(this.label1);
            this.grbNhapTT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbNhapTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbNhapTT.Location = new System.Drawing.Point(0, 45);
            this.grbNhapTT.Name = "grbNhapTT";
            this.grbNhapTT.Size = new System.Drawing.Size(620, 173);
            this.grbNhapTT.TabIndex = 0;
            this.grbNhapTT.TabStop = false;
            this.grbNhapTT.Text = "Nhập Thông Tin";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Image = global::QuanLyTiVi.Properties.Resources.icon_Báo_cáo___OK;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(447, 50);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(93, 29);
            this.btnBaoCao.TabIndex = 23;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click_1);
            // 
            // btnTimLai
            // 
            this.btnTimLai.Image = global::QuanLyTiVi.Properties.Resources.btnTimKiem;
            this.btnTimLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimLai.Location = new System.Drawing.Point(109, 115);
            this.btnTimLai.Name = "btnTimLai";
            this.btnTimLai.Size = new System.Drawing.Size(93, 29);
            this.btnTimLai.TabIndex = 19;
            this.btnTimLai.Text = "Tìm Lại";
            this.btnTimLai.UseVisualStyleBackColor = true;
            this.btnTimLai.Click += new System.EventHandler(this.btnTimLai_Click);
            // 
            // btnDong
            // 
            this.btnDong.Image = global::QuanLyTiVi.Properties.Resources.icon_thoát;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(457, 115);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(81, 29);
            this.btnDong.TabIndex = 21;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            this.btnIn.Image = global::QuanLyTiVi.Properties.Resources.btnIn;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(278, 115);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(105, 29);
            this.btnIn.TabIndex = 20;
            this.btnIn.Text = "In Báo Cáo";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // cbbQuy
            // 
            this.cbbQuy.FormattingEnabled = true;
            this.cbbQuy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbQuy.Location = new System.Drawing.Point(292, 50);
            this.cbbQuy.Name = "cbbQuy";
            this.cbbQuy.Size = new System.Drawing.Size(91, 24);
            this.cbbQuy.TabIndex = 3;
            // 
            // cbbNam
            // 
            this.cbbNam.FormattingEnabled = true;
            this.cbbNam.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbbNam.Location = new System.Drawing.Point(111, 50);
            this.cbbNam.Name = "cbbNam";
            this.cbbNam.Size = new System.Drawing.Size(91, 24);
            this.cbbNam.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quý";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm";
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
            this.panel2.Size = new System.Drawing.Size(620, 224);
            this.panel2.TabIndex = 1;
            // 
            // lbBangChu
            // 
            this.lbBangChu.AutoSize = true;
            this.lbBangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBangChu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbBangChu.Location = new System.Drawing.Point(32, 202);
            this.lbBangChu.Name = "lbBangChu";
            this.lbBangChu.Size = new System.Drawing.Size(64, 15);
            this.lbBangChu.TabIndex = 19;
            this.lbBangChu.Text = "Bằng Chữ:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(495, 196);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(113, 20);
            this.txtTongTien.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(416, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tổng Tiền:";
            // 
            // grbHienThiTT
            // 
            this.grbHienThiTT.Controls.Add(this.grvBaoCaoHDB);
            this.grbHienThiTT.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbHienThiTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHienThiTT.Location = new System.Drawing.Point(0, 0);
            this.grbHienThiTT.Name = "grbHienThiTT";
            this.grbHienThiTT.Size = new System.Drawing.Size(620, 190);
            this.grbHienThiTT.TabIndex = 0;
            this.grbHienThiTT.TabStop = false;
            this.grbHienThiTT.Text = "Thông Tin Hiển Thị";
            // 
            // grvBaoCaoHDB
            // 
            this.grvBaoCaoHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvBaoCaoHDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvBaoCaoHDB.Location = new System.Drawing.Point(3, 18);
            this.grvBaoCaoHDB.Name = "grvBaoCaoHDB";
            this.grvBaoCaoHDB.Size = new System.Drawing.Size(614, 169);
            this.grvBaoCaoHDB.TabIndex = 0;
            // 
            // FrmBaoCaoHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 442);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBaoCaoHDB";
            this.Text = "FrmBaoCaoHDB";
            this.Load += new System.EventHandler(this.FrmBaoCaoHDB_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbNhapTT.ResumeLayout(false);
            this.grbNhapTT.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbHienThiTT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvBaoCaoHDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbNhapTT;
        private System.Windows.Forms.Label lbHDB;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnTimLai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ComboBox cbbQuy;
        private System.Windows.Forms.ComboBox cbbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbBangChu;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbHienThiTT;
        private System.Windows.Forms.DataGridView grvBaoCaoHDB;
    }
}