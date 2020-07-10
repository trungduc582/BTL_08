using QuanLyTiVi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiVi
{
    public partial class FrmTK_HDN : Form
    {
        DataTable tableTK_HDN;
        public FrmTK_HDN()
        {
            InitializeComponent();
        }

        private void loadDataToGridView()
        {
            string sql = "select HoaDonNhap.SoHDN, DMTV.MaTV, TenTV, NgayNhap, ChiTietHDN.SoLuong, MaNCC, MaNV, ThanhTien from ChiTietHDN inner join HoaDonNhap on ChiTietHDN.SoHDN = HoaDonNhap.SoHDN inner join DMTV on DMTV.MaTV = ChiTietHDN.MaTV";
            tableTK_HDN = functions.GetDataToTable(sql);
            dataGridView_TKHĐN.DataSource = tableTK_HDN;
            dataGridView_TKHĐN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        private void FrmTK_HDN_Load(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaHDN.ReadOnly = true;
            txtMaTV.ReadOnly = true;
            txtTenTV.ReadOnly = true;
            txtNgayNhap.ReadOnly = true;
            txtSoLuong.ReadOnly = true;
            txtMaNV.ReadOnly = true;
            txtMaNCC.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            functions.FillCombo("SELECT DISTINCT MaTV FROM DMTV", cbbMaTV, "MaTV", "MaTV");
            cbbMaTV.SelectedIndex = -1;

            loadDataToGridView();
            //dataGridView_TKHĐN.DataSource = null;
        }

        private void dataGridView_TKHĐN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHDN.Text = dataGridView_TKHĐN.CurrentRow.Cells[0].Value.ToString();
            txtMaTV.Text = dataGridView_TKHĐN.CurrentRow.Cells[1].Value.ToString();
            txtTenTV.Text = dataGridView_TKHĐN.CurrentRow.Cells[2].Value.ToString();
            txtNgayNhap.Text = dataGridView_TKHĐN.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = dataGridView_TKHĐN.CurrentRow.Cells[4].Value.ToString();
            txtMaNV.Text = dataGridView_TKHĐN.CurrentRow.Cells[5].Value.ToString();
            txtMaNCC.Text = dataGridView_TKHĐN.CurrentRow.Cells[6].Value.ToString();
            txtThanhTien.Text = dataGridView_TKHĐN.CurrentRow.Cells[7].Value.ToString();
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            cbbMaTV.SelectedIndex = -1;
            cbbMaTV.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cbbMaTV.Text == "") && (txtSoLuongNhap.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select HoaDonNhap.SoHDN, DMTV.MaTV, TenTV, NgayNhap, ChiTietHDN.SoLuong, MaNCC, MaNV, ThanhTien from ChiTietHDN inner join HoaDonNhap on ChiTietHDN.SoHDN = HoaDonNhap.SoHDN inner join DMTV on DMTV.MaTV = ChiTietHDN.MaTV WHERE 1=1";
            if (cbbMaTV.Text != "")
                sql = sql + " AND DMTV.MaTV = '" + cbbMaTV.Text + "' ";
            if (txtSoLuongNhap.Text != "")
                sql = sql + " AND ChiTietHDN.SoLuong = '" + txtSoLuongNhap.Text + "'";
            DataTable tblTV = functions.GetDataToTable(sql);
            if (tblTV.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblTV.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tableTK_HDN = functions.GetDataToTable(sql);
            dataGridView_TKHĐN.DataSource = tableTK_HDN;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            cbbMaTV.SelectedIndex = -1;
            txtSoLuongNhap.Text = "";
            loadDataToGridView();
            //dataGridView_TKHĐN.DataSource = null;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
