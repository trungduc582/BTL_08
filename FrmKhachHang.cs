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
    public partial class FrmDMKH : Form
    {
        public FrmDMKH()
        {
            InitializeComponent();
        }
        private void loadDataToGridView()
        {
            string sql = "select * from KhachHang";
            DataTable tableTV = functions.GetDataToTable(sql);
            dataGridView_KH.DataSource = tableTV;
            dataGridView_KH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            maskSĐT.Text = "";
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaKH.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            loadDataToGridView();
        }

        private void dataGridView_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            txtMaKH.Text = dataGridView_KH.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dataGridView_KH.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView_KH.CurrentRow.Cells[2].Value.ToString();
            maskSĐT.Text = dataGridView_KH.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void TBNhapDayDu()
        {
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Khách Hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ Nhà Cung Cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (maskSĐT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập SĐT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskSĐT.Focus();
                return;
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT MaKhach FROM KhachHang WHERE MaKhach='" + txtMaKH.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã Khách Hàng này đã tồn tại, bạn phải chọn mã Khách Hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            sql = "INSERT INTO KhachHang(MaKhach,TenKhach,DiaChi, DienThoai) VALUES('" + txtMaKH.Text.Trim() + "'," +
                "N'" + txtTenKH.Text.Trim() + "',N'" + txtDiaChi.Text + "','" + maskSĐT.Text + "')";
            functions.RunSQL(sql);
            loadDataToGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKH.Enabled = false;
        }

     
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaKH.Enabled = false;
            txtTenKH.Focus();
            ResetValues();
            loadDataToGridView();

            txtMaKH.Text = functions.tangkey("select top(1) convert(integer ,substring(MaKhach,3,3)+1) as soma from  KhachHang order by soma desc", "kh");
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            TBNhapDayDu();
            string sql = "update KhachHang set TenKhach=N'" + txtTenKH.Text.Trim() + "',DiaChi=N'" + txtDiaChi.Text + "',DienThoai='" + maskSĐT.Text + "' WHERE MaKhach='" + txtMaKH.Text + "'";
            MessageBox.Show(sql); ;
            functions.RunSQL(sql);
            loadDataToGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhachHang WHERE MaKhach='" + txtMaKH.Text + "'";
                functions.RunSqlDel(sql);
                loadDataToGridView();
                ResetValues();
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKH.Enabled = false;
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
