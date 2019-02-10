USE QuanLyThuVien
GO
---- Tạo Procedures ----
-- Tìm thể loại sách
CREATE PROC dbo.SelecBookCategorys
AS
BEGIN
	SELECT matl, ten
	FROM dbo.TheLoai
	ORDER BY ten
END
 GO
-- Tìm tiêu đề sách dựa trên thể loại
CREATE PROC dbo.SelecTitleBooks
@catebook CHAR(6)
AS
BEGIN
	IF @catebook IS NOT NULL 
		SELECT mads, ten, soluong, songaytoida, sotienphat, giabia
		FROM dbo.DauSach
		WHERE dbo.DauSach.matl = @catebook
		ORDER BY soluong
	ELSE
		SELECT mads, ten, soluong, songaytoida, sotienphat, giabia
		FROM dbo.DauSach
		ORDER BY soluong
END
 GO
-- Tìm Sách dựa trên tiêu đề sách và lọc ra trạng thái sách
CREATE PROC dbo.SelecBooks
@titlbook CHAR(10)
AS
BEGIN
	SELECT Sach.mads, Sach.stt, 
	CASE
		WHEN lost = 1 THEN N'Đã mất'
		WHEN EXISTS(
			SELECT mads,stt 
			FROM dbo.TTPhieuMuon 
			WHERE dbo.Sach.mads = dbo.TTPhieuMuon.mads 
			  AND dbo.Sach.stt = dbo.TTPhieuMuon.stt
			  AND dbo.TTPhieuMuon.mapt IS NULL
		) THEN N'Được mượn'
		ELSE N'Vẫn còn'
	END AS trangthai
	FROM dbo.Sach
	WHERE dbo.Sach.mads = @titlbook
	ORDER BY stt
END
 GO
-- Tìm sách mượn của độc giả
CREATE PROC dbo.SelecBookIsLend
@madg CHAR(10)
AS
BEGIN
	SELECT DauSach.mads, DauSach.ten, songaytoida, sotienphat, giabia, TTPhieuMuon.stt, mapm
	FROM DauSach, TTPhieuMuon, PhieuMuon
	WHERE PhieuMuon.madg = @madg
	  AND PhieuMuon.ngaymuon = TTPhieuMuon.mapm
	  AND TTPhieuMuon.mapt IS NULL
	  AND TTPhieuMuon.mads = DauSach.mads
END
 GO
-- Tìm loại độc giả
CREATE PROC dbo.SelecTypeOfReaders
AS
BEGIN
	SELECT maloai, socuon
	FROM dbo.LoaiDG
	ORDER BY socuon
END
 GO
-- Tìm Độc giả dựa trên loại độc giả
CREATE PROC dbo.SelecReaders
@typeofreaders CHAR(6)
AS
BEGIN
	IF @typeofreaders IS NOT NULL
		SELECT madg, ten, sdt, dayblock, dayunblock
		FROM dbo.DocGia
		WHERE maloai = @typeofreaders
		ORDER BY ten
	ELSE
		SELECT madg, ten, sdt, dayblock, dayunblock, LoaiDG.maloai, socuon
		FROM dbo.DocGia, dbo.LoaiDG
		WHERE DocGia.maloai = LoaiDG.maloai
		ORDER BY ten
END
 GO
-- Tìm nhà cung cấp 
CREATE PROC dbo.SelecSuppiers
AS
BEGIN
	SELECT manxb, ten, sdt, email, sdt, fax
	FROM dbo.NXB
	ORDER BY ten
END
 GO
-- Tìm phiếu nhập
CREATE PROC dbo.SelecReceiptNotes
AS
BEGIN
	SELECT ngaynhap
	FROM dbo.PhieuNhap
	ORDER BY ngaynhap DESC
END
 GO
-- Tìm phiếu nhập chưa giao
CREATE PROC dbo.SelecReceiptNotesNotDeliveryNotes
AS
BEGIN
	SELECT ngaynhap
	FROM dbo.PhieuNhap, dbo.TTPhieuNhap
	WHERE dbo.PhieuNhap.ngaynhap = dbo.TTPhieuNhap.mapn
	  AND dbo.TTPhieuNhap.mapg IS NULL
	GROUP BY ngaynhap
	ORDER BY ngaynhap DESC
