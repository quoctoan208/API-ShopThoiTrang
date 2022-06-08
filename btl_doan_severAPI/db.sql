create database Doan4_SHOP
go

use Doan4_SHOP
go

create table NGUOIDUNG
(
	Id varchar(15) primary key,
	useName varchar(50),
	passWord varchar(20),
	SDT text,
	diaChi nvarchar(max)
)
go

create table THELOAI
(
	maTL varchar(15) primary key,
	tenTL nvarchar(20),
)
go

create table SANPHAM
(
	maSP varchar(15) primary key,
	maTL varchar(15),
	tenSP nvarchar(100),
	donGia int,
	soLuong int,
	anh varchar(max),
	motaSP nvarchar(max),
	CONSTRAINT FK_maTheLoai_sanpham FOREIGN KEY(maTL) REFERENCES THELOAI(maTL)
)

create table GIOHANG
(
	ID varchar(15) primary key,
	maSP varchar(15),
	tenSP nvarchar(100),
	donGia int,
	soLuong int,
	anh varchar(max),
	tongTien int,
	CONSTRAINT FK_maSanPham_sanpham FOREIGN KEY(maSP) REFERENCES SANPHAM(maSP)
)


create table DONHANG
(
	maDH varchar(15) primary key,
	thoiGian DateTime,
	phiGiaoHang Float,
	ghiChu nvarchar(max),
	diaChiGuiHang nvarchar(max),
	tongTienThanhToan Float,
)

create table CHITIETDONHANG
(
	maDH varchar(15) primary key,
	useName varchar(50),
	maSP varchar(15),
	tenSP nvarchar(100),
	anh varchar(max),
	donGia int,
	soLuong int,
	tongTien int,
	CONSTRAINT FK_maDonHang_donhang FOREIGN KEY(maDH) REFERENCES DONHANG(maDH),
)



SELECT * FROM THELOAI
INSERT INTO THELOAI VALUES ('L01',N'Tập Gym')
INSERT INTO THELOAI VALUES ('L02',N'Bóng Đá')
INSERT INTO THELOAI VALUES ('L03',N'Bơi Lội')
INSERT INTO THELOAI VALUES ('L04',N'Tập Yoga')
INSERT INTO THELOAI VALUES ('L05',N'Tập Erobic')
INSERT INTO THELOAI VALUES ('L06',N'Khác')
INSERT INTO THELOAI VALUES ('L07',N'Thời Trang Nam')
INSERT INTO THELOAI VALUES ('L08',N'Thời Trang Nữ')
INSERT INTO THELOAI VALUES ('L09',N'Mũ')
INSERT INTO THELOAI VALUES ('L010',N'Túi & Balo')



