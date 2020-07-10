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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyTiVi
{
    public partial class FrmTop3Selling : Form
    {
        DataTable tableBaoCao;
        String MaKH = "";
        public FrmTop3Selling()
        {
            InitializeComponent();
        }

        private void FrmTop3Selling_Load(object sender, EventArgs e)
        {
            Class.functions.Connect();
            txtTongTien.ReadOnly = true;
            txtTongTien.Text = "0";

            string sql;
            sql = "select TenKhach,ChiTietHDB.MaTV,TenTV, Sum(ChiTietHDB.SoLuong) as SoLuongTV , sum(ThanhTien *1000000) as ThanhTien from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV group by TenTV,TenKhach, ChiTietHDB.MaTV ORDER BY Sum(ChiTietHDB.SoLuong) DESC";
            tableBaoCao = functions.GetDataToTable(sql);
            dataGridView_BCTop3.DataSource = tableBaoCao;
            dataGridView_BCTop3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //////  Thêm  /////
            double tong;
            tong = Convert.ToDouble(functions.GetFieldValues("select sum(ThanhTien)*1000000 from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV"));
            txtTongTien.Text = tong.ToString();
            lblBangChu.Text = "Bằng chữ: " + functions.ChuyenSoSangChu(tong.ToString());

            //loadDataToGridView();
            //dataGridView_BCTop3.DataSource = null;
        }


        private void txtTenKH_Enter(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "Trần Mái Đình Hội")
            {
                txtTenKH.Text = "";
                txtTenKH.ForeColor = Color.Black;
            }
        }

        private void txtTenKH_Leave(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "")
            {
                txtTenKH.Text = "Trần Mái Đình Hội";
                txtTenKH.ForeColor = Color.Silver;
            }
        }


        private void btnIn_Click(object sender, EventArgs e)
        {
            if(txtTenKH.Text == "Trần Mái Đình Hội" || txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }    
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            int phong = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Điện Máy TiVi MIS";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (036)9592656";
            exRange.Range["D2:G2"].Font.Size = 16;
            exRange.Range["D2:G2"].Font.Bold = true;
            exRange.Range["D2:G2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["D2:G2"].MergeCells = true;
            exRange.Range["D2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D2:G2"].Value = "Báo Cáo 3 SP Được Mua Nhiều Nhất";
            //Tạo dòng tiêu đề bảng
            exRange.Range["A6:F6"].Font.Bold = true;
            exRange.Range["A6:F6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C6:F6"].ColumnWidth = 12;
            exRange.Range["B6:B6"].Value = "Số Lượng";
            exRange.Range["C6:C6"].Value = "Tên Khách Hàng";
            exRange.Range["D6:D6"].Value = "Mã TiVi";
            exRange.Range["E6:E6"].Value = "Tên TiVi";
            exRange.Range["F6:F6"].Value = "Thành Tiền";
            for (phong = 0; phong < tableBaoCao.Rows.Count; phong++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][phong + 7] = phong + 1;
                for (cot = 0; cot < tableBaoCao.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 7
                {
                    exSheet.Cells[cot + 2][phong + 7] = tableBaoCao.Rows[phong][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][phong + 7] = tableBaoCao.Rows[phong][cot].ToString();
                }
            }
            exRange = exSheet.Cells[cot][phong + 10];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][phong + 10];
            exRange.Font.Bold = true;
            double tong;
            
            if (txtTenKH.Text != "")
            {
                tong = Convert.ToDouble(functions.GetFieldValues("select sum(ThanhTien)*1000000 from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV WHERE  TenKhach Like N'%" + txtTenKH.Text + "%' "));
                exRange.Value2 = tong.ToString();
                exRange = exSheet.Cells[1][phong + 11]; //Ô A1 
                exRange.Range["A1:F1"].MergeCells = true;
                exRange.Range["A1:F1"].Font.Bold = true;
                exRange.Range["A1:F1"].Font.Italic = true;
                exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;

                exRange.Range["A1:F1"].Value = "Bằng chữ: " + Class.functions.ChuyenSoSangChu(tong.ToString());
            }

            exRange = exSheet.Cells[4][phong + 13]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(DateTime.Now);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Ký Tên";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exApp.Visible = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            string sql;
            double tong;
            if (txtTenKH.Text == "Trần Mái Đình Hội" || txtTenKH.Text == "")
            {
                //string sql;
                sql = "select TenKhach,ChiTietHDB.MaTV,TenTV, Sum(ChiTietHDB.SoLuong) as SoLuongTV , sum(ThanhTien *1000000) as ThanhTien from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV group by TenTV,TenKhach, ChiTietHDB.MaTV ORDER BY Sum(ChiTietHDB.SoLuong) DESC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop3.DataSource = tableBaoCao;
                dataGridView_BCTop3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                //////  Thêm  /////
                //double tong;
                tong = Convert.ToDouble(functions.GetFieldValues("select sum(ThanhTien)*1000000 from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV"));
                txtTongTien.Text = tong.ToString();
                lblBangChu.Text = "Bằng chữ: " + functions.ChuyenSoSangChu(tong.ToString());

                //MessageBox.Show("Hãy nhập điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MaKH = functions.GetFieldValues("select MaKhach from KhachHang WHERE  TenKhach Like N'%" + txtTenKH.Text + "%'");

            sql = "select Sum(ChiTietHDB.SoLuong) as SoLuongTV ,TenKhach,ChiTietHDB.MaTV,TenTV, sum(ThanhTien *1000000) as ThanhTien from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV  WHERE 1 =1";
            if (txtTenKH.Text.Trim() != "")
                sql = sql + " AND KhachHang.TenKhach LIKE N'%" + txtTenKH.Text.Trim() + "%' " + "group by TenTV,TenKhach, ChiTietHDB.MaTV ORDER BY Sum(ChiTietHDB.SoLuong) DESC";

            tableBaoCao = functions.GetDataToTable(sql);
            if (tableBaoCao.Rows.Count == 0)
            {
                //MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTongTien.Text = "0";
                lblBangChu.Text = " Bằng chữ: " + "";

            }
            else
            {
                //MessageBox.Show("Có " + tableBaoCao.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Cập nhật lại tổng tiền cho báo cáo
                if (txtTenKH.Text != "")
                {
                    tong = Convert.ToDouble(functions.GetFieldValues("select sum(ThanhTien)*1000000 from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV WHERE  TenKhach Like N'%" + txtTenKH.Text.Trim() + "%' "));
                    txtTongTien.Text = tong.ToString();
                    lblBangChu.Text = "Bằng chữ: " + Class.functions.ChuyenSoSangChu(tong.ToString());
                }

            }
            
            tableBaoCao = functions.GetDataToTable(sql);
            dataGridView_BCTop3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView_BCTop3.DataSource = tableBaoCao;
            functions.RunSQL(sql);
        }

        private void dataGridView_BCTop3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenKH.Text = dataGridView_BCTop3.CurrentRow.Cells["TenKhach"].Value.ToString();
            txtTenKH.ForeColor = Color.Black;
            MaKH = functions.GetFieldValues("select MaKhach from KhachHang WHERE  TenKhach Like N'%" + txtTenKH.Text + "%'");

            string sql;
            double tong;
            sql = "select  top 3 Sum(ChiTietHDB.SoLuong) as SoLuongTV ,TenKhach,ChiTietHDB.MaTV,TenTV, sum(ThanhTien *1000000) as ThanhTien from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV  WHERE 1 =1";
            if (txtTenKH.Text.Trim() != "")
                sql = sql + " AND KhachHang.MaKhach = '" + MaKH + "' " + "group by TenTV,TenKhach, ChiTietHDB.MaTV ORDER BY Sum(ChiTietHDB.SoLuong) DESC";

            tableBaoCao = functions.GetDataToTable(sql);
            if (tableBaoCao.Rows.Count == 0)
            {
                txtTongTien.Text = "0";
                lblBangChu.Text = " Bằng chữ: " + "";

            }
            else
            {
                if (txtTenKH.Text != "")
                {
                    tong = Convert.ToDouble(functions.GetFieldValues("select sum(ThanhTien)*1000000 from KhachHang inner join HoaDonBan on KhachHang.MaKhach = HoaDonBan.MaKhach inner join ChiTietHDB on HoaDonBan.SoHDB = ChiTietHDB.SoHDB inner join DMTV on dmtv.MaTV = ChiTietHDB.MaTV WHERE  TenKhach Like N'%" + txtTenKH.Text.Trim() + "%' "));
                    txtTongTien.Text = tong.ToString();
                    lblBangChu.Text = "Bằng chữ: " + Class.functions.ChuyenSoSangChu(tong.ToString());
                }

            }

            tableBaoCao = functions.GetDataToTable(sql);
            dataGridView_BCTop3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView_BCTop3.DataSource = tableBaoCao;
            functions.RunSQL(sql);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTenKH.Text = "";
            txtTenKH.ForeColor = Color.Black;
        }
    }
}