END
 GO
-- Tìm chi tiết phiếu nhập
CREATE PROC dbo.SelecReceiptNote 
@ngaynhap DATETIME
AS
BEGIN
	SELECT DauSach.mads, DauSach.ten AS dausach, dongia, TTPhieuNhap.soluong, ngaygiao, mapg, NXB.ten AS nxb
	FROM dbo.TTPhieuNhap, dbo.DauSach, dbo.NXB
	WHERE TTPhieuNhap.mapn = @ngaynhap
	  AND TTPhieuNhap.mads = DauSach.mads
	  AND TTPhieuNhap.manxb = NXB.manxb
END
 GO
-- Tìm những phiếu nhập chưa giao của nhà cung cấp
CREATE PROC dbo.SelecReceiptNotesOfSupplier
@manxb CHAR(10)
AS
BEGIN
	SELECT mapn, DauSach.mads, ten AS dausach, dongia, TTPhieuNhap.soluong, ngaygiao
	FROM dbo.TTPhieuNhap, dbo.DauSach
	WHERE TTPhieuNhap.manxb = @manxb
	  AND TTPhieuNhap.mapg IS NULL
	  AND TTPhieuNhap.mads = DauSach.mads
END
 GO
-- Tìm phiếu giao
CREATE PROC dbo.SelecDeliveryNotes
AS
BEGIN
	SELECT ngaygiao
	FROM dbo.PhieuGiao
	ORDER BY ngaygiao DESC
END
 GO
-- Tìm chi tiết phiếu giao
CREATE PROC dbo.SelecDeliveryNote 
@ngaynhap DATETIME
AS
BEGIN
	SELECT mapn, DauSach.ten AS dausach, dongia, TTPhieuNhap.soluong, ngaygiao, NXB.ten AS nxb
	FROM dbo.TTPhieuNhap, dbo.DauSach, dbo.NXB
	WHERE TTPhieuNhap.mapg = @ngaynhap
	  AND TTPhieuNhap.mads = DauSach.mads
	  AND TTPhieuNhap.manxb = NXB.manxb
END
 GO
-- Tìm phiếu mượn
CREATE PROC dbo.SelecLendNotes
AS
BEGIN
	SELECT ngaymuon, DocGia.madg, ten, sdt
	FROM dbo.PhieuMuon, dbo.DocGia
	WHERE dbo.PhieuMuon.madg = dbo.DocGia.madg
	ORDER BY ngaymuon DESC
END
 GO
-- Tìm phiếu mượn mà chưa trả
CREATE PROC dbo.SelecLendNotesNotPayBackNotes
AS
BEGIN
	SELECT ngaymuon, DocGia.madg, ten, sdt
	FROM dbo.PhieuMuon, dbo.TTPhieuMuon, dbo.DocGia
	WHERE dbo.PhieuMuon.madg = dbo.DocGia.madg
	  AND dbo.PhieuMuon.ngaymuon = dbo.TTPhieuMuon.mapm
	  AND dbo.TTPhieuMuon.mapt IS NULL
	GROUP BY ngaymuon, DocGia.madg, ten, sdt
	ORDER BY ngaymuon DESC

END
 GO
-- Tìm chi tiết phiếu mượn
CREATE PROC dbo.SelecLendNote 
@ngaymuon DATETIME
AS
BEGIN
	SELECT ten AS dausach, songaytoida, stt, phat, mapt
	FROM dbo.TTPhieuMuon, dbo.DauSach
	WHERE TTPhieuMuon.mapm = @ngaymuon
	  AND TTPhieuMuon.mads = DauSach.mads
END
 GO
-- Tìm phiếu trả
CREATE PROC dbo.SelecPayBackNotes
AS
BEGIN
	SELECT ngaytra
	FROM dbo.PhieuTra
	ORDER BY ngaytra DESC
END
 GO
-- Tìm chi tiết phiếu trả
CREATE PROC dbo.SelecPayBackNote 
@ngaytra DATETIME
AS
BEGIN
	SELECT mapm, ten AS dausach, stt, phat
	FROM dbo.TTPhieuMuon, dbo.DauSach
	WHERE TTPhieuMuon.mapt = @ngaytra
	  AND TTPhieuMuon.mads = DauSach.mads
