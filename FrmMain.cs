using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyTiVi
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void mnuTiVi_Click(object sender, EventArgs e)
        {
            FrmDMTiVi f = new FrmDMTiVi();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            FrmDMNV f = new FrmDMNV();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            FrmDMNCC f = new FrmDMNCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            FrmDMKH f = new FrmDMKH();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTK_TiVi_Click(object sender, EventArgs e)
        {
            FrmTKTiVi f = new FrmTKTiVi();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTK_HĐ_Click(object sender, EventArgs e)
        {
            FrmTK_HDN f = new FrmTK_HDN();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTop3_Click(object sender, EventArgs e)
        {
            FrmTop3Selling f = new FrmTop3Selling();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTop5NCC_Click(object sender, EventArgs e)
        {
            FrmTop5NCC f = new FrmTop5NCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHoaDonNhap f = new FrmHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHoaDonBan f = new FrmHoaDonBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCHD_NCC_Click(object sender, EventArgs e)
        {
            BaoCaoHDN f = new BaoCaoHDN();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuBCHD_Quy_Click(object sender, EventArgs e)
        {
            FrmBaoCaoHDB f = new FrmBaoCaoHDB();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
