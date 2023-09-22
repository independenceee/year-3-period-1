USE [BT2]

-- 1. Tạo View danh sách sinh viên, gồm các thông tin sau: Mã sinh viên, Họ sinh viên, Tên sinh viên, Học bổng.

GO
CREATE VIEW CAU_1 AS
SELECT MaSV, HoSV, TenSV, HocBong FROM DSSinhVien;
GO
SELECT * FROM CAU_1;


-- 2. Tạo view Liệt kê các sinh viên có học bổng từ 150,000 trở lên và sinh ở Hà Nội, gồm các thông tin: Họ tên sinh viên, Mã khoa, Nơi sinh, Học bổng.

GO 
CREATE VIEW CAU_2 AS 
SELECT DSSinhVien.HoSV, DSSinhVien.TenSV, DSSinhVien.MaKhoa, DSSinhVien.NoiSinh, DSSinhVien.HocBong FROM DSSinhVien
WHERE DSSinhVien.HocBong >= 150000 AND DSSinhVien.NoiSinh = N'Hà Nội'
GO
SELECT * FROM CAU_2;

-- 3. Tạo view liệt kê những sinh viên nam của khoa Anh văn và khoa tin học, gồm các thông tin: Mã sinh viên, Họ tên sinh viên, tên khoa, Phái.

GO
CREATE VIEW CAU_3 AS
SELECT DSSinhVien.MaSV, DSSinhVien.HoSV, DSSinhVien.TenSV, DMKhoa.TenKhoa , DSSinhVien.Phai
FROM DSSinhVien 
JOIN DMKhoa ON DSSinhVien.MaKhoa = DMKhoa.MaKhoa
WHERE (DMKhoa.TenKhoa = N'Anh văn' OR DMKhoa.TenKhoa = N'Tin học') AND DSSinhVien.Phai = N'Nam'
GO 
SELECT * FROM CAU_3;

-- 4. Tạo view gồm những sinh viên có tuổi từ 20 đến 25, thông tin gồm: Họ tên sinh viên, Tuổi, Tên khoa.

GO
CREATE VIEW CAU_4 AS


GO
SELECT * FROM CAU_4;

-- 5. Tạo view cho biết thông tin về mức học bổng của các sinh viên, gồm: Mã sinh viên, Phái, Mã khoa, Mức học bổng. Trong đó, mức học bổng sẽ hiển thị là “Học bổng cao” nếu giá trị của field học bổng lớn hơn 500,000 và ngược lại hiển thị là “Mức trung bình”

GO
CREATE VIEW CAU_5 AS
SELECT DSSinhVien.MaSV, DSSinhVien.Phai, DSSinhVien.MaKhoa,
( CASE WHEN DSSinhVien.HocBong > 500000 THEN N'Học bổng cao' ELSE N'Mức trung bình' END) AS MucHocBong
FROM DSSinhVien WHERE DSSinhVien.HocBong > 0
Go
SELECT * FROM CAU_5;

-- 6. Tạo view đưa ra thông tin những sinh viên có học bổng lớn hơn bất kỳ học bổng của sinh viên học khóa anh văn

GO
CREATE VIEW CAU_6 AS
SELECT * FROM DSSinhVien 
JOIN DMKhoa ON DSSinhVien.MaKhoa = DMKhoa.MaKhoa
WHERE DSSinhVien.HocBong > (
	SELECT TOP 1 DSSinhVien.HocBong 
	FROM DSSinhVien 
	JOIN DMKhoa ON DSSinhVien.MaKhoa = DMKhoa.MaKhoa
	WHERE DMKhoa.TenKhoa = N'Anh Văn'
	ORDER BY DSSinhVien.HocBong DESC
)
GO
SELECT * FROM CAU_6;



-- 7. Tạo view đưa ra thông tin những sinh viên đạt điểm cao nhất trong từng môn.

GO
CREATE VIEW CAU_7 AS


GO
SELECT * FROM CAU_7;

-- 8. Tạo view đưa ra những sinh viên chưa thi môn cơ sở dữ liệu.

GO
CREATE VIEW CAU_8 AS
SELECT * FROM DSSinhVien
WHERE DSSinhVien.MaSV NOT IN (
	SELECT KetQua.MaSV FROM KetQua
	WHERE KetQua.MaMH = 01
	GROUP BY KetQua.MaSV
)
GO
SELECT * FROM CAU_8;

-- 9. Tạo view đưa ra thông tin những sinh viên không trượt môn nào.

GO
CREATE VIEW CAU_9 AS
SELECT * FROM DSSinhVien
WHERE MaSV NOT IN (
	SELECT KetQua.MaSV FROM KetQua
	WHERE KetQua.Diem < 4
	GROUP BY KetQua.MaSV
)
GO
SELECT * FROM CAU_9