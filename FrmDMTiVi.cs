using QuanLyTiVi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiVi
{
    public partial class FrmDMTiVi : Form
    {
        public FrmDMTiVi()
        {
            InitializeComponent();
        }

        private void FrmDMTiVi_Load(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaTiVi.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

            functions.FillCombo("SELECT MaHangSanXuat FROM HangSanXuat", cbbMaHangSX, "MaHangSanXuat", "MaHangSanXuat");
            functions.FillCombo("SELECT MaKieu FROM KieuDang", cbbMaKieu, "MaKieu", "MaKieu");
            functions.FillCombo("SELECT MaMau FROM MauSac", cbbMaMau, "MaMau", "MaMau");
            functions.FillCombo("SELECT MaManHinh FROM ManHinh", cbbMaManHinh, "MaManHinh", "MaManHinh");
            functions.FillCombo("SELECT MaCo FROM CoManHinh", cbbMaCo, "MaCo", "MaCo");
            functions.FillCombo("SELECT MaNuocSX FROM NuocSanXuat", cbbMaNuocSX, "MaNuocSX", "MaNuocSX");
            loadDataToGridView();
            ResetValues();
        }
        private void loadDataToGridView()
        {
            string sql = "select MaTV, TenTV, MaHangSanXuat, MaKieu, MaMau, MaManHinh, MaCo, MaNuocSX, SoLuong, DonGiaNhap, DonGiaBan, ThoiGianBanHanh from DMTV";
            DataTable tableTV = functions.GetDataToTable(sql);
            dataGridView_TiVi.DataSource = tableTV;
            dataGridView_TiVi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void ResetValues()
        {
            txtMaTiVi.Text = "";
            txtTenTiVi.Text = "";
            cbbMaHangSX.Text = "";
            cbbMaKieu.Text = "";
            cbbMaMau.Text = "";
            cbbMaManHinh.Text = "";
            cbbMaCo.Text = "";
            cbbMaNuocSX.Text = "";
            txtSoLuong.Text = "";
            txtDGNhap.Text = "";
            txtDGBan.Text = "";
            txtTGBaoHanh.Text = "";
        }

        private void dataGridView_TiVi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTiVi.Focus();
                return;
            }
            txtMaTiVi.Text = dataGridView_TiVi.CurrentRow.Cells[0].Value.ToString();
            txtTenTiVi.Text = dataGridView_TiVi.CurrentRow.Cells[1].Value.ToString();
            cbbMaHangSX.Text = dataGridView_TiVi.CurrentRow.Cells[2].Value.ToString();
            cbbMaKieu.Text = dataGridView_TiVi.CurrentRow.Cells[3].Value.ToString();
            cbbMaMau.Text = dataGridView_TiVi.CurrentRow.Cells[4].Value.ToString();
            cbbMaManHinh.Text = dataGridView_TiVi.CurrentRow.Cells[5].Value.ToString();
            cbbMaCo.Text = dataGridView_TiVi.CurrentRow.Cells[6].Value.ToString();
            cbbMaNuocSX.Text = dataGridView_TiVi.CurrentRow.Cells[7].Value.ToString();
            txtSoLuong.Text = dataGridView_TiVi.CurrentRow.Cells[8].Value.ToString();
            txtDGNhap.Text = dataGridView_TiVi.CurrentRow.Cells[9].Value.ToString();
            txtDGBan.Text = dataGridView_TiVi.CurrentRow.Cells[10].Value.ToString();
            txtTGBaoHanh.Text = dataGridView_TiVi.CurrentRow.Cells[11].Value.ToString();
            //  txtAnh.Text = dataGridView_TiVi.CurrentRow.Cells["MaODia"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void TBNhapDayDu()
        {
            if (txtMaTiVi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã TiVi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTiVi.Focus();
                return;
            }
            if (txtTenTiVi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên TiVi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTiVi.Focus();
                return;
            }
            if (cbbMaHangSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hãng SX", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaHangSX.Focus();
                return;
            }
            if (cbbMaKieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã kiểu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaKieu.Focus();
                return;
            }
            if (cbbMaMau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaMau.Focus();
                return;
            }
            if (cbbMaManHinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaManHinh.Focus();
                return;
            }
            if (cbbMaCo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã cỡ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaCo.Focus();
                return;
            }
            if (cbbMaNuocSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nước SX", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaNuocSX.Focus();
                return;
            }
        }
        
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;

            txtMaTiVi.Enabled = false;
            txtTenTiVi.Focus();
            ResetValues();
            loadDataToGridView();
            txtMaTiVi.Text = functions.tangkey(" select top(1) convert(integer, substring(MaTV, 5, 3) + 1) as soma from DMTV order by soma desc", "dmtv");
        }

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            TBNhapDayDu();
            string a = txtDGNhap.Text;
            Double b = Convert.ToDouble(a);
            string c = txtDGBan.Text;
            Double d = Convert.ToDouble(c);
            string sql = "UPDATE DMTV SET  TenTV=N'" + txtTenTiVi.Text.Trim() + "',MaHangSanXuat='" + cbbMaHangSX.Text + "',MaKieu='" + cbbMaKieu.Text + "'," +
                "MaMau='" + cbbMaMau.Text + "',MaManHinh='" + cbbMaManHinh.Text + "',MaCo='" + cbbMaCo.Text + "',MaNuocSX='" + cbbMaNuocSX.Text + "',SoLuong='" + txtSoLuong.Text + "',DonGiaNhap= CONVERT(float,'"+txtDGNhap.Text+ "'),DonGiaBan= CONVERT(float,'" + txtDGBan.Text + "'),ThoiGianBanHanh =N'" + txtTGBaoHanh.Text + "'WHERE MaTV='" + txtMaTiVi.Text + "'";
            MessageBox.Show(sql);
            functions.RunSQL(sql);

            loadDataToGridView();
            
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaTiVi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE DMTV WHERE MaTV='" + txtMaTiVi.Text + "'";
                functions.RunSqlDel(sql);
                loadDataToGridView();
                ResetValues();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaTiVi.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            TBNhapDayDu();

            sql = "SELECT MaTV  FROM DMTV WHERE MaTV=N'" + txtMaTiVi.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã TV này đã tồn tại, bạn phải chọn mã máy khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTiVi.Focus();
                return;
            }
            //MaTV, TenTV, MaHangSanXuat, MaKieu, MaMau, MaManHinh, MaCo, MaNuocSX, SoLuong, DonGiaNhap, DonGiaBan, ThoiGianBanHanh from DMTV";
            sql = "INSERT INTO DMTV(MaTV, TenTV, MaHangSanXuat, MaKieu, MaMau, MaManHinh, MaCo, MaNuocSX, SoLuong, DonGiaNhap, DonGiaBan, ThoiGianBanHanh)" +
                " VALUES('" + txtMaTiVi.Text.Trim() + "','" + txtTenTiVi.Text.Trim() + "','" + cbbMaHangSX.SelectedValue.ToString() + "','" + cbbMaKieu.SelectedValue.ToString() + "'," +
                "'" + cbbMaMau.SelectedValue.ToString() + "','" + cbbMaManHinh.SelectedValue.ToString() + "'," +
                "'" + cbbMaCo.SelectedValue.ToString() + "','" + cbbMaNuocSX.SelectedValue.ToString() + "','" + txtSoLuong.Text.Trim() + "'," +
                "'" + txtDGNhap.Text.Trim() + "','" + txtDGBan.Text.Trim() + "','" + txtTGBaoHanh.Text.Trim() + "')";
            MessageBox.Show(sql);
            functions.RunSQL(sql);

            

            loadDataToGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaTiVi.Enabled = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog open = new OpenFileDialog();
        //    if(open.ShowDialog() == DialogResult.OK)
        //    {
        //        pictureBox1.Image = Image.FromFile(open.FileName);
        //        this.Text = open.FileName;
        //    }
        //}

        private void txtDGNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtDGNhap.Text == "")
                txtDGBan.Text = "";
            else 
            {
                double x = Convert.ToDouble(txtDGNhap.Text) * 1.1;
                txtDGBan.Text = x.ToString(); 
            }
        }
    }
}
