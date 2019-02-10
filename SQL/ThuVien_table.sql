---- Tạo database ----
CREATE DATABASE QuanLyThuVien
GO

USE QuanLyThuVien
GO

---- Tạo table ----
-- Thể Loại
CREATE TABLE TheLoai
(
	matl CHAR(6) PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Unknown',
)
-- Đầu Sách
CREATE TABLE DauSach
(
	mads CHAR(10) PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Unknown',
	soluong INT NOT NULL DEFAULT 0,
	songaytoida TINYINT NOT NULL DEFAULT 0,
	sotienphat BIGINT NOT NULL DEFAULT 0,
	giabia BIGINT NOT NULL DEFAULT 0,
	matl CHAR(6) NOT NULL,

	--FOREIGN KEY (matl) REFERENCES TheLoai(matl)
)
 GO
-- Sách
CREATE TABLE Sach
(
	mads CHAR(10),
	stt INT NOT NULL,
	lost BIT NOT NULL DEFAULT 0,

	--FOREIGN KEY (mads) REFERENCES DauSach(mads),

	CONSTRAINT masach PRIMARY KEY (mads,stt)
)
 GO
-- Loại độc giả
CREATE TABLE LoaiDG
(
	maloai CHAR(6) PRIMARY KEY,
	socuon INT NOT NULL, 
)
 GO
-- Độc giả
CREATE TABLE DocGia
(
	madg CHAR(10) PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Unknown',
	sdt CHAR(10) NOT NULL,
	maloai CHAR(6) NOT NULL,
	dayblock DATE NULL,
	dayunblock DATE NULL,

	--FOREIGN KEY (maloai) REFERENCES LoaiDG(maloai)
)
 GO
-- Nhà Xuất Bản
CREATE TABLE NXB
(
	manxb CHAR(10) PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Unknown',
	email VARCHAR(100),
	sdt VARCHAR(11),
	fax VARCHAR(100)
)
 GO
-- Phiếu nhập sách
CREATE TABLE PhieuNhap
(
	ngaynhap DATETIME PRIMARY KEY
)
 GO
-- Phiếu giao sách
CREATE TABLE PhieuGiao
(
	ngaygiao DATETIME PRIMARY KEY
)
 GO
-- Phiếu mượn sách
CREATE TABLE PhieuMuon
(
	ngaymuon DATETIME PRIMARY KEY,
	madg CHAR(10) NOT NULL,

	--FOREIGN KEY (madg) REFERENCES DocGia(madg)
)
 GO
-- Phiếu trả sách
CREATE TABLE PhieuTra
(
	ngaytra DATETIME PRIMARY KEY
)
 GO
-- Thông tin phiếu nhập
CREATE TABLE TTPhieuNhap
(
	mapn DATETIME,
	mads CHAR(10),
	dongia BIGINT NOT NULL DEFAULT 0,
	soluong INT NOT NULL DEFAULT 0,
	ngaygiao DATE,
	mapg DATETIME NULL,
	manxb CHAR(10),

	--FOREIGN KEY (mapn) REFERENCES PhieuNhap(ngaynhap),
	--FOREIGN KEY (mads) REFERENCES DauSach(mads),
	--FOREIGN KEY (mapg) REFERENCES PhieuGiao(ngaygiao),
	--FOREIGN KEY (manxb) REFERENCES NXB(manxb),

	CONSTRAINT mattpn PRIMARY KEY (mapn,mads)
)
 GO
-- Thông tin phiếu mượn
CREATE TABLE TTPhieuMuon
(
	mapm DATETIME,
	mads CHAR(10),
	stt INT,
	phat BIGINT NOT NULL DEFAULT 0,
	mapt DATETIME NULL,

	--FOREIGN KEY (mapm) REFERENCES PhieuMuon(ngaymuon),
	--FOREIGN KEY (mapt) REFERENCES PhieuTra(ngaytra),
	--FOREIGN KEY(mads,stt) REFERENCES Sach(mads,stt),
	
	CONSTRAINT mattpm PRIMARY KEY (mapm,mads,stt)
)
 GO
/*
use ReportServer$TVHUY
drop database QuanLyThuVien
*/