END
 GO
-- Sửa thông tin đầu sách
CREATE PROC dbo.UpdatTitleBook
@mads CHAR(10),
@ten NVARCHAR(100),
@soluong INT,
@songay TINYINT,
@tienphat BIGINT,
@giabia BIGINT,
@matl CHAR(6)
AS
BEGIN
	UPDATE dbo.DauSach
	SET ten = @ten, soluong = @soluong, songaytoida = @songay, sotienphat = @tienphat, giabia = @giabia, matl = @matl
	WHERE mads = @mads
END
 GO
-- Sửa thể loại đầu sách
CREATE PROC dbo.UpdatBookCategory
@matl CHAR(6),
@ten NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.TheLoai
	SET ten = @ten
	WHERE matl = @matl
END
 GO
-- Sửa trạng thái sách mất/ vẫn còn
CREATE PROC dbo.UpdatStatusBook
@mads CHAR(10),
@stt INT,
@status bit
AS
BEGIN
	UPDATE dbo.Sach
	SET lost = @status
	WHERE mads = @mads AND stt = @stt
END
 GO
-- Sửa thông tin độc giả
CREATE PROC dbo.UpdatReader 
@madg CHAR(10),
@ten NVARCHAR(100),
@sdt CHAR(10),
@loai CHAR(6)
AS
BEGIN
	UPDATE dbo.DocGia
	SET ten = @ten, sdt = @sdt, maloai = @loai
	WHERE madg = @madg
END
 GO
-- Thay đổi trạng thái của độc giả
CREATE PROC dbo.UpdatSttReader
@madg CHAR(10),
@khoa DATE,
@mo DATE
AS
BEGIN
	IF @khoa = '1/1/1'

	UPDATE dbo.DocGia
	SET dayblock = null, dayunblock = null
	WHERE madg = @madg 
	
	UPDATE dbo.DocGia
	SET dayblock = @khoa, dayunblock = @mo 
	WHERE madg = @madg
END
 GO
-- Sửa thông tin của nhà cung cấp
CREATE PROC dbo.UpdatSupplier
@manxb CHAR(10),
@ten NVARCHAR(100),
@email VARCHAR(100),
@sdt VARCHAR(11),
@fax VARCHAR(100)
AS
BEGIN
	UPDATE dbo.NXB
	SET ten = @ten, email = @email, sdt = @sdt, fax = @fax
	WHERE manxb = @manxb
END
 GO
-- Sửa thông tin chi tiết phiếu nhập
CREATE PROC dbo.UpdatDetailReceiptNote
@ngaynhap DATETIME,
@dausach CHAR(10),
@dongia BIGINT,
@soluong INT,
@ngayhen DATE
AS
BEGIN
	UPDATE TTPhieuNhap
	SET dongia = @dongia, soluong = @soluong, ngaygiao = @ngayhen
	WHERE mapn = @ngaynhap
	  AND mads = @dausach
END
 GO
-- Thêm một sách mới cho một đầu sách
CREATE PROC dbo.InserBook
@mads CHAR(10),
@stt INT
AS
BEGIN
	INSERT INTO Sach
	VALUES (@mads,@stt,0)
END
 GO
-- Thêm một đầu sách mới 
CREATE PROC dbo.InserTitle
@ten NVARCHAR(100),
@soluong INT, 
@songaytoida TINYINT,
@sotienphat BIGINT,
@giabia BIGINT, 
@matl CHAR(6)
AS
BEGIN
	INSERT INTO DauSach( mads, ten, soluong, songaytoida, sotienphat, giabia, matl)
	VALUES ( dbo.Auto_IDDS(), @ten, @soluong, @songaytoida, @sotienphat, @giabia, @matl)
END
 GO
-- Thêm một thể loại mới
CREATE PROC dbo.InserBookCategory
@ten NVARCHAR(100)
AS
BEGIN
	INSERT INTO TheLoai(matl, ten)
	VALUES (dbo.Auto_IDTL(), @ten)
END
 GO
-- Thêm một độc giả
CREATE PROC dbo.InserReader
@ten NVARCHAR(100),
@sdt CHAR(10),
@maloai CHAR(6)
AS
BEGIN
	INSERT INTO DocGia(madg, ten, sdt, maloai)
	VALUES(dbo.Auto_IDDG(), @ten, @sdt, @maloai)
