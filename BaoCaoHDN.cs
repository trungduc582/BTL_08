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
    public partial class BaoCaoHDN : Form
    {
        DataTable tblBC;
        string sql;
        Double tong;
        public BaoCaoHDN()
        {
            InitializeComponent();
        }

        private void BaoCaoHDN_Load(object sender, EventArgs e)
        {
            functions.Connect();
            ResetValues();
            btnIn.Enabled = false;
            btnTimLai.Enabled = false;
            grvBaoCaoHDB.DataSource = null;
            functions.FillCombo("SELECT MaNCC FROM NhaCungCap", cbbMaNCC, "MaNCC", "MaNCC");
            cbbMaNCC.SelectedIndex = -1;
        }
        private void ResetValues()
        {
            cbbMaNCC.SelectedItem = null;
            
            txtTongTien.Text = "0";
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (cbbMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbMaNCC.Focus();
                return;
            }
            

            if (cbbMaNCC.Text.Trim() != "")
            {
                sql = "SELECT * FROM HoaDonNhap WHERE MaNCC='" + cbbMaNCC.Text.Trim() +"'";
                tblBC = functions.GetDataToTable(sql);

            }


            if (tblBC.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTongTien.Text = "0";
                return;
            }
            else
            {
                MessageBox.Show("Có " + tblBC.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Cập nhật lại tổng tiền cho báo cáo
               
                tong = Convert.ToDouble(functions.GetFieldValues("SELECT sum(TongTien)*1000000 FROM HoaDonNhap WHERE MaNCC='" + cbbMaNCC.Text.Trim() + "'"));
                txtTongTien.Text = tong.ToString();
                lbBangChu.Text = "Bằng chữ: " + Class.functions.ChuyenSoSangChu(tong.ToString());
                tblBC = functions.GetDataToTable(sql);
                grvBaoCaoHDB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                grvBaoCaoHDB.DataSource = tblBC;
                functions.RunSQL(sql);
                btnTimLai.Enabled = true;
                btnIn.Enabled = true;

            }
            btnBaoCao.Enabled = false;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnTimLai.Enabled = false;
            btnIn.Enabled = false;
            btnBaoCao.Enabled = true;
            grvBaoCaoHDB.DataSource = null;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa Hàng TiVi";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Cầu Giấy - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (03)73200740";


            exRange.Range["C3:F3"].Font.Size = 16;
            exRange.Range["C3:F3"].Font.Name = "Times new roman";
            exRange.Range["C3:F3"].Font.Bold = true;
            exRange.Range["C3:F3"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C3:F3"].MergeCells = true;
            exRange.Range["C3:F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C3:F3"].Value = "BÁO CÁO DANH SÁCH HÓA ĐƠN";

            exRange.Range["B5:C5"].MergeCells = true;
            exRange.Range["B5:C5"].Font.Bold = true;
            exRange.Range["B5:C5"].Font.Italic = true;
            exRange.Range["B5:C5"].Value = "Nhà Cung Cấp: "+ cbbMaNCC.Text;

            //Tạo dòng tiêu đề bảng
            exRange.Range["A7:G7"].Font.Bold = true;
            exRange.Range["A7:G7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C7:G7"].ColumnWidth = 12;
            exRange.Range["A7:A7"].Value = "STT";
            exRange.Range["B7:B7"].Value = "Số HDN";
            exRange.Range["C7:C7"].Value = "Mã NV";
            exRange.Range["D7:D7"].Value = "Ngày Nhập";
            exRange.Range["E7:E7"].Value = "Mã NCC";
            exRange.Range["F7:F7"].Value = "Tổng Tiền";

            for (hang = 0; hang <= grvBaoCaoHDB.Rows.Count - 2; hang++)
            {
                exSheet.Cells[1][hang + 8] = hang + 1;
                for (cot = 0; cot < grvBaoCaoHDB.ColumnCount; cot++)
                {
                    exSheet.Cells[hang + 8, cot + 2] = grvBaoCaoHDB.Rows[hang].Cells[cot].Value;
                }
            }
            exRange = exSheet.Cells[cot][hang + 10];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange.Value2 = "Tổng tiền: " + txtTongTien.Text.ToString();
            exRange = exSheet.Cells[1][hang + 11];
            exRange.Range["D1:G1"].MergeCells = true;
            exRange.Range["D1:G1"].Font.Bold = true;
            exRange.Range["D1:G1"].Font.Italic = true;
            exRange.Range["D1:G1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["D1:G1"].Value = "Bằng chữ:   " + functions.ChuyenSoSangChu(txtTongTien.Text.ToString());

            exRange = exSheet.Cells[4][hang + 12];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + day + " tháng " + month + " năm " + year;

            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Người lập báo cáo";

            exRange.Range["A3:C3"].MergeCells = true;
            exRange.Range["A3:C3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:C3"].Value = "(Kí, Ghi rõ họ tên)";

            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }
    }
}
