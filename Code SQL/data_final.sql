insert into HangSanXuat values('hsx1','SAMSUNG');
insert into HangSanXuat values('hsx2','SONY');
insert into HangSanXuat values('hsx3','LG');

insert into KieuDang values('kd1',N'Phẳng');
insert into KieuDang values('kd2',N'Cong');

insert into MauSac values('ms1',N'Bạc');
insert into MauSac values('ms2',N'Đen');

insert into ManHinh values('mh1','OLED');
insert into ManHinh values('mh2','LCD');
insert into ManHinh values('mh3','LED');

insert into CoManHinh values('c1','32');
insert into CoManHinh values('c2','49');
insert into CoManHinh values('c3','55');
insert into CoManHinh values('c4','65');

insert into NuocSanXuat values('nsx1',N'Việt Nam');
insert into NuocSanXuat values('nsx2',N'Nhật Bản');
insert into NuocSanXuat values('nsx3',N'Trung Quốc');

insert into DMTV values('dmtv1','Smart Tivi QLED Samsung 4K QA43Q65R','hsx1','kd1','ms1','mh1','c3','nsx1','5','13','14.3','',N'2 năm');
-----------------
insert into DMTV values('dmtv2','Smart Tivi 4K 49 inch KD-49X7000G','hsx2','kd1','ms2','mh2','c3','nsx2','5','11.4','12.54','',N'1.5 năm');
insert into DMTV values('dmtv3','Smart Tivi 4K 55 inch KD-49X7000G','hsx2','kd1','ms2','mh2','c4','nsx2','5','15','16.5','',N'2 năm');

SELECT * FROM DMTV
----------------
insert into CongViec values('cv1',N'Tiếp tân');
insert into CongViec values('cv2',N'Quản lý');
insert into CongViec values('cv3',N'Bán hàng');
insert into CongViec values('cv4',N'Kĩ thuật viên');
insert into CongViec values('cv5',N'Quản lý kho');

insert into CaLam values('cl1',N'Ca sáng');
insert into CaLam values('cl2',N'Ca trưa');
insert into CaLam values('cl3',N'Ca chiều');
insert into CaLam values('cl4',N'Ca tối');

insert into NhanVien values('nv1',N'Nguyễn Trung Đức',N'Nam','04-Feb-2000','01653391231',N'12 Chùa Bộc - Đống Đa','cl1','cv3');
insert into NhanVien values('nv2',N'Nguyễn Ngọc Anh',N'Nữ','04-Jan-2001','01653441231',N'17 Tây Sơn - Đống Đa','cl1','cv1');
insert into NhanVien values('nv3',N'Nguyễn Nam Anh','Nam','09-Mar-1997','01653394431',N'16 Chùa Bộc - Đống Đa','cl1','cv2');
insert into NhanVien values('nv4',N'Nguyễn Hùng Nam','Nam','15-Sep-2000','01674591231',N'21 Khương Thượng - Đống Đa','cl1','cv4');
insert into NhanVien values('nv5',N'Nguyễn Đức Anh','Nam','22-May-1996','03333391231',N'55 Nguyễn Lương Bằng - Đống Đa','cl3','cv3');
insert into NhanVien values('nv6',N'Trần Thị Ánh',N'Nữ','22-Feb-1999','0165591231',N'12 Đặng Văn Ngữ - Đống Đa','cl2','cv3');

insert into KhachHang values('kh1',N'Trần Đình Hội',N'Quảng Ninh','0372896511');
insert into KhachHang values('kh2',N'Đỗ Quang Dũng',N'Thái Bình','0112896511');
insert into KhachHang values('kh3',N'Nguyễn Trịnh Quốc Long',N'Hà Nội','0992896511');