END
 GO
-- Thêm một nhà cung cấp
CREATE PROC dbo.InserSupplier
@ten NVARCHAR(100),
@email VARCHAR(100),
@sdt VARCHAR(11),
@fax VARCHAR(100)
AS
BEGIN
	INSERT INTO NXB(manxb, ten, email, sdt, fax)
	VALUES(dbo.Auto_IDNXB(), @ten, @email, @sdt, @fax)
END
 GO
-- Thêm một phiếu nhập
CREATE PROC dbo.InserReceiptNote
@ngaynhap DATETIME
AS
BEGIN
	INSERT INTO PhieuNhap
	VALUES(@ngaynhap)
END
 GO
-- Thêm chi tiết phiếu nhập
CREATE PROC dbo.InserDetailReceiptNote
@mapn DATETIME,
@mads CHAR(10),
@dongia BIGINT,
@soluong INT,
@ngaygiao DATE,
@manxb CHAR(10)
AS
BEGIN
	INSERT INTO TTPhieuNhap(mapn, mads, dongia, soluong, ngaygiao, manxb)
	VALUES(@mapn, @mads, @dongia, @soluong, @ngaygiao, @manxb)
END
 GO
-- Thêm một phiếu giao
CREATE PROC dbo.InserDeliveryNote
@ngaygiao DATETIME
AS
BEGIN
	INSERT INTO PhieuGiao
	VALUES(@ngaygiao)
END
 GO
-- Thêm chi tiết phiếu giao
CREATE PROC dbo.InserDetailDeliveryNote
@mapn DATETIME,
@dausach CHAR(10),
@mapg DATETIME
AS
BEGIN
	UPDATE dbo.TTPhieuNhap
	SET mapg = @mapg
	WHERE mapn = @mapn AND mads = @dausach
END
 GO
-- Thêm một phiếu mượn
CREATE PROC dbo.InserLendNote
@ngaymuon DATETIME,
@docgia CHAR(10)
AS
BEGIN
	INSERT INTO PhieuMuon
	VALUES(@ngaymuon, @docgia)
END
 GO
-- Thêm một chi tiết phiếu mượn
CREATE PROC dbo.InserDetailLendNote
@ngaymuon DATETIME,
@dausach CHAR(10),
@stt INT
AS
BEGIN
	INSERT INTO TTPhieuMuon(mapm, mads, stt)
	VALUES(@ngaymuon, @dausach, @stt)
END
 GO
-- Thêm một phiếu trả
CREATE PROC dbo.InserPayBackNote 
@ngaytra DATETIME
AS
BEGIN
	INSERT INTO PhieuTra
	VALUES(@ngaytra)
END
 GO
-- Thêm một chi tiết phiếu trả
CREATE PROC dbo.InserDetailPayBackNote
@ngaymuon DATETIME,
@dausach CHAR(10),
@stt INT,
@ngaytra DATETIME
AS
BEGIN
	UPDATE dbo.TTPhieuMuon
	SET mapt = @ngaytra
	WHERE mapm = @ngaymuon
	  AND mads = @dausach
	  AND stt = @stt
END
 GO
-- Xóa một đầu sách 
CREATE PROC dbo.DeletTitleBook
@mads CHAR(10)
AS
BEGIN
	DELETE FROM DauSach
	WHERE mads = @mads
END
 GO
-- Xóa một sách cho một đầu sách
CREATE PROC dbo.DeletBook
@mads CHAR(10),
@stt INT
AS
BEGIN
	DELETE FROM Sach
	WHERE mads = @mads AND stt = @stt
END
 GO
-- Xóa tất cả sách cho một đầu sách
CREATE PROC dbo.DeletAllBooks
@mads CHAR(10)
AS
BEGIN
	DELETE FROM Sach
	WHERE mads = @mads
END
 GO
 -- Xóa phiếu nhập
CREATE PROC dbo.DeletReceiptNote 
@ngaynhap DATETIME
AS
BEGIN
	DELETE FROM PhieuNhap
	WHERE ngaynhap = @ngaynhap
END
 GO
