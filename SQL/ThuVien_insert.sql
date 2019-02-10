USE QuanLyThuVien
GO
---- Thêm dữ liệu ----
-- Thể Loại
INSERT INTO TheLoai
VALUES ('TL0001',N'Ngoại ngữ')
 GO
INSERT INTO TheLoai
VALUES ('TL0002',N'Truyện Tranh')
 GO
-- Đầu Sách
INSERT INTO DauSach(mads, ten, matl)
VALUES ('DS00000001', N'Tiếng Anh cho người mới', 'TL0001')
 GO
INSERT INTO DauSach(mads, ten, matl)
VALUES ('DS00000002', N'Tiếng Anh chuyên ngành', 'TL0001')
 GO
INSERT INTO DauSach(mads, ten, matl)
VALUES ('DS00000003', N'Doraemon tập 1', 'TL0002')
 GO
-- Sách
INSERT INTO Sach
VALUES('DS00000001',1,1)
 GO
INSERT INTO Sach
VALUES('DS00000001',2,0)
 GO
INSERT INTO Sach
VALUES('DS00000001',3,0)
 GO
INSERT INTO Sach
VALUES('DS00000002',1,0)
 GO
INSERT INTO Sach
VALUES('DS00000002',2,0)
 GO
-- Loại độc giả 
INSERT INTO LoaiDG
VALUES('LR0001',10)
 GO
INSERT INTO LoaiDG
VALUES('LR0002',8)
 GO
INSERT INTO LoaiDG
VALUES('LR0003',6)
 GO
-- Độc giả
INSERT INTO DocGia(madg,ten,sdt,maloai,dayblock,dayunblock)
VALUES('DG00000001',N'Trương Vĩ Huy','0363679542','LR0003','1/7/2018','2/7/2018')
 GO
INSERT INTO DocGia(madg,ten,sdt,maloai)
VALUES('DG00000002',N'Đoàn Ngọc Thảo','0000000000','LR0002')
 GO
INSERT INTO DocGia(madg,ten,sdt,maloai,dayblock)
VALUES('DG00000003',N'Hà Thị Bích Chi','0000000000','LR0001','1/7/2018')
 GO
-- NXB
INSERT INTO NXB(manxb,ten,email,sdt,fax)
VALUES('NX00000001',N'Nhà xuất bản Trẻ','nhaxuatbantre@gmail.com','0909090909','0909090909')
 GO
INSERT INTO NXB(manxb,ten,email,sdt)
VALUES('NX00000002',N'Kim Đồng','kimdong@gmail.com','0909090909')
 GO
-- PhieuNhap
INSERT INTO PhieuNhap
VALUES('12/28/2018 7:00:00 PM')
 GO
INSERT INTO PhieuNhap
VALUES('1/20/2019 7:00:00 AM')
 GO
-- PhieuGiao
INSERT INTO PhieuGiao
VALUES('1/27/2019 7:00:00 AM')
 GO
-- Phiếu Mượn
INSERT INTO PhieuMuon
VALUES('11/28/2018 7:00:00 PM','DG00000001')
 GO
-- PhieuTra
INSERT INTO PhieuTra
VALUES('1/29/2019 9:00:00 AM')
 GO
-- TTPhieuNhap
INSERT INTO TTPhieuNhap(mapn,mads,dongia,soluong,ngaygiao,manxb,mapg)
VALUES('12/28/2018 7:00:00 PM','DS00000001',10000,1,'12/28/2019','NX00000001','1/27/2019 7:00:00 AM')
 GO
INSERT INTO TTPhieuNhap(mapn,mads,dongia,soluong,ngaygiao,manxb)
VALUES('12/28/2018 7:00:00 PM','DS00000002',10000,1,'12/28/2019','NX00000001')
 GO
-- TTPhieuMuon
INSERT INTO TTPhieuMuon(mapm,mads,stt,phat,mapt)
VALUES('11/28/2018 7:00:00 PM','DS00000001',3,10000,'1/29/2019 9:00:00 AM')
 GO
INSERT INTO TTPhieuMuon(mapm,mads,stt)
VALUES('11/28/2018 7:00:00 PM','DS00000001',2)
 GO
/*
DELETE FROM Sach
WHERE mads = 'DS00000004' AND stt = 1 OR stt = 2
select *
FROM Sach
where mads = 'DS00000003'
*/
/*
use ReportServer$TVHUY
*/