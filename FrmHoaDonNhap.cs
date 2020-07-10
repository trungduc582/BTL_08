using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyTiVi.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyTiVi
{
    public partial class FrmHoaDonNhap : Form
    {
        DataTable tblCTHDN;
        public FrmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void FrmHoaDonNhap_Load(object sender, EventArgs e)
        {
            functions.Connect();
            dtpNgayNhap.Enabled = false;
            btnThemChiTiet.Enabled = false;
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHDN.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            cbbMaNV.Enabled = false;
            cbbMaNCC.Enabled = false;
            cbbMaTiVi.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtGiamGia.Enabled = false;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            functions.FillCombo("SELECT MaNCC FROM NhaCungCap", cbbMaNCC, "MaNCC", "MaNCC");
            cbbMaNCC.SelectedIndex = -1;
            functions.FillCombo("SELECT MaNV FROM NhanVien", cbbMaNV, "MaNV", "MaNV");
            cbbMaNV.SelectedIndex = -1;
            functions.FillCombo("SELECT MaTV FROM DMTV", cbbMaTiVi, "MaTV", "MaTV");
            cbbMaTiVi.SelectedIndex = -1;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "select a.MaTV, a.SoLuong, a.DonGia, a.GiamGia,a.ThanhTien from ChiTietHDN a WHERE a.SoHDN ='" + txtMaHDN.Text.Trim() + "'";
            tblCTHDN = functions.GetDataToTable(sql);
            grvHDN.DataSource = tblCTHDN;
            grvHDN.Columns[0].HeaderText = "Mã TiVi";
            grvHDN.Columns[1].HeaderText = "Số Lượng";
            grvHDN.Columns[2].HeaderText = "Đơn Giá";
            grvHDN.Columns[3].HeaderText = "Giảm giá";
            grvHDN.Columns[4].HeaderText = "Thành tiền";
            grvHDN.Columns[0].Width = 100;
            grvHDN.Columns[1].Width = 100;
            grvHDN.Columns[2].Width = 100;
            grvHDN.Columns[3].Width = 100;
            grvHDN.Columns[4].Width = 100;
            grvHDN.AllowUserToAddRows = false;
            grvHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayNhap FROM HoaDonNhap WHERE SoHDN = N'" + txtMaHDN.Text.Trim() + "'";
            dtpNgayNhap.Text = functions.ConvertDateTime(functions.GetFieldValues(str));
            str = "SELECT MaNV FROM HoaDonNhap WHERE SoHDN = N'" + txtMaHDN.Text.Trim() + "'";
            cbbMaNV.Text = functions.GetFieldValues(str);
            str = "SELECT MaNCC FROM HoaDonNhap WHERE SoHDN = N'" + txtMaHDN.Text.Trim() + "'";
            cbbMaNCC.Text = functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDonNhap WHERE SoHDN = N'" + txtMaHDN.Text.Trim() + "'";
            txtTongTien.Text = functions.GetFieldValues(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnDong.Enabled = true;
            btnThem.Enabled = false;
            cbbMaTiVi.Enabled = true;
            cbbMaNV.Enabled = true;
            cbbMaNCC.Enabled = true;
            txtMaHDN.ReadOnly = true;
            dtpNgayNhap.Enabled = true;
            cbbMaTiVi.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiamGia.Enabled = true;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            btnThemChiTiet.Enabled = false;
            btnThemDMTV.Enabled = true;
            ResetValues();
            cbbHDN.SelectedValue = -1;
            grvHDN.DataSource = null;
            txtMaHDN.Text = functions.CreateKey("HDN_");
        }
        private void ResetValues()
        {
            txtMaHDN.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            cbbMaNV.Text = "";
            cbbMaNCC.Text = "";
            txtTongTien.Text = "0";
            cbbMaTiVi.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "0";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            cbbMaNCC.Enabled = false;
            dtpNgayNhap.Enabled = false;
            txtMaHDN.ReadOnly = true;
            cbbMaTiVi.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtSoLuong.Enabled = false;
            txtGiamGia.Enabled = false;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            cbbMaNV.Enabled = false;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            btnThemChiTiet.Enabled = true;
            if(cbbHDN.Text != "")
            {
                txtMaHDN.Text = cbbHDN.Text;
                LoadInfoHoaDon();
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double Sl=0, SLcon, tong, Tongmoi;
            sql = "SELECT SoHDN FROM HoaDonNhap WHERE SoHDN=N'" + txtMaHDN.Text.Trim() + "'";
            if (!functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                if (cbbMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbMaNV.Focus();
                    return;
                }
                if (cbbMaNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbMaNCC.Focus();
                    return;
                }
                sql = "INSERT INTO HoaDonNhap(SoHDN, MaNV, MaNCC,NgayNhap, TongTien) VALUES (N'" + txtMaHDN.Text.Trim() + "','" +
                        cbbMaNV.SelectedValue + "',N'" + cbbMaNCC.SelectedValue + "','" + dtpNgayNhap.Value + "'," + txtTongTien.Text.Trim() + ")";
                //MessageBox.Show(sql);
                functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cbbMaTiVi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã TiVi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaTiVi.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            // kiểm tra MaTV đã tồn tại trong chi tiết hóa đơn nhập chưa
            sql = "SELECT MaTV FROM ChiTietHDN WHERE MaTV=N'" + cbbMaTiVi.SelectedValue + "' AND SoHDN = N'" + txtMaHDN.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaTiVi.SelectedValue = "";
                cbbMaTiVi.Focus();
                return;
            }
            
            //thực hiện insert
            sql = "INSERT INTO ChiTietHDN(SoHDN,MaTV,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtMaHDN.Text.Trim() + "',N'" + cbbMaTiVi.SelectedValue + "'," +
                    txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text.Trim() + "," + txtGiamGia.Text.Trim() + "," + txtThanhTien.Text + ")";
            functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng DMTV
            Sl = Convert.ToDouble(functions.GetFieldValues("SELECT SoLuong FROM DMTV WHERE MaTV = N'" + cbbMaTiVi.SelectedValue + "'"));
            SLcon = Sl + Convert.ToDouble(txtSoLuong.Text);
            sql = "UPDATE DMTV SET SoLuong =" + SLcon + " WHERE MaTV= N'" + cbbMaTiVi.SelectedValue + "'";
            functions.RunSQL(sql);

            // cập nhật lại giá nhập của mặt hàng trong bảng DMTV
            double giabanmoi, gianhapmoi;
            gianhapmoi = Convert.ToDouble(txtDonGiaNhap.Text.Trim());
            sql= "UPDATE DMTV SET DonGiaNhap =" + gianhapmoi + " WHERE MaTV = N'" + cbbMaTiVi.SelectedValue + "'";
            functions.RunSQL(sql);

            // cập nhật lại giá bán trong dmtv
            giabanmoi = gianhapmoi * 1.1;
            sql = "UPDATE DMTV SET DonGiaBan =" + giabanmoi + " WHERE MaTV = N'" + cbbMaTiVi.SelectedValue + "'";
            functions.RunSQL(sql);

            // Cập nhật lại tổng tiền cho hóa đơn 
            sql = "select SUM (ThanhTien) from ChiTietHDN where SoHDN = '" + txtMaHDN.Text.Trim() + "'";
            tong = Convert.ToDouble(functions.GetFieldValues(sql));
            Tongmoi = tong;
            sql = "UPDATE HoaDonNhap SET TongTien =" + Tongmoi + " WHERE SoHDN = N'" + txtMaHDN.Text + "'";
            functions.RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();

            cbbMaTiVi.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnThemChiTiet.Enabled = true;
            btnDong.Enabled = true;
            cbbMaNV.Enabled = false;
            cbbMaNCC.Enabled = false;
            dtpNgayNhap.Enabled = false;
            txtMaHDN.ReadOnly = true;
            cbbMaTiVi.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtSoLuong.Enabled = false;
            txtGiamGia.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaTV,SoLuong FROM ChiTietHDN WHERE SoHDN = N'" + txtMaHDN.Text + "'";
                DataTable tblHang = functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(functions.GetFieldValues("SELECT SoLuong FROM DMTV WHERE MaTV = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl - slxoa;
                    sql = "UPDATE DMTV SET SoLuong =" + slcon + " WHERE MaTV= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE ChiTietHDN WHERE SoHDN=N'" + txtMaHDN.Text + "'";
                functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE HoaDonNhap WHERE SoHDN=N'" + txtMaHDN.Text + "'";
                functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                cbbHDN.SelectedIndex = -1;
                btnXoa.Enabled = false;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbbHDB_DropDown(object sender, EventArgs e)
        {
            functions.FillCombo("SELECT SoHDN FROM HoaDonNhap", cbbHDN, "SoHDN", "SoHDN");
            cbbHDN.SelectedIndex = -1;
        }

        private void btnTimHoaDonNhap_Click_1(object sender, EventArgs e)
        {
            if (cbbHDN.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbHDN.Focus();
                return;
            }
            txtMaHDN.Text = cbbHDN.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThemChiTiet.Enabled = true;
        }

        private void btnThemDMTV_Click(object sender, EventArgs e)
        {
            FrmDMTiVi f = new FrmDMTiVi();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void grvHDN_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaTiVi.Focus();
                return;
            }
            cbbMaTiVi.Text = grvHDN.CurrentRow.Cells[0].Value.ToString();
            txtSoLuong.Text = grvHDN.CurrentRow.Cells[1].Value.ToString();
            txtDonGiaNhap.Text = grvHDN.CurrentRow.Cells[2].Value.ToString();
            txtGiamGia.Text = grvHDN.CurrentRow.Cells[3].Value.ToString();
            txtThanhTien.Text = grvHDN.CurrentRow.Cells[4].Value.ToString();
        }

        private void grvHDN_DoubleClick_1(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = grvHDN.CurrentRow.Cells["MaTV"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(grvHDN.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(grvHDN.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE ChiTietHDN WHERE SoHDN=N'" + txtMaHDN.Text + "' AND MaTV = N'" + MaHangxoa + "'";
                functions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(functions.GetFieldValues("SELECT SoLuong FROM DMTV WHERE MaTV = N'" + MaHangxoa + "'"));
                slcon = sl - SoLuongxoa;
                sql = "UPDATE DMTV SET SoLuong =" + slcon + " WHERE MaTV= N'" + MaHangxoa + "'";
                functions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(functions.GetFieldValues("SELECT TongTien FROM HoaDonNhap WHERE SoHDN = '" + txtMaHDN.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE HoaDonNhap SET TongTien =" + tongmoi + " WHERE SoHDN = N'" + txtMaHDN.Text + "'";
                functions.RunSQL(sql);
                txtTongTien.Text = tongmoi.ToString();
                LoadDataGridView();
            }
        }

        private void cbbMaTiVi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string str;
            if (cbbMaTiVi.Text == "")
            {
                txtSoLuong.Text = "";
                txtDonGiaNhap.Text = "";
            }
            // Khi chọn mã TV thì các thông tin về TV hiện ra

            str = "SELECT DonGiaNhap FROM DMTV WHERE MaTV =N'" + cbbMaTiVi.SelectedValue + "'";
            txtDonGiaNhap.Text = functions.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text.Trim() == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaNhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaNhap.Text);
            tt = sl * dg - gg;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaNhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaNhap.Text);
            tt = sl * dg - gg;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            cbbMaTiVi.Text = "";
            btnThemDMTV.Enabled = true;
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "0";
            cbbMaTiVi.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiamGia.Enabled = true;
            btnThemChiTiet.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        }
    }
}
