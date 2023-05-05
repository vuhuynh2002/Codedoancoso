Create Database Shopper
go
use Shopper
go

Create Table Categories(
	cateID int identity(1,1) primary key,
	cateName Nvarchar(100),
	catePhoto Nvarchar(MAX)
)
go
Create Table ProductTypes(
	typeID int identity(1,1) primary key,
	cateID int FOREIGN KEY REFERENCES Categories(cateID),
	typeName Nvarchar(100)
)
go
Create Table Producers(
	pdcID int identity(1,1) primary key,
	pdcName Nvarchar(100),
	pdcPhone varchar(20),
	pdcEmail varchar(50),
	pdcAddress Nvarchar(MAX),
	pdcPhoto Nvarchar(MAX),
	pdcInfo Nvarchar(MAX)
)
go
Create Table Products(
	proID varchar(50) primary key,
	pdcID int FOREIGN KEY REFERENCES Producers(pdcID),
	typeID int FOREIGN KEY REFERENCES ProductTypes(typeID),
	proName Nvarchar(200),
	proSize varchar(10),
	proPrice varchar(10),
	proDiscount int,
	proPhoto Nvarchar(MAX),
	proUpdateDate varchar(50),
	proDescription Nvarchar(MAX)
)
go
Create Table Administrator(
	adAcc varchar(500) primary key,
	adPass varchar(500)
)
go
Create Table Customers(
	cusPhone varchar(20) primary key,
	cusFullName Nvarchar(200),
	cusEmail varchar(100),
	cusAddress Nvarchar(500)
)
go
Create Table Orders(
	orderID varchar(20) primary key,
	cusPhone varchar(20) FOREIGN KEY REFERENCES Customers(cusPhone),
	orderMessage Nvarchar(MAX),
	orderDateTime varchar(50),
	orderStatus Nvarchar(50)
)
go
Create Table OrderDetails(
	orderID varchar(20) FOREIGN KEY REFERENCES Orders(orderID),
	proID varchar(50) FOREIGN KEY REFERENCES Products(proID),
	ordtsQuantity int,
	ordtsThanhTien varchar(50),
	Constraint PK_OrderDetails Primary key (orderID, proID)
)
go
Create Table Rates(
	proID varchar(50) FOREIGN KEY REFERENCES Products(proID),
	rateStar int
	Constraint PK_Rates Primary key (proID)
)
go
Create Table Comments(
	commentID int identity(1,1) primary key,
	proID varchar(50) FOREIGN KEY REFERENCES Products(proID),
	commentMessage Nvarchar(MAX)
)
go
--Insert table Administrator
Insert into Administrator values('vutung','Z8iwc6Uz2M+EpI1l6kLxPQ==')
--Insert table Categories
Insert into Categories values(N'Quần-áo', N'/Image/img (7).jpg')
Insert into Categories values(N'Giày-dép', N'/Image/img (23).jpg')
Insert into Categories values(N'Mũ(nón)', N'/Image/img (4).png')
--Insert table ProductTypes
Insert into ProductTypes values(1, N'Quần thun')
Insert into ProductTypes values(1, N'Áo thun')
Insert into ProductTypes values(1, N'Quần kaki')
Insert into ProductTypes values(1, N'Áo sơ mi')
Insert into ProductTypes values(1, N'Áo khoác')
Insert into ProductTypes values(1, N'Đồ bộ')
Insert into ProductTypes values(1, N'Đồ công sở')
Insert into ProductTypes values(1, N'Đồ ngủ')
Insert into ProductTypes values(1, N'Đồ lót')
Insert into ProductTypes values(2, N'Giày thể thao')
Insert into ProductTypes values(2, N'Giày thời trang')
Insert into ProductTypes values(2, N'Dép lê')
Insert into ProductTypes values(2, N'Dép có quai')
Insert into ProductTypes values(3, N'Mũ thời trang')
Insert into ProductTypes values(3, N'Mũ bảo hiểm')
--Insert table Producers
Insert into Producers values(N'Adidas','01212692802','adidas@gmail.com',N'TpHCM',N'/Image/img (2).png',N'Thông tin tự gút gồ')
Insert into Producers values(N'FILA','01212692802','fila@gmail.com',N'TpHCM',N'/Image/img (3).png',N'Thông tin tự gút gồ')
Insert into Producers values(N'Versage','01212692802','versage@gmail.com',N'TpHCM',N'/Image/img (5).jpg',N'Thông tin tự gút gồ')
Insert into Producers values(N'Chanel','01212692802','chanel@gmail.com',N'TpHCM',N'/Image/img (15).jpg',N'Thông tin tự gút gồ')
Insert into Producers values(N'D&G','01212692802','dg@gmail.com',N'TpHCM',N'/Image/img (18).jpg',N'Thông tin tự gút gồ')
Insert into Producers values(N'LV','01212692802','lv@gmail.com',N'TpHCM',N'/Image/img (21).jpg',N'Thông tin tự gút gồ')
Insert into Producers values(N'Nike','01212692802','nike@gmail.com',N'TpHCM',N'/Image/img (26).jpg',N'Thông tin tự gút gồ')
Insert into Producers values(N'Lacoste','01212692802','lacoste@gmail.com',N'TpHCM',N'/Image/img (30).jpg',N'Thông tin tự gút gồ')
--Insert table Products
Insert into Products values('MU001', 1, 14, N'Mũ phớt nam', 'M,S,L,...', '60000', 0, N'/Image/img (1).jpg', '10/01/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('MU002', 2, 14, N'Mũ thời trang kiểu xã hội đen', 'M,S,...', '82000', 0, N'/Image/img (20).jpg', '10/02/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('MU003', 3, 14, N'Mũ thời trang FILA (đen)', 'XL,L,...', '45000', 0, N'/Image/img (27).jpg', '10/03/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('MU004', 4, 15, N'Mũ bảo hiểm honda', 'S,M,...', '120000', 5, N'/Image/img (29).jpg', '10/04/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('CS001', 5, 7, N'Đầm công sở nữ', 'S,M,...', '320000', 10, N'/Image/img (2).jpg', '10/05/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('CS002', 6, 7, N'Đồ công sở quần dài', 'M,S,L', '230000', 5, N'/Image/img (4).jpg', '10/06/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('CS003', 3, 7, N'Kiểu dáng học sinh', 'M,S,...', '200000', 0, N'/Image/img (19).jpg', '10/07/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('AK001', 3, 5, N'Áo khoác nam', 'XL,XXL,L', '110000', 0, N'/Image/img (3).jpg', '10/08/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('AT001', 4, 2, N'Áo thun nữ sành điệu', 'S,M,L...', '80000', 0, N'/Image/img (8).jpg', '10/09/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('AT002', 3, 2, N'Áo body nam', 'L,XL,XXL', '130000', 0, N'/Image/img (12).jpg', '10/10/2017 6:43:36 AM', N'Không có mô tả')
Insert into Products values('AT003', 8, 2, N'Áo nữ 100% cotton', 'S,M,L...', '170000', 0, N'/Image/img (13).jpg', '10/11/2017 6:43:36 AM', N'Không có mô tả')
--Insert table Customers
Insert into Customers values('01234567891', N'Vũ Văn A', 'a@gmail.com', N'Nhà A')
Insert into Customers values('01234567892', N'Vũ Văn B', 'b@gmail.com', N'Nhà B')
Insert into Customers values('01234567893', N'Vũ Văn C', 'c@gmail.com', N'Nhà C')
Insert into Customers values('01234567894', N'Vũ Văn D', 'd@gmail.com', N'Nhà D')
Insert into Customers values('01234567895', N'Vũ Văn E', 'e@gmail.com', N'Nhà E')
--Insert table Rates
Insert into Rates values('MU001', 1)
Insert into Rates values('MU002', 2)
Insert into Rates values('MU003', 3)
Insert into Rates values('MU004', 4)
Insert into Rates values('CS001', 5)
Insert into Rates values('CS002', 1)
Insert into Rates values('CS003', 2)
Insert into Rates values('AK001', 3)
Insert into Rates values('AT001', 4)
Insert into Rates values('AT002', 5)
Insert into Rates values('AT003', 1)
--Insert table Comments
Insert into Comments values('MU001', N'đã đánh giá MU001')
Insert into Comments values('MU002', N'đã đánh giá MU002')
Insert into Comments values('MU003', N'đã đánh giá MU003')
Insert into Comments values('MU004', N'đã đánh giá MU004')
Insert into Comments values('CS001', N'đã đánh giá CS001')
Insert into Comments values('CS002', N'đã đánh giá CS002')
Insert into Comments values('CS003', N'đã đánh giá CS003')
Insert into Comments values('AK001', N'đã đánh giá AK001')
Insert into Comments values('AT001', N'đã đánh giá AT001')
Insert into Comments values('AT002', N'đã đánh giá AT002')
Insert into Comments values('AT003', N'đã đánh giá AT003')
--Insert table Orders
Insert into Orders values('HD1', '01234567891', 'Size: M', '11/20/2017 10:40:30 AM', N'0')
--Insert table OrderDetails
Insert into OrderDetails values('HD1', 'AT001', 2, '160000')
Insert into OrderDetails values('HD1', 'AT002', 1, '130000')
Insert into OrderDetails values('HD1', 'AT003', 1, '170000')