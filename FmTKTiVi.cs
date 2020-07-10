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
    
    public partial class FrmTKTiVi : Form
    {   DataTable tableTKTV;
        public FrmTKTiVi()
        {
            InitializeComponent();
        }
        private void loadDataToGridView()
        {
            string sql = "select MaTV, TenTV, TenHangSanXuat, TenManHinh, KichCo FROM HangSanXuat a join DMTV b on a.MaHangSanXuat = b.MaHangSanXuat join ManHinh c on b.MaManHinh = c.MaManHinh join CoManHinh d on d.MaCo = b.MaCo WHERE 1=1";
            tableTKTV = functions.GetDataToTable(sql);
            dataGridView_TKTV.DataSource = tableTKTV;
            dataGridView_TKTV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        private void FmTKTiVi_Load(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaTV.ReadOnly = true;
            txtTenTV.ReadOnly = true;
            txtHangSX.ReadOnly = true;
            txtManHinh.ReadOnly = true;
            txtKichCo.ReadOnly = true;
            functions.FillCombo("SELECT DISTINCT TenHangSanXuat FROM HangSanXuat", cbbHangSX, "TenHangSanXuat", "TenHangSanXuat");
            cbbHangSX.SelectedIndex = -1;
            functions.FillCombo("SELECT DISTINCT KichCo FROM CoManHinh", cbbKichCo, "KichCo", "KichCo");
            cbbKichCo.SelectedIndex = -1;
            functions.FillCombo("SELECT DISTINCT TenManHinh FROM ManHinh", cbbManHinh, "TenManHinh", "TenManHinh");
            cbbManHinh.SelectedIndex = -1;
            loadDataToGridView();
            dataGridView_TKTV.DataSource = null;

            string sql;
            sql = "SELECT MaTV, TenTV, TenHangSanXuat, TenManHinh, KichCo FROM HangSanXuat a join DMTV b on a.MaHangSanXuat = b.MaHangSanXuat join ManHinh c on b.MaManHinh = c.MaManHinh join CoManHinh d on d.MaCo = b.MaCo";
            DataTable tblMT = functions.GetDataToTable(sql);
            dataGridView_TKTV.DataSource = tblMT;
        }

        private void dataGridView_TKTV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTV.Text = dataGridView_TKTV.CurrentRow.Cells[0].Value.ToString();
            txtTenTV.Text = dataGridView_TKTV.CurrentRow.Cells[1].Value.ToString();
            txtHangSX.Text = dataGridView_TKTV.CurrentRow.Cells[2].Value.ToString();
            txtManHinh.Text = dataGridView_TKTV.CurrentRow.Cells[3].Value.ToString();
            txtKichCo.Text = dataGridView_TKTV.CurrentRow.Cells[4].Value.ToString();
        }

        private void ResetValues()
        {
            cbbHangSX.SelectedIndex = -1;
            cbbKichCo.SelectedIndex = -1;
            cbbManHinh.SelectedIndex = -1;
            cbbHangSX.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cbbHangSX.Text == "") && (cbbManHinh.Text == "") && (cbbKichCo.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT MaTV, TenTV, TenHangSanXuat, TenManHinh, KichCo FROM HangSanXuat a join DMTV b on a.MaHangSanXuat = b.MaHangSanXuat join ManHinh c on b.MaManHinh = c.MaManHinh join CoManHinh d on d.MaCo = b.MaCo WHERE 1=1"; 
            if (cbbHangSX.Text != "")
                sql = sql + " AND TenHangSanXuat = '" + cbbHangSX.Text + "' ";
            if (cbbManHinh.Text != "")
                sql = sql + " AND TenManHinh = '" + cbbManHinh.Text + "'";
            if (cbbKichCo.Text != "")
                sql = sql + " AND KichCo = '" + cbbKichCo.Text + "'";
            DataTable tblTV = functions.GetDataToTable(sql);
            if (tblTV.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblTV.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tableTKTV = functions.GetDataToTable(sql);
            dataGridView_TKTV.DataSource = tableTKTV;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            string sql;
            sql = "SELECT MaTV, TenTV, TenHangSanXuat, TenManHinh, KichCo FROM HangSanXuat a join DMTV b on a.MaHangSanXuat = b.MaHangSanXuat join ManHinh c on b.MaManHinh = c.MaManHinh join CoManHinh d on d.MaCo = b.MaCo";
            DataTable tblMT = functions.GetDataToTable(sql);
            dataGridView_TKTV.DataSource = tblMT;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
