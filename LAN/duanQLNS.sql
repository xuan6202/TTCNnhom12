USE master
GO
IF EXISTS(SELECT 'True' FROM master.dbo.SysDatabases WHERE NAME='QuanLNS')
DROP DATABASE QuanLNS
GO
CREATE DATABASE QuanLNS
GO
USE QuanLNS
GO

create table DangNhap(
	TenDN nvarchar(30),
	MatKhau varchar(20),
	MaNV char(5) primary key
)
go
create table PhongBan (
	MaPB char(5) primary key,
	TenPB nvarchar(30),
	SoNV_PB int,
	MoTaPB nvarchar(50)
)
go
create table DuAn (
	MaDA char(5) primary key,
	TenDA nvarchar(30),
	SoNV_DA int, 
	MoTa_DA nvarchar(50)
)
go
create table NhanVien (
	MaNV char(5) primary key,
	TenNV nvarchar(30),
	NgaySinh nvarchar(30),
	DiaChi nvarchar(30),
	Luong float,
	MaPB char(5),
	MaDA char(5),
	constraint fk_pb FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB) on update cascade on delete cascade,
	constraint fk_da FOREIGN KEY(MaDA) REFERENCES DuAn(MaDA) on update cascade on delete cascade
)
updata 
go
INSERT INTO DangNhap VALUES ('giangpt', 12345678, 'NV01'),
							('hoangnh', 12345678, 'NV02'),
							('lanbt', 12345678, 'NV03'),
							('xuanht', 12345678, 'NV04')
GO
INSERT INTO PhongBan VALUES ('PB01',N'Phòng nhân sự', 10, N'Tìm kiếm nhân viên'),
							('PB02',N'Phòng kế toán ', 7, N'Lập bảng lương, thuế'),
							('PB03',N'Phòng Kinh Doanh', 14, N'Lên kế hoạch kinh doanh'),
							('PB04',N'Phòng Marketing', 21, N'Lên kế hoạch truyền thông'),
							('PB05',N'Phòng Kĩ thuật', 10, N'Sửa chữa sự cố kĩ thuật')					
GO
Insert into DuAn Values ('DA01',N'Dự án 01', 5, N'Mô tả 1'),
						('DA02',N'Dự án 02', 10, N'Mô tả 2'),
						('DA03',N'Dự án 03', 12, N'Mô tả 3'),
						('DA04',N'Dự án 04', 7, N'Mô tả 4')
go
Insert into NhanVien values ('NV01', N'Phùng Thị Giang', '1/1/2002',N'Hà Nội', 2000, 'PB01', 'DA02'),
							('NV02', N'Nguyễn Huy Hoàng', '1/1/2002',N'Hà Nội', 1500, 'PB03', 'DA02'),
							('NV03', N'Bùi Thị Lan', '1/1/2002',N'Hà Nội', 1700, 'PB04', 'DA01'),
							('NV04', N'Hoàng Thị Xuân', '1/1/2002',N'Hà Nội', 2200, 'PB02', 'DA04')
Insert into NhanVien values ('NV05', N'Lăng Thảo Văn', '10/10/2000',N'Hà Nội', 2000, 'PB01', 'DA02')
go

select * from DangNhap
Select * from PhongBan
select * from DuAn
select * from NhanVien 

update NhanVien set DiaChi = N'Thái Nguyên' where MaNV = 'NV05'

delete from DangNhap where TenDN = 'van321pro'
