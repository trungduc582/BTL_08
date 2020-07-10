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
    public partial class FrmTop5NCC : Form
    {
        public int month = 1;
        DataTable tableBaoCao;
        public FrmTop5NCC()
        {
            InitializeComponent();
        }

        private void FrmTop5NCC_Load(object sender, EventArgs e)
        {
            Class.functions.Connect();

            string sql;
            sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
            tableBaoCao = functions.GetDataToTable(sql);
            dataGridView_BCTop5.DataSource = tableBaoCao;
            dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang1.Checked == true)
            {
                month = 1;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 1 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang1.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang2_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang2.Checked == true)
            {
                month = 2;
                cb_thang1.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 2 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang2.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang3_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang3.Checked == true)
            {
                month = 3;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 3 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang3.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang4_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang4.Checked == true)
            {
                month = 4;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 4 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang4.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang5_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang5.Checked == true)
            {
                month = 5;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 5 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang5.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang6_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang6.Checked == true)
            {
                month = 6;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 6 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang6.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang7_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang7.Checked == true)
            {
                month = 7;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 7 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang7.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang8_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang8.Checked == true)
            {
                month = 8;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 8 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang8.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang9_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang9.Checked == true)
            {
                month = 9;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 9 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang9.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang10_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang10.Checked == true)
            {
                month = 10;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang11.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 10 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang10.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang11_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang11.Checked == true)
            {
                month = 11;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang12.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 11 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang11.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void cb_thang12_Click(object sender, EventArgs e)
        {
            string sql;
            if (cb_thang12.Checked == true)
            {
                month = 12;
                cb_thang1.Checked = false;
                cb_thang2.Checked = false;
                cb_thang3.Checked = false;
                cb_thang4.Checked = false;
                cb_thang5.Checked = false;
                cb_thang6.Checked = false;
                cb_thang7.Checked = false;
                cb_thang8.Checked = false;
                cb_thang9.Checked = false;
                cb_thang10.Checked = false;
                cb_thang11.Checked = false;
                sql = "select top 5 Sum(ChiTietHDN.SoLuong) as SoLuongTV, NhaCungCap.MaNCC AS MaNCC,TenNCC  from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC where MONTH(NgayNhap) = 12 group by TenNCC, NhaCungCap.MaNCC";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
            if (cb_thang12.Checked == false)
            {
                sql = "select SoLuong as SoLuongTV, NhaCungCap.MaNCC AS MaNCC, TenNCC,NgayNhap,MaTV from HoaDonNhap inner join ChiTietHDN on HoaDonNhap.SoHDN = ChiTietHDN.SoHDN inner join NhaCungCap on HoaDonNhap.MaNCC = NhaCungCap.MaNCC order by NgayNhap asc";
                tableBaoCao = functions.GetDataToTable(sql);
                dataGridView_BCTop5.DataSource = tableBaoCao;
                dataGridView_BCTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cb_thang1.Checked == false && cb_thang2.Checked == false&& cb_thang3.Checked == false&&cb_thang4.Checked == false&&cb_thang5.Checked == false&&cb_thang6.Checked == false&&cb_thang7.Checked == false&&cb_thang8.Checked == false&&cb_thang9.Checked == false&&cb_thang10.Checked == false&&cb_thang11.Checked == false && cb_thang12.Checked == false)
            {
                MessageBox.Show("Bạn phải click chọn một tháng để xuất báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            exRange.Range["D2:I4"].Font.Size = 16;
            exRange.Range["D2:I4"].Font.Bold = true;
            exRange.Range["D2:I4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["D2:I4"].MergeCells = true;
            exRange.Range["D2:I4"].WrapText = true;
            exRange.Range["D2:I4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D2:I4"].Value = "BÁO CÁO 5 NCC CUNG CẤP NHIỀU HÀNG NHẤT THEO THÁNG " + month.ToString();
            
            //Tạo dòng tiêu đề bảng
            exRange.Range["E6:H6"].Font.Bold = true;
            exRange.Range["E6:H6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E6:E6"].ColumnWidth = 16;
            exRange.Range["F6:F6"].ColumnWidth = 16;
            exRange.Range["G6:G6"].ColumnWidth = 20;
            exRange.Range["E6:E6"].Value = "Số Lượng TiVi";
            exRange.Range["F6:F6"].Value = "Mã Nhà Cung Cấp";
            exRange.Range["G6:G6"].Value = "Tên Nhà Cung Cấp";
            for (phong = 0; phong < tableBaoCao.Rows.Count; phong++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[4][phong + 7] = phong + 1;
                for (cot = 0; cot < tableBaoCao.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 7
                {
                    exSheet.Cells[cot + 5][phong + 7] = tableBaoCao.Rows[phong][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][phong + 7] = tableBaoCao.Rows[phong][cot].ToString();
                }
            }
            
            exRange = exSheet.Cells[4][phong + 13]; //Ô A1 
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(DateTime.Now);
            exRange.Range["D1:F1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["D2:F2"].MergeCells = true;
            exRange.Range["D2:F2"].Font.Italic = true;
            exRange.Range["D2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D2:F2"].Value = "Ký Tên";
            exRange.Range["D6:F6"].MergeCells = true;
            exRange.Range["D6:F6"].Font.Italic = true;
            exRange.Range["D6:F6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exApp.Visible = true;
        }
    }
}
