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
    public partial class FrmDMNV : Form
    {
        public FrmDMNV()
        {
            InitializeComponent();
        }

        private void loadDataToGridView()
        {
            string sql = "select * from NhanVien";
            DataTable tableTV = functions.GetDataToTable(sql);
            dataGridView_NV.DataSource = tableTV;
            dataGridView_NV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            cbbGioiTinh.Text = "";
            cbbMaCa.Text = "";
            cbbMaCV.Text = "";
            maskNgaySinh.Text = "";
            maskSĐT.Text = "";
        }
        private void FrmDMNV_Load(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaNV.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

            functions.FillCombo("SELECT MaCa FROM CaLam", cbbMaCa, "MaCa", "MaCa");
            functions.FillCombo("SELECT MaCV FROM CongViec", cbbMaCV, "MaCV", "MaCV");
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
            cbbGioiTinh.SelectedIndex = -1;
            loadDataToGridView();
        }

        private void dataGridView_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            txtMaNV.Text = dataGridView_NV.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dataGridView_NV.CurrentRow.Cells[1].Value.ToString();
            cbbGioiTinh.Text = dataGridView_NV.CurrentRow.Cells[2].Value.ToString();
            maskNgaySinh.Text = dataGridView_NV.CurrentRow.Cells[3].Value.ToString();
            maskSĐT.Text = dataGridView_NV.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView_NV.CurrentRow.Cells[5].Value.ToString();
            cbbMaCa.Text = dataGridView_NV.CurrentRow.Cells[6].Value.ToString();
            cbbMaCV.Text = dataGridView_NV.CurrentRow.Cells[7].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void TBNhapDayDu()
        {
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (cbbGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giới tính Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbGioiTinh.Focus();
                return;
            }
            if (maskSĐT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập SĐT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskSĐT.Focus();
                return;
            }
            if (cbbMaCa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ca", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaCa.Focus();
                return;
            }
            if (cbbMaCV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaCV.Focus();
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
            txtMaNV.Enabled = false;
            txtTenNV.Focus();
            ResetValues();
            loadDataToGridView();

            txtMaNV.Text = functions.tangkey("select top(1) convert(integer ,substring(MaNV,3,3)+1) as soma from  NhanVien order by soma desc", "nv");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
                string sql;
                TBNhapDayDu();
                sql = "SELECT MaNV FROM NhanVien WHERE MaNV='" + txtMaNV.Text.Trim() + "'";
                if (functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã NV này đã tồn tại, bạn phải chọn mã NV khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Focus();
                    return;
                }
                sql = "INSERT INTO NhanVien(MaNV,TenNhanVien,GioiTinh, NgaySinh,DienThoai, DiaChi,MaCa,MaCV) VALUES('" + txtMaNV.Text.Trim() + "'," +
                    "N'" + txtTenNV.Text.Trim() + "',N'" + cbbGioiTinh.Text + "','" + functions.ConvertDateTime(maskNgaySinh.Text) + "'," +
                    "'" + maskSĐT.Text + "',N'" + txtDiaChi.Text + "','" + cbbMaCa.Text + "','" + cbbMaCV.Text + "')";
                functions.RunSQL(sql);
                loadDataToGridView();
                ResetValues();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                txtMaNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
                TBNhapDayDu();
                string sql = "update NhanVien set TenNhanVien=N'"+txtTenNV.Text.Trim()+"',GioiTinh=N'"+cbbGioiTinh.Text+ "',NgaySinh = '" + functions.ConvertDateTime(maskNgaySinh.Text) + "',DienThoai='" + maskSĐT.Text + "',DiaChi=N'" + txtDiaChi.Text + "',MaCa='" + cbbMaCa.Text + "',MaCV='" + cbbMaCV.Text + "' WHERE MaNV='" + txtMaNV.Text + "'";//,NgaySinh = '" + functions.ConvertDateTime(maskNgaySinh.Text) + "'
                MessageBox.Show(sql);
                functions.RunSQL(sql);
                loadDataToGridView();
                ResetValues();
                btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NhanVien WHERE MaNV=N'" + txtMaNV.Text + "'";
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
            txtMaNV.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