SELECT * FROM sanpham
INSERT INTO sanpham VALUES ('SP01','L01',N'Áo quần tập gym phong cách',200000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/05/ACT11246-ACT-NAM-ICADO-AT15-5.jpg',N'Quần áo đẹp phong cách')

INSERT INTO sanpham VALUES ('SP02','L01',N'Áo Bra Tập Gym Yoga Nữ Dệt HN35',250000,5,
'https://thegioidotap.vn/wp-content/uploads/2020/12/quan-lung-yoga-nu-ql17.jpg',N'Chất liệu: 88% Polyester, 12% spandex, co giãn 4 chiều')

INSERT INTO sanpham VALUES ('SP03','L01',N'Áo Bra Tập Gym Yoga Nữ Dệt HN33',100000,6,
'https://thegioidotap.vn/wp-content/uploads/2021/11/ao-bra-tap-gym-yoga-nu-det-hn334.png',N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện
Thấm hút mồ hôi, thoáng mát và khử mùi tốt
Chống tia UV cực tốt, bảo vệ da, không bị kích ứng
Phong cách althei-sure năng động')

INSERT INTO sanpham VALUES ('SP04','L01',N'Set Đồ Tập Nữ Áo Bra HN33 Quần Dài Icado QD26',250000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/10/set-do-tap-nu-ao-bra-hn33-quan-dai-icado-qd261.jpg',N'Chất liệu: 88% Polyester, 12% spandex
Sợi vải coolmax. Làm mát và thoáng khí x2 lần
Đường may: 4 kim tinh tế, sắc sảo
Áo Croptop AT3 in logo dưới ngực trái phong cách trẻ trung năng động. Kết hợp với quần dài tập gym nữ không kém phần cá tính và nổi bật')

INSERT INTO sanpham VALUES ('SP05','L01',N'Set Đồ Tập Nữ Áo Croptop Icado AT3 + Quần Jogger Icado SG11
',200000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/06/set-do-tap-nu-ao-croptop-icado-at3-quan-jogger-icado-sg11-2.jpg',N'Quần áo đẹp phong cách')

INSERT INTO sanpham VALUES ('SP06','L01',N'Quần dài tập gym yoga nữ ICADO phối lưới QD-38',100000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/05/ArtboarQ.DAI-NU-ICADO-PHOI-LUOI-QD-38d-1.jpg',N'Quần áo đẹp phong cách')


INSERT INTO sanpham VALUES ('SP07','L01',N'Quần Đùi Tập Gym Yoga nữ ICADO phối lưới QL5',100000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/05/QN21247-Q.DUI-NU-ICADO-PHOI-LUOI-QL5.jpg',N'Quần áo đẹp phong cách')


INSERT INTO sanpham VALUES ('SP08','L01',N'Áo Tanktop Tập Gym Yoga Nữ Icado SG2',100000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/06/TANKTOP-ICADO-SG2-8.png',N'Quần áo đẹp phong cách')


INSERT INTO sanpham VALUES ('SP09','L01',N'Áo Ngắn Tay Nữ ICADO dây rút AT8',100000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/03/Ao-Ngan-Tay-Nu-ICADO-day-rut-AT8.jpg',N'Quần áo đẹp phong cách')


--1
INSERT INTO sanpham VALUES ('SP10','L04',N'Áo TankTop Tập Gym Yoga nam ICADO AT2',250000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/06/SET-TAP-GYM-YOGA-NAM-TANKTOP-ICADO-AT2-QUAN-SHORT-THE-THAO-ICADO-AT9-3.png',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--2
INSERT INTO sanpham VALUES ('SP11','L04',N'Áo ngắn tay tập gym yoga nam AT15',295000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/05/ACT11246-ACT-NAM-ICADO-AT15-5.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--3
INSERT INTO sanpham VALUES ('SP12','L04',N'Áo ngắn tay tập gym yoga Nam PAVO AT4',280000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/03/Untitled-Session20941.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')


--4
INSERT INTO sanpham VALUES ('SP13','L04',N'Áo Ngắn Tay Thể Thao nam Icado AH1',275000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/01/ao-thun-the-thao-nam-ah1-4-2.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--5
INSERT INTO sanpham VALUES ('SP14','L04',N'Áo Bra tập gym yoga nữ Dệt CH14',265000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/05/BR21237-BRA-DET-CH14.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')


--6
INSERT INTO sanpham VALUES ('SP15','L04',N'Áo Tanktop Tập Gym Yoga nữ lưới sport life HN4',265000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/03/1.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--7
INSERT INTO sanpham VALUES ('SP16','L04',N'Áo Ngắn Tay Tập Gym Yoga nữ ICADO Cổ Thuyền AT6',265000,5,
'https://thegioidotap.vn/wp-content/uploads/2020/12/ao-thun-yoga-nu-at6.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--8
INSERT INTO sanpham VALUES ('SP17','L04',N'Áo Tanktop Tập Gym Yoga nữ Lưới HN2',265000,5,
'https://thegioidotap.vn/wp-content/uploads/2020/12/ao-tanktop-tap-gym-yoga-nu-li-hn2.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--9
INSERT INTO sanpham VALUES ('SP18','L04',N'Quần Lửng Thể Thao nữ ICADO Phối Lưới QL20',265000,5,
'https://thegioidotap.vn/wp-content/uploads/2020/12/quan-lung-the-thao-nu-icado-phoi-luoi-ql20.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--10
INSERT INTO sanpham VALUES ('SP19','L04',N'Quần Lửng Thể Thao nữ ICADO Phối Lưới QL17',265000,5,
'https://thegioidotap.vn/wp-content/uploads/2020/12/quan-lung-yoga-nu-ql17.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--11
INSERT INTO sanpham VALUES ('SP20','L04',N'Áo Tanktop Tập Gym Yoga nữ lưới sport life HN4',260000,5,
'https://thegioidotap.vn/wp-content/uploads/2021/03/1.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')

--12
INSERT INTO sanpham VALUES ('SP21','L04',N'Áo Ngắn Tay Tập Gym Yoga nữ ICADO Cổ Thuyền AT6',215000,5,
'https://thegioidotap.vn/wp-content/uploads/2020/12/ao-thun-yoga-nu-at6.jpg',
N'Co giãn 4 chiều, tăng độ đàn hồi bảo vệ cơ khi tập luyện')
go
--------

--1.get sản phẩm 
create function Getsanpham()
returns table
as
return select * from SANPHAM
go

--2.get sản phẩm theo mã
create function Getsanphamtheoma(@ma varchar(15))
returns table 
as 
    return select * from SANPHAM where SANPHAM.maSP=@ma
go

--3.get sản phẩm theo tên
create function Getsanphamthepthen(@tensp nvarchar(30))
returns table 
as 
    return select * from SANPHAM where SANPHAM.tenSP like N'%'+@tensp+'%'
go

--4.get đơn hàng 
create function Getdonhang()
returns table
as
return select * from DONHANG
go

--5.get đơn hàng theo mã
create function Getdonhangtheoma(@madh varchar(15))
returns table 
as 
    return select * from DONHANG where DONHANG.maDH=@madh
go