insert into HoaDonBan values('HDB_07062020_104754','nv1','kh1','22-Sep-2019','1.3','14.3');
insert into HoaDonBan values('HDB02','nv1','kh2','12-Mar-2020','1.5','16.5');
insert into HoaDonBan values('HDB01','nv1','kh1','22-Sep-2019','1.3','14.3');
--------------------
INSERT INTO HoaDonBan(SoHDB, MaNV, MaKhach,NgayBan,Thue, TongTien) VALUES (N'HDB_07062020_113419','nv2',N'kh2','07/06/2020 11:34:19',N'0','13')
select * from HoaDonBan

insert into NhaCungCap values('ncc1',N'Samsung Việt Nam Đông Bắc Bộ',N'Bắc Ninh','0999888777');
insert into NhaCungCap values('ncc2',N'LG Việt Nam Đông Bắc Bộ',N'Hà Nội','09911668557');
insert into NhaCungCap values('ncc3',N'Sony Việt Nam Đông Bắc Bộ',N'Ninh Bình','0123445511');
insert into NhaCungCap values('ncc4',N'Samsung Việt Nam Hà Nội',N'Bắc Ninh','0999888777');
insert into NhaCungCap values('ncc5',N'LG Việt Nam Hà Nội',N'Hà Nội','09911668557');
insert into NhaCungCap values('ncc6',N'Sony Việt Nam Hà Nội',N'Ninh Bình','0123445511');


insert into HoaDonNhap values('HDN01','nv1','22-Oct-2019','ncc1','73');

SELECT CONVERT(nvarchar, '22/02/2020', 106);

INSERT INTO ChiTietHDB VALUES('HDB_07062020_104754','dmtv1','1','13','0','13')
insert into ChiTietHDB values('HDB01','dmtv2','1','13','0','13')
insert into ChiTietHDB values('HDB02','dmtv2','1','15','0','15')
SELECT * FROM ChiTietHDB
select SUM (ThanhTien) from ChiTietHDB where SoHDB = N'HDB_07062020_104754'
delete from ChiTietHDB

insert into ChiTietHDN values('HDN01','dmtv1','5','12','10','50')
insert into ChiTietHDN values('HDN02','dmtv2','10','11.4','1','100')
insert into ChiTietHDN values('HDN03','dmtv2','10','15','3','150')


---------------------------1/6/2020
insert into DMTV values('dmtv4','Android Tivi Sony 4K 49 inch KD-43X8000G','hsx2','kd1','ms2','mh2','c2','nsx2','10','10.6','11.66','',N'2 năm');
insert into DMTV values('dmtv5','Smart Tivi LG 4K 65 inch 65UM7400PTA','hsx3','kd1','ms2','mh2','c4','nsx3','7','25','27.5','',N'3 năm');
insert into DMTV values('dmtv6','Smart Tivi Samsung 4K 65 inch UA65RU7100','hsx1','kd1','ms1','mh1','c4','nsx1','5','17','18.7','',N'2 năm');

insert into HoaDonBan values('HDB04','nv4','kh1','22-05-2020','0','156.98');

INSERT INTO ChiTietHDB VALUES('HDB03','dmtv4','3','11.66','3','31.98')
INSERT INTO ChiTietHDB VALUES('HDB03','dmtv5','5','27.5','12.5','125')

select a.MaTV, a.SoLuong, a.DonGia, a.GiamGia,a.ThanhTien from ChiTietHDB a WHERE a.SoHDB ='HDB_07062020_210056'
select * from HoaDonBan
select * from HoaDonNhap
select * from ChiTietHDN
select * from DMTV
select * from ChiTietHDB
SELECT * FROM DMTV
SELECT * FROM MauSac

delete from HoaDonBan where SoHDB='03'
SELECT  * FROM HoaDonBan;
select * from ChiTietHDB;
select top 3 b.MaTV from 
DMTV a join ChiTietHDB b on a.MaTV = b.MaTV 
join HoaDonBan c on b.SoHDB = c.SoHDB 
join KhachHang d on c.MaKhach = d.MaKhach 
where d.MaKhach ='kh1' group by b.SoLuong;

