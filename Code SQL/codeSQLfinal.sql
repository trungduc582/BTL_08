create table HangSanXuat(
MaHangSanXuat nvarchar(15) primary key not null,
TenHangSanXuat nvarchar(50))

create table KieuDang(
MaKieu nvarchar(15) primary key not null,
TenKieu nvarchar(50))

create table MauSac(
MaMau nvarchar(15) primary key not null,
TenMau nvarchar(50))

create table ManHinh(
MaManHinh nvarchar(15) primary key not null,
TenManHinh nvarchar(50))

create table CoManHinh(
MaCo nvarchar(15) primary key not null,
KichCo nvarchar(15))

create table NuocSanXuat(
MaNuocSX nvarchar(15) primary key not null,
TenNuocSX nvarchar(50))

create table DMTV(
MaTV nvarchar(15)primary key not null,
TenTV nvarchar(50)not null,
MaHangSanXuat nvarchar(15) not null,
foreign key(MaHangSanXuat) references HangSanXuat(MaHangSanXuat),
MaKieu nvarchar(15) not null,
foreign key(MaKieu) references KieuDang(MaKieu),
MaMau nvarchar(15) not null,
foreign key(MaMau) references MauSac(MaMau),
MaManHinh nvarchar(15) not null,
foreign key(MaManHinh) references ManHinh(MaManHinh),
MaCo nvarchar(15) not null,
foreign key(MaCo) references CoManHinh(MaCo),
MaNuocSX nvarchar(15) not null,
foreign key(MaNuocSX) references NuocSanXuat(MaNuocSX),
SoLuong int,
DonGiaNhap float,
DonGiaBan float,
Anh nvarchar,
ThoiGianBanHanh nvarchar(20))
----------------

create table CongViec(
MaCV nvarchar(15) primary key not null,
TenCV nvarchar(50))

create table CaLam(
MaCa nvarchar(15) primary key not null,
TenCa nvarchar(50))

create table NhanVien(
MaNV nvarchar(15) primary key not null,
TenNhanVien nvarchar(50),
GioiTinh nvarchar(3),
NgaySinh datetime,
DienThoai nvarchar(15),
DiaChi nvarchar(50),
MaCa nvarchar(15),
foreign key(MaCa) references CaLam(MaCa),
MaCV nvarchar(15)
foreign key(MaCV) references CongViec(MaCV))


create table KhachHang(
MaKhach nvarchar(15) primary key not null,
TenKhach nvarchar(50),
DiaChi nvarchar(50),
DienThoai nvarchar(15))


create table HoaDonBan(
SoHDB nvarchar(30) primary key not null,
MaNV nvarchar(15),
foreign key (MaNV) references NhanVien(MaNV),
MaKhach nvarchar(15),
foreign key(MaKhach) references KhachHang(MaKhach),
NgayBan date,
Thue float,
TongTien float)


create table NhaCungCap(
MaNCC nvarchar(15) primary key not null,
TenNCC nvarchar(50),
DiaChi nvarchar(50),
DienThoai nvarchar(15))


create table HoaDonNhap(
SoHDN nvarchar(30) primary key not null,
MaNV nvarchar(15),
foreign key (MaNV) references NhanVien(MaNV),
NgayNhap datetime,
MaNCC nvarchar(15),
foreign key (MaNCC) references NhaCungCap(MaNCC),
TongTien float)





create table ChiTietHDB(
SoHDB nvarchar(30) foreign key references HoaDonBan(SoHDB) on update cascade,
MaTV nvarchar(15),
foreign key(MaTV) references DMTV(MaTV)on update cascade,
primary key(SoHDB,MaTV),
SoLuong int,
DonGia float,
GiamGia float,
ThanhTien float)



create table ChiTietHDN(
SoHDN nvarchar(30) foreign key references HoaDonNhap(SoHDN) on update cascade,
MaTV nvarchar(15),
foreign key(MaTV) references DMTV(MaTV)on update cascade,
primary key(SoHDN,MaTV),
SoLuong int,
DonGia float,
GiamGia float,
ThanhTien float)


