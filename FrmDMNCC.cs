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
    public partial class FrmDMNCC : Form
    {
        public FrmDMNCC()
        {
            InitializeComponent();
        }

        private void loadDataToGridView()
        {
            string sql = "select * from NhaCungCap";
            DataTable tableTV = functions.GetDataToTable(sql);
            dataGridView_NCC.DataSource = tableTV;
            dataGridView_NCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void ResetValues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            maskSĐT.Text = "";
        }

        private void FrmDMNCC_Load(object sender, EventArgs e)
        {
            functions.Connect();
            txtMaNCC.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            loadDataToGridView();
        }

        private void dataGridView_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            txtMaNCC.Text = dataGridView_NCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dataGridView_NCC.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView_NCC.CurrentRow.Cells[2].Value.ToString();
            maskSĐT.Text = dataGridView_NCC.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void TBNhapDayDu()
        {
            if (txtMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Nhà Cung Cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Nhà Cung Cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaNCC.Enabled = false;
            txtTenNCC.Focus();
            ResetValues();
            loadDataToGridView();

            txtMaNCC.Text = functions.tangkey("select top(1) convert(integer ,substring(MaNCC,4,3)+1) as soma from  NhaCungCap order by soma desc", "ncc");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            TBNhapDayDu();
            sql = "SELECT MaNCC FROM NhaCungCap WHERE MaNCC='" + txtMaNCC.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã NCC này đã tồn tại, bạn phải chọn mã NCC khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            sql = "INSERT INTO NhaCungCap(MaNCC,TenNCC,DiaChi, DienThoai) VALUES('" + txtMaNCC.Text.Trim() + "'," +
                "N'" + txtTenNCC.Text.Trim() + "',N'" + txtDiaChi.Text + "','" + maskSĐT.Text + "')";
            functions.RunSQL(sql);
            loadDataToGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TBNhapDayDu();
            string sql = "update NhaCungCap set TenNCC=N'" + txtTenNCC.Text.Trim() + "',DiaChi=N'" + txtDiaChi.Text + "',DienThoai='" + maskSĐT.Text + "' WHERE MaNCC='" + txtMaNCC.Text + "'";
            MessageBox.Show(sql); ;
            functions.RunSQL(sql);
            loadDataToGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NhaCungCap WHERE MaNCC='" + txtMaNCC.Text + "'";
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
            txtMaNCC.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
