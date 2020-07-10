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
    public partial class FrmHoaDonBan : Form
    {
        DataTable tblCTHDB; //Bảng chi tiết hoá đơn bán
        public FrmHoaDonBan()
        {
            InitializeComponent();
        }

        private void FrmHoaDonBan_Load(object sender, EventArgs e)
        {
            functions.Connect();
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            btnThemChiTiet.Enabled = false;
            btnLuu.Enabled = false;
            cbbMaNV.Enabled = false;
            cbbMakhach.Enabled = false;
            dtpNgayBan.Enabled = false;
            txtThue.ReadOnly = true;
            txtMaHDB.ReadOnly = true;
            cbbMaTiVi.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtSoluong.Enabled = false;
            txtGiamGia.Enabled = false;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            functions.FillCombo("SELECT MaKhach FROM KhachHang", cbbMakhach, "MaKhach", "MaKhach");
            cbbMakhach.SelectedIndex = -1;
            functions.FillCombo("SELECT MaNV FROM NhanVien", cbbMaNV, "MaNV", "MaNV");
            cbbMaNV.SelectedIndex = -1;
            functions.FillCombo("SELECT MaTV FROM DMTV", cbbMaTiVi, "MaTV", "MaTV");
            cbbMaTiVi.SelectedIndex = -1;
            LoadDataGridView();
        }
       
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM HoaDonBan WHERE SoHDB = N'" + txtMaHDB.Text.Trim() + "'";
            dtpNgayBan.Text = functions.ConvertDateTime(functions.GetFieldValues(str));
            str = "SELECT MaNV FROM HoaDonBan WHERE SoHDB = N'" + txtMaHDB.Text.Trim() + "'";
            cbbMaNV.Text = functions.GetFieldValues(str);
            str = "SELECT MaKhach FROM HoaDonBan WHERE SoHDB = N'" + txtMaHDB.Text.Trim() + "'";
            cbbMakhach.Text = functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDonBan WHERE SoHDB = N'" + txtMaHDB.Text.Trim() + "'";
            txtTongTien.Text = functions.GetFieldValues(str);
            str = "SELECT Thue FROM HoaDonBan WHERE SoHDB = N'" + txtMaHDB.Text.Trim() + "'";
            txtThue.Text = functions.GetFieldValues(str);
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "select a.MaTV, a.SoLuong, a.DonGia, a.GiamGia,a.ThanhTien from ChiTietHDB a WHERE a.SoHDB ='" + txtMaHDB.Text.Trim() + "'";
            tblCTHDB = functions.GetDataToTable(sql);
            grvHDB.DataSource = tblCTHDB;
            grvHDB.Columns[0].HeaderText = "Mã TiVi";
            grvHDB.Columns[1].HeaderText = "Số Lượng";
            grvHDB.Columns[2].HeaderText = "Đơn Giá";
            grvHDB.Columns[3].HeaderText = "Giảm giá";
            grvHDB.Columns[4].HeaderText = "Thành tiền";
            grvHDB.Columns[0].Width = 100;
            grvHDB.Columns[1].Width = 100;
            grvHDB.Columns[2].Width = 100;
            grvHDB.Columns[3].Width = 100;
            grvHDB.Columns[4].Width = 100;
            grvHDB.AllowUserToAddRows = false;
            grvHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnDong.Enabled = true;
            btnThem.Enabled = false;
            cbbMaTiVi.Enabled = true;
            cbbMaNV.Enabled = true;
            cbbMakhach.Enabled = true;
            txtThue.ReadOnly = false;
            txtMaHDB.ReadOnly = true;
            dtpNgayBan.Enabled = true;
            cbbMaTiVi.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiamGia.Enabled = true;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            btnThemChiTiet.Enabled = false;
            ResetValues();
            grvHDB.DataSource = null;
            cbbHDB.SelectedValue = -1;
            txtMaHDB.Text = functions.CreateKey("HDB_");
        }
        private void ResetValues()
        {
            txtMaHDB.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            cbbMaNV.Text = "";
            cbbMakhach.Text = "";
            txtThue.Text = "";
            txtTongTien.Text = "0";
            cbbMaTiVi.Text = "";
            txtSoluong.Text = "";
            txtDonGiaBan.Text = "";
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
            cbbMakhach.Enabled = false;
            dtpNgayBan.Enabled = false;
            txtThue.ReadOnly = true;
            txtMaHDB.ReadOnly = true;
            cbbMaTiVi.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtSoluong.Enabled = false;
            txtGiamGia.Enabled = false;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            cbbMaNV.Enabled = false;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            btnThemChiTiet.Enabled = true;
            if (cbbHDB.Text != "")
            {
                txtMaHDB.Text = cbbHDB.Text;
                LoadInfoHoaDon();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon,thuemoi, Tongmoi;
            sql = "SELECT SoHDB FROM HoaDonBan WHERE SoHDB=N'" + txtMaHDB.Text.Trim() + "'";
            if (!functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                if (cbbMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbMaNV.Focus();
                    return;
                }
                if (cbbMakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbMakhach.Focus();
                    return;
                }
                if (txtThue.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập thuế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtThue.Focus();
                    return;
                }
                sql = "INSERT INTO HoaDonBan(SoHDB, MaNV, MaKhach,NgayBan,Thue, TongTien) VALUES (N'" + txtMaHDB.Text.Trim() + "','" +
                        cbbMaNV.SelectedValue + "',N'" + cbbMakhach.SelectedValue + "','" + dtpNgayBan.Value + "',N'" +
                       txtThue.Text.Trim() + "'," + txtTongTien.Text.Trim() + ")";
                functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cbbMaTiVi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã TiVi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaTiVi.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            sql = "SELECT MaTV FROM ChiTietHDB WHERE MaTV=N'" + cbbMaTiVi.SelectedValue + "' AND SoHDB = N'" + txtMaHDB.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMaTiVi.SelectedValue = "";
                cbbMaTiVi.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(functions.GetFieldValues("SELECT SoLuong FROM DMTV WHERE MaTV = N'" + cbbMaTiVi.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng TiVi này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO ChiTietHDB(SoHDB,MaTV,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtMaHDB.Text.Trim() + "',N'" + cbbMaTiVi.SelectedValue + "'," +
                    txtSoluong.Text.Trim() + "," + txtDonGiaBan.Text.Trim() + ","+ txtGiamGia.Text.Trim() + "," + txtThanhTien.Text.Trim() + ")";
            functions.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng DMTV
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE DMTV SET SoLuong =" + SLcon + " WHERE MaTV= N'" + cbbMaTiVi.SelectedValue + "'";
            functions.RunSQL(sql);

            // cập nhật lại thuế
            thuemoi =Convert.ToDouble(txtThue.Text);
            sql = "UPDATE HoaDonBan SET Thue =" + thuemoi + " WHERE SoHDB = N'" + txtMaHDB.Text + "'";
            functions.RunSQL(sql);
            txtThue.Text = thuemoi.ToString();

            // Cập nhật lại tổng tiền cho hóa đơn bán
            sql = "select SUM (ThanhTien) from ChiTietHDB where SoHDB = N'" + txtMaHDB.Text.Trim() + "'";
            Tongmoi = Convert.ToDouble(functions.GetFieldValues(sql));
            sql = "UPDATE HoaDonBan SET TongTien =" + Tongmoi + " WHERE SoHDB = N'" + txtMaHDB.Text + "'";
            functions.RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();
            
            cbbMaTiVi.Text = "";
            txtSoluong.Text = "";
            txtDonGiaBan.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnThemChiTiet.Enabled = true;
            btnDong.Enabled = true;
            cbbMaNV.Enabled = false;
            cbbMakhach.Enabled = false;
            dtpNgayBan.Enabled = false;
            txtThue.ReadOnly = true;
            txtMaHDB.ReadOnly = true;
            cbbMaTiVi.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtSoluong.Enabled = false;
            txtGiamGia.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaTV,SoLuong FROM ChiTietHDB WHERE SoHDB = N'" + txtMaHDB.Text + "'";
                DataTable tblHang = functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(functions.GetFieldValues("SELECT SoLuong FROM DMTV WHERE MaTV = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE DMTV SET SoLuong =" + slcon + " WHERE MaTV= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE ChiTietHDB WHERE SoHDB=N'" + txtMaHDB.Text + "'";
                functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE HoaDonBan WHERE SoHDB=N'" + txtMaHDB.Text + "'";
                functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                cbbHDB.SelectedIndex = -1;
                btnXoa.Enabled = false;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbMaTiVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbMaTiVi.Text == "")
            {
                txtSoluong.Text = "";
                txtDonGiaBan.Text = "";
            }
            // Khi chọn mã TV thì các thông tin về TV hiện ra
           
            str = "SELECT DonGiaBan FROM DMTV WHERE MaTV =N'" + cbbMaTiVi.SelectedValue + "'";
            txtDonGiaBan.Text = functions.GetFieldValues(str);
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text.Trim() == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - gg;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - gg;
            txtThanhTien.Text = tt.ToString();
        }

        private void cbbHDB_DropDown(object sender, EventArgs e)
        {
            functions.FillCombo("SELECT SoHDB FROM HoaDonBan", cbbHDB, "SoHDB", "SoHDB");
            cbbHDB.SelectedIndex = -1;
        }

        private void btnTimHoaDonBan_Click(object sender, EventArgs e)
        {
            if (cbbHDB.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbHDB.Focus();
                return;
            }
            ResetValues();
            txtMaHDB.Text = cbbHDB.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            btnThemChiTiet.Enabled = true;
        }
        

       

        private void grvHDB_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = grvHDB.CurrentRow.Cells["MaTV"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(grvHDB.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(grvHDB.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE ChiTietHDB WHERE SoHDB=N'" + txtMaHDB.Text + "' AND MaTV = N'" + MaHangxoa + "'";
                functions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(functions.GetFieldValues("SELECT SoLuong FROM DMTV WHERE MaTV = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE DMTV SET SoLuong =" + slcon + " WHERE MaTV= N'" + MaHangxoa + "'";
                functions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(functions.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE SoHDB = N'" + txtMaHDB.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE HoaDonBan SET TongTien =" + tongmoi + " WHERE SoHDB = N'" + txtMaHDB.Text + "'";
                functions.RunSQL(sql);

                cbbMaTiVi.Text = "";
                txtSoluong.Text = "";
                txtDonGiaBan.Text = "";
                txtGiamGia.Text = "";
                txtThanhTien.Text = "0";
                txtTongTien.Text = tongmoi.ToString();
                LoadDataGridView();
            }
        }

        private void grvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            cbbMaTiVi.Text = grvHDB.CurrentRow.Cells[0].Value.ToString();
            txtSoluong.Text = grvHDB.CurrentRow.Cells[1].Value.ToString();
            txtDonGiaBan.Text = grvHDB.CurrentRow.Cells[2].Value.ToString();
            txtGiamGia.Text = grvHDB.CurrentRow.Cells[3].Value.ToString();
            txtThanhTien.Text = grvHDB.CurrentRow.Cells[4].Value.ToString();
            btnHuy.Enabled = true;
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            cbbMaTiVi.Text = "";
            txtSoluong.Text = "";
            txtDonGiaBan.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "0";
            cbbMaTiVi.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiamGia.Enabled = true;
            btnThemChiTiet.Enabled = false;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void cbbHDB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