-- Xóa 1 chi tiết phiếu nhập
CREATE PROC dbo.DeletDetailReceiptNote
@ngaynhap DATETIME,
@dausach CHAR(10)
AS
BEGIN
	DELETE FROM TTPhieuNhap
	WHERE mapn = @ngaynhap
	  AND mads = @dausach
END
 GO
-- Đếm số lượng sách mượn
CREATE PROC dbo.CountBookIsLend
@docgia CHAR(10)
AS
BEGIN
	SELECT COUNT(*)
	FROM PhieuMuon, TTPhieuMuon
	WHERE madg = @docgia
	  AND ngaymuon = mapm
	  AND mapt IS NULL
END
 GO
---- Tạo function ----
-- Sinh mã đầu sách
CREATE FUNCTION dbo.Auto_IDDS()
RETURNS CHAR(10)
AS
BEGIN
	DECLARE @id CHAR(10)
	IF (SELECT COUNT(mads) FROM DauSach) = 0
		SET @id = '0'
	ELSE 
		SELECT @id = MAX(RIGHT(mads, 8)) FROM DauSach
	SELECT @id = CASE
		WHEN @id >= 0 AND @id < 9 THEN 'DS0000000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9 AND @id < 99 THEN 'DS000000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 99 AND @id < 999 THEN 'DS00000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 999 AND @id < 9999 THEN 'DS0000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9999 AND @id < 99999 THEN 'DS000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 99999 AND @id < 999999 THEN 'DS00' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 999999 AND @id < 9999999 THEN 'DS0' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9999999 THEN 'DS' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
	END
	RETURN @id
END
 GO
-- Sinh mã thể loại
CREATE FUNCTION dbo.Auto_IDTL()
RETURNS CHAR(6)
AS
BEGIN
	DECLARE @id CHAR(6)
	IF (SELECT COUNT(matl) FROM TheLoai) = 0
		SET @id = '0'
	ELSE
		SELECT @id = MAX(RIGHT(matl, 4)) FROM TheLoai
	SELECT @id = CASE
		WHEN @id >= 0 AND @id < 9 THEN 'TL000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9 AND @id < 99 THEN 'TL00' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 99 AND @id < 999 THEN 'TL0' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 999 THEN 'TL' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
	END
	RETURN @id
END
 GO
-- Sinh mã độc giả
CREATE FUNCTION dbo.Auto_IDDG()
RETURNS CHAR(10)
AS
BEGIN
	DECLARE @id CHAR(10)
	IF (SELECT COUNT(madg) FROM DocGia) = 0
		SET @id = '0'
	ELSE 
		SELECT @id = MAX(RIGHT(madg, 8)) FROM DocGia
	SELECT @id = CASE
		WHEN @id >= 0 AND @id < 9 THEN 'DG0000000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9 AND @id < 99 THEN 'DG000000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 99 AND @id < 999 THEN 'DG00000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 999 AND @id < 9999 THEN 'DG0000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9999 AND @id < 99999 THEN 'DG000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 99999 AND @id < 999999 THEN 'DG00' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 999999 AND @id < 9999999 THEN 'DG0' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9999999 THEN 'DG' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
	END
	RETURN @id
END
 GO
-- Sinh mã nhà cung cấp
CREATE FUNCTION dbo.Auto_IDNXB()
RETURNS CHAR(10)
AS
BEGIN
	DECLARE @id CHAR(10)
	IF (SELECT COUNT(manxb) FROM NXB) = 0
		SET @id = '0'
	ELSE 
		SELECT @id = MAX(RIGHT(manxb, 8)) FROM NXB
	SELECT @id = CASE
		WHEN @id >= 0 AND @id < 9 THEN 'NX0000000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9 AND @id < 99 THEN 'NX000000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 99 AND @id < 999 THEN 'NX00000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 999 AND @id < 9999 THEN 'NX0000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9999 AND @id < 99999 THEN 'NX000' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 99999 AND @id < 999999 THEN 'NX00' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 999999 AND @id < 9999999 THEN 'NX0' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
		WHEN @id >= 9999999 THEN 'NX' + CONVERT(CHAR, CONVERT(INT, @id) + 1)
	END
	RETURN @id
END
 GO
/*
use ReportServer$TVHUY
*/