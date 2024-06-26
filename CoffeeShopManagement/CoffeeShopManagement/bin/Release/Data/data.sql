USE [master]
GO
/****** Object:  Database [CoffeeShopManagement]    Script Date: 26-05-2024 8:32:22 CH ******/
CREATE DATABASE [CoffeeShopManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoffeeShopManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CoffeeShopManagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CoffeeShopManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CoffeeShopManagement_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CoffeeShopManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoffeeShopManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoffeeShopManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CoffeeShopManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoffeeShopManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoffeeShopManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CoffeeShopManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoffeeShopManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [CoffeeShopManagement] SET  MULTI_USER 
GO
ALTER DATABASE [CoffeeShopManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoffeeShopManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoffeeShopManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoffeeShopManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CoffeeShopManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CoffeeShopManagement', N'ON'
GO
USE [CoffeeShopManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] 
(
    @strInput NVARCHAR(4000)
) 
RETURNS NVARCHAR(4000)
AS 
BEGIN 
    IF @strInput IS NULL RETURN @strInput 
    IF @strInput = '' RETURN @strInput 

    DECLARE @Result NVARCHAR(4000)
    SET @Result = @strInput

    -- Replace accented characters with their unaccented counterparts
    SET @Result = REPLACE(@Result, N'ă', 'a')
    SET @Result = REPLACE(@Result, N'â', 'a')
    SET @Result = REPLACE(@Result, N'đ', 'd')
    SET @Result = REPLACE(@Result, N'ê', 'e')
    SET @Result = REPLACE(@Result, N'ô', 'o')
    SET @Result = REPLACE(@Result, N'ơ', 'o')
    SET @Result = REPLACE(@Result, N'ư', 'u')
    SET @Result = REPLACE(@Result, N'à', 'a')
    SET @Result = REPLACE(@Result, N'ả', 'a')
    SET @Result = REPLACE(@Result, N'ã', 'a')
    SET @Result = REPLACE(@Result, N'ạ', 'a')
    SET @Result = REPLACE(@Result, N'á', 'a')
    SET @Result = REPLACE(@Result, N'ằ', 'a')
    SET @Result = REPLACE(@Result, N'ẳ', 'a')
    SET @Result = REPLACE(@Result, N'ẵ', 'a')
    SET @Result = REPLACE(@Result, N'ặ', 'a')
    SET @Result = REPLACE(@Result, N'ắ', 'a')
    SET @Result = REPLACE(@Result, N'ầ', 'a')
    SET @Result = REPLACE(@Result, N'ẩ', 'a')
    SET @Result = REPLACE(@Result, N'ẫ', 'a')
    SET @Result = REPLACE(@Result, N'ậ', 'a')
    SET @Result = REPLACE(@Result, N'ấ', 'a')
    SET @Result = REPLACE(@Result, N'è', 'e')
    SET @Result = REPLACE(@Result, N'ẻ', 'e')
    SET @Result = REPLACE(@Result, N'ẽ', 'e')
    SET @Result = REPLACE(@Result, N'ẹ', 'e')
    SET @Result = REPLACE(@Result, N'é', 'e')
    SET @Result = REPLACE(@Result, N'ề', 'e')
    SET @Result = REPLACE(@Result, N'ể', 'e')
    SET @Result = REPLACE(@Result, N'ễ', 'e')
    SET @Result = REPLACE(@Result, N'ệ', 'e')
    SET @Result = REPLACE(@Result, N'ế', 'e')
    SET @Result = REPLACE(@Result, N'ì', 'i')
    SET @Result = REPLACE(@Result, N'ỉ', 'i')
    SET @Result = REPLACE(@Result, N'ĩ', 'i')
    SET @Result = REPLACE(@Result, N'ị', 'i')
    SET @Result = REPLACE(@Result, N'í', 'i')
    SET @Result = REPLACE(@Result, N'ò', 'o')
    SET @Result = REPLACE(@Result, N'ỏ', 'o')
    SET @Result = REPLACE(@Result, N'õ', 'o')
    SET @Result = REPLACE(@Result, N'ọ', 'o')
    SET @Result = REPLACE(@Result, N'ó', 'o')
    SET @Result = REPLACE(@Result, N'ồ', 'o')
    SET @Result = REPLACE(@Result, N'ổ', 'o')
    SET @Result = REPLACE(@Result, N'ỗ', 'o')
    SET @Result = REPLACE(@Result, N'ộ', 'o')
    SET @Result = REPLACE(@Result, N'ố', 'o')
    SET @Result = REPLACE(@Result, N'ờ', 'o')
    SET @Result = REPLACE(@Result, N'ở', 'o')
	SET @Result = REPLACE(@Result, N'ỡ', 'o')
    SET @Result = REPLACE(@Result, N'ợ', 'o')
    SET @Result = REPLACE(@Result, N'ớ', 'o')
    SET @Result = REPLACE(@Result, N'ù', 'u')
    SET @Result = REPLACE(@Result, N'ủ', 'u')
    SET @Result = REPLACE(@Result, N'ũ', 'u')
    SET @Result = REPLACE(@Result, N'ụ', 'u')
    SET @Result = REPLACE(@Result, N'ú', 'u')
    SET @Result = REPLACE(@Result, N'ừ', 'u')
    SET @Result = REPLACE(@Result, N'ử', 'u')
    SET @Result = REPLACE(@Result, N'ữ', 'u')
    SET @Result = REPLACE(@Result, N'ự', 'u')
    SET @Result = REPLACE(@Result, N'ứ', 'u')
    SET @Result = REPLACE(@Result, N'ỳ', 'y')
    SET @Result = REPLACE(@Result, N'ỷ', 'y')
    SET @Result = REPLACE(@Result, N'ỹ', 'y')
    SET @Result = REPLACE(@Result, N'ỵ', 'y')
    SET @Result = REPLACE(@Result, N'ý', 'y')

    -- Uppercase letters
    SET @Result = REPLACE(@Result, N'Ă', 'A')
    SET @Result = REPLACE(@Result, N'Â', 'A')
    SET @Result = REPLACE(@Result, N'Đ', 'D')
    SET @Result = REPLACE(@Result, N'Ê', 'E')
    SET @Result = REPLACE(@Result, N'Ô', 'O')
    SET @Result = REPLACE(@Result, N'Ơ', 'O')
    SET @Result = REPLACE(@Result, N'Ư', 'U')
    SET @Result = REPLACE(@Result, N'À', 'A')
    SET @Result = REPLACE(@Result, N'Ả', 'A')
    SET @Result = REPLACE(@Result, N'Ã', 'A')
    SET @Result = REPLACE(@Result, N'Ạ', 'A')
    SET @Result = REPLACE(@Result, N'Á', 'A')
    SET @Result = REPLACE(@Result, N'Ằ', 'A')
    SET @Result = REPLACE(@Result, N'Ẳ', 'A')
    SET @Result = REPLACE(@Result, N'Ẵ', 'A')
    SET @Result = REPLACE(@Result, N'Ặ', 'A')
    SET @Result = REPLACE(@Result, N'Ắ', 'A')
    SET @Result = REPLACE(@Result, N'Ầ', 'A')
    SET @Result = REPLACE(@Result, N'Ẩ', 'A')
    SET @Result = REPLACE(@Result, N'Ẫ', 'A')
    SET @Result = REPLACE(@Result, N'Ậ', 'A')
    SET @Result = REPLACE(@Result, N'Ấ', 'A')
    SET @Result = REPLACE(@Result, N'È', 'E')
    SET @Result = REPLACE(@Result, N'Ẻ', 'E')
    SET @Result = REPLACE(@Result, N'Ẽ', 'E')
    SET @Result = REPLACE(@Result, N'Ẹ', 'E')
    SET @Result = REPLACE(@Result, N'É', 'E')
    SET @Result = REPLACE(@Result, N'Ề', 'E')
    SET @Result = REPLACE(@Result, N'Ể', 'E')
    SET @Result = REPLACE(@Result, N'Ễ', 'E')
    SET @Result = REPLACE(@Result, N'Ệ', 'E')
    SET @Result = REPLACE(@Result, N'Ế', 'E')
    SET @Result = REPLACE(@Result, N'Ì', 'I')
    SET @Result = REPLACE(@Result, N'Ỉ', 'I')
    SET @Result = REPLACE(@Result, N'Ĩ', 'I')
    SET @Result = REPLACE(@Result, N'Ị', 'I')
    SET @Result = REPLACE(@Result, N'Í', 'I')
    SET @Result = REPLACE(@Result, N'Ò', 'O')
    SET @Result = REPLACE(@Result, N'Ỏ', 'O')
    SET @Result = REPLACE(@Result, N'Õ', 'O')
	 SET @Result = REPLACE(@Result, N'Ọ', 'O')
    SET @Result = REPLACE(@Result, N'Ó', 'O')
    SET @Result = REPLACE(@Result, N'Ồ', 'O')
    SET @Result = REPLACE(@Result, N'Ổ', 'O')
    SET @Result = REPLACE(@Result, N'Ỗ', 'O')
    SET @Result = REPLACE(@Result, N'Ộ', 'O')
    SET @Result = REPLACE(@Result, N'Ố', 'O')
    SET @Result = REPLACE(@Result, N'Ờ', 'O')
    SET @Result = REPLACE(@Result, N'Ở', 'O')
    SET @Result = REPLACE(@Result, N'Ỡ', 'O')
    SET @Result = REPLACE(@Result, N'Ợ', 'O')
    SET @Result = REPLACE(@Result, N'Ớ', 'O')
    SET @Result = REPLACE(@Result, N'Ù', 'U')
    SET @Result = REPLACE(@Result, N'Ủ', 'U')
    SET @Result = REPLACE(@Result, N'Ũ', 'U')
    SET @Result = REPLACE(@Result, N'Ụ', 'U')
    SET @Result = REPLACE(@Result, N'Ú', 'U')
    SET @Result = REPLACE(@Result, N'Ừ', 'U')
    SET @Result = REPLACE(@Result, N'Ử', 'U')
    SET @Result = REPLACE(@Result, N'Ữ', 'U')
    SET @Result = REPLACE(@Result, N'Ự', 'U')
    SET @Result = REPLACE(@Result, N'Ứ', 'U')
    SET @Result = REPLACE(@Result, N'Ỳ', 'Y')
    SET @Result = REPLACE(@Result, N'Ỷ', 'Y')
    SET @Result = REPLACE(@Result, N'Ỹ', 'Y')
    SET @Result = REPLACE(@Result, N'Ỵ', 'Y')
    SET @Result = REPLACE(@Result, N'Ý', 'Y')

    RETURN @Result
END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Beverage]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beverage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BeverageCategory]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BeverageCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idBeverage] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TableBeverage]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableBeverage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [Password], [Type]) VALUES (N'ad', N'ad2', N'20720532132149213101239102231223249249135100218', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [Password], [Type]) VALUES (N'admin', N'Khoa', N'3244185981728979115075721453575112', 1)
SET IDENTITY_INSERT [dbo].[Beverage] ON 

INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (1, N'Cà phê sữa', 1, 12000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (2, N'Cà phê đen', 1, 10000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (3, N'Espresso đen', 1, 13000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (4, N'Espresso sữa', 1, 14000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (5, N'Cà phê sữa sài gòn', 1, 14000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (6, N'Bò húc', 2, 20000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (7, N'Nước Khoáng', 2, 12000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (8, N'Nước suối', 2, 10000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (9, N'Nước chanh', 3, 17000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (10, N'Matcha đá xay', 3, 30000)
INSERT [dbo].[Beverage] ([id], [name], [idCategory], [price]) VALUES (11, N'Socola đá xay', 3, 30000)
SET IDENTITY_INSERT [dbo].[Beverage] OFF
SET IDENTITY_INSERT [dbo].[BeverageCategory] ON 

INSERT [dbo].[BeverageCategory] ([id], [name]) VALUES (1, N'Cà phê')
INSERT [dbo].[BeverageCategory] ([id], [name]) VALUES (2, N'Nước đóng chai')
INSERT [dbo].[BeverageCategory] ([id], [name]) VALUES (3, N'Pha chế')
SET IDENTITY_INSERT [dbo].[BeverageCategory] OFF
SET IDENTITY_INSERT [dbo].[TableBeverage] ON 

INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (1, N'Bàn 0', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (2, N'Bàn 1', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (3, N'Bàn 2', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (4, N'Bàn 3', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (5, N'Bàn 4', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (6, N'Bàn 5', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (7, N'Bàn 6', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (8, N'Bàn 7', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (9, N'Bàn 8', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (10, N'Bàn 9', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (11, N'Bàn 10', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (13, N'Bàn 11', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (14, N'Bàn 12', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (15, N'Bàn 13', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (16, N'Bàn 14', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (17, N'Bàn 15', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (18, N'Bàn 16', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (19, N'Bàn 17', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (20, N'Bàn 18', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (21, N'Bàn 19', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (22, N'Bàn 20', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (23, N'Bàn 21', N'Trống')
INSERT [dbo].[TableBeverage] ([id], [name], [status]) VALUES (24, N'Bàn 22', N'Trống')
SET IDENTITY_INSERT [dbo].[TableBeverage] OFF
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('Khoas staff') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Password]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Beverage] ADD  DEFAULT ('unnamed') FOR [name]
GO
ALTER TABLE [dbo].[Beverage] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[BeverageCategory] ADD  DEFAULT ('unnamed') FOR [name]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[TableBeverage] ADD  DEFAULT ('unnamed table') FOR [name]
GO
ALTER TABLE [dbo].[TableBeverage] ADD  CONSTRAINT [df_status]  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Beverage]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[BeverageCategory] ([id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableBeverage] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBeverage])
REFERENCES [dbo].[Beverage] ([id])
GO
/****** Object:  StoredProcedure [dbo].[USP_CombineTable]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_CombineTable]
@idTable1 int,@idTable2 int
AS
BEGIN
	Declare @idFirstBill int
	Declare @idSecondBill int
	Declare @isFirstTableEmpty int = 1
	Declare @isSecondTableEmpty int = 1
	--Lấy ra BillID của Bill chưa thanh toán trên 2 bàn cần gộp vào nhau
	Select @idSecondBill = Id from Bill Where IdTable = @idTable2 And status = 0
	Select @idFirstBill = Id from Bill Where IdTable = @idTable1 And status = 0

	--Nếu 2 bàn đều có người thì mới tiến hành gộp
	IF(@idFirstBill != 0 AND @idSecondBill != 0)
		BEGIN
			--Gộp bàn thứ 1 vào bàn thứ 2 bằng cách thay BillID trong bảng BillInfo
			UPDATE BillInfo SET IdBill = @idSecondBill WHERE IdBill = @idFirstBill

			--Khi gộp bàn sẽ xuất hiện các món trùng lặp với nhau
			--Tạo con trỏ và lấy ra các FoodID với số lần trùng lặp
			DECLARE BillInfoCursor CURSOR FOR SELECT idBeverage, count(*) AS 'Count' FROM BillInfo WHERE IdBill = @idSecondBill GROUP BY idBeverage
			OPEN BillInfoCursor

			DECLARE @foodID INT
			DECLARE @count INT

			FETCH NEXT FROM BillInfoCursor INTO @foodID, @count

			WHILE @@FETCH_STATUS = 0
				BEGIN
					--Trường hợp @count > 1 tức là món này bị trùng nhau, xuất hiện hơn 1 lần
					IF(@count > 1) 
						BEGIN
							DECLARE @finalFoodCount INT = 0
							--Tính gộp tổng các FoodCount của món này
							SELECT @finalFoodCount = SUM(count) FROM BillInfo WHERE IdBill = @idSecondBill AND idBeverage = @foodID
			
							DECLARE @maxID INT = 0
							--Lấy ra max ID của món này để tí nữa giữ lại, các ID khác xoá hết cho khỏi trùng nhau
							SELECT @maxID = MAX(ID) FROM BillInfo WHERE IdBill = @idSecondBill AND idBeverage = @foodID

							--update số lượng món ăn cho ID này
							UPDATE BillInfo SET count = @finalFoodCount WHERE IdBill = @idSecondBill AND idBeverage = @foodID AND ID = @maxID --Cài nhiều điều kiện cho chắc kèo

							--Xoá các ID còn lại
							DELETE BillInfo WHERE IdBill = @idSecondBill AND idBeverage = @foodID AND ID != @maxID
						END

					FETCH NEXT FROM BillInfoCursor INTO @foodID, @count
				END

			CLOSE BillInfoCursor
			DEALLOCATE BillInfoCursor
		END
		Select @isFirstTableEmpty =  COUNT (*) from BillInfo where IdBill = @idFirstBill
		Select @isSecondTableEmpty =  COUNT (*) from BillInfo where IdBill = @idSecondBill
		Print '------'
		Print @isFirstTableEmpty
		Print @isSecondTableEmpty
	If(@isFirstTableEmpty = 0)
		Begin
			Update dbo.TableBeverage set status = N'Trống' where Id = @idTable1
			Delete Bill where IdTable = @idTable1 And status = 0
		End
	If(@isSecondTableEmpty = 0)
		Begin
			Update dbo.TableBeverage set status = N'Trống' where Id = @idTable2
			Delete Bill where IdTable = @idTable2 And status = 0
		End
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAccountByUserName]
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetListByDate]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListByDate]
@checkIn date, @checkOut date
AS
BEGIN
	SELECT tb.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], b.DateCheckIn AS [Ngày vào], b.DateCheckOut AS [Ngày thanh toán], b.discount AS [Giảm giá] 
	FROM bill AS b, dbo.TableBeverage AS tb
	WHERE b.DateCheckIn >= @checkIn AND b.DateCheckOut <= @checkOut AND b.status = 1
	AND tb.id = b.idTable
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS 
	SELECT * FROM dbo.TableBeverage

GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@idTable int
AS
BEGIN
	INSERT INTO dbo.Bill
	(
	    DateCheckIn,
	    DateCheckOut,
	    idTable,
	    status,
		discount
	)
	VALUES
	(   GETDATE(), -- DateCheckIn - date
	    NULL, -- DateCheckOut - date
	    @idTable,  -- idTable - int
	    0,         -- status - int
		0
	    )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
@idBill INT,
@idBeverage INT,
@count INT
AS
BEGIN
	IF @count <= 0
    BEGIN
        RETURN
    END

	DECLARE @billInfoIsExist INT
	DECLARE @beverageCount INT = 1

	SELECT @billInfoIsExist = id, @beverageCount = count FROM dbo.BillInfo WHERE idBill = @idBill AND idBeverage = @idBeverage --kiểm tra xem có tồn tại chưa

	IF (@billInfoIsExist > 0)
	BEGIN
		DECLARE @newCount INT = @beverageCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET count = @beverageCount + @count WHERE idBeverage = @idBeverage --nếu đã tồn tại thì cộng thêm, nếu là số âm sẽ trừ bớt
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idBeverage = @idBeverage
	END
	ELSE
	BEGIN
		INSERT INTO dbo.BillInfo
		(
			idBill,
			idBeverage,
			count
		)
		VALUES
		(   @idBill, -- idBill - int
			@idBeverage, -- idBeverage - int
			@count  -- count - int
	    )
	END
END

GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName nvarchar(100), 
@password nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND Password = @password
END 

GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTable]
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSecondBill INT
	
	DECLARE @isFirstTableEmty INT = 1
	DECLARE @isSecondTableEmty INT = 1
	
	SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status,
				  discount
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0,  -- status - int
				  0
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '-----------'
	
	IF (@idSecondBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status,
				  discount
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0,  -- status - int
				  0
		        )
		SELECT @idSecondBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSecondBill
	
	PRINT @idFirstBill
	PRINT @idSecondBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
	
	UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable

	IF (@isFirstTableEmty = 0)
		UPDATE dbo.TableBeverage SET status = N'Trống' WHERE id = @idTable2

	IF (@isSecondTableEmty = 0)
		UPDATE dbo.TableBeverage SET status = N'Trống' WHERE id = @idTable1
	
END

GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable1]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTable1]
@idTable1 INT, @idTable2 INT
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE @idSecondBill INT
	
	SELECT id = @idSecondBill FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT id = @idFirstBill FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

	IF (@idFirstBill IS NULL)
	BEGIN
		INSERT dbo.Bill
		(
		    DateCheckIn,
		    DateCheckOut,
		    idTable,
		    status,
		    discount
		)
		VALUES
		(   GETDATE(), -- DateCheckIn - date
		    NULL, -- DateCheckOut - date
		    @idTable1, -- idTable - int
		    0,         -- status - int
		    0          -- discount - int
		    )

		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
    END

	IF (@idSecondBill IS NULL)
	BEGIN
		INSERT dbo.Bill
		(
		    DateCheckIn,
		    DateCheckOut,
		    idTable,
		    status,
		    discount
		)
		VALUES
		(   GETDATE(), -- DateCheckIn - date
		    NULL, -- DateCheckOut - date
		    @idTable2, -- idTable - int
		    0,         -- status - int
		    0          -- discount - int
		    )

		SELECT @idSecondBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
    END

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill

	UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM dbo.IDBillInfoTable)

	DROP TABLE dbo.IDBillInfoTable
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(1000), @newPassword NVARCHAR(1000)
AS
BEGIN
	DECLARE @isRightPass INT = 0
    
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND Password = @password
	
	IF(@isRightPass = 1)
	BEGIN
		IF(@newPassword = NULL OR @newPassword = '' OR @newPassword = '2122914021714301784233128915223624866126')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, Password = @newPassword WHERE UserName = @userName
	END
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateBillInfoAfrerMinus]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateBillInfoAfrerMinus]
@idBill INT,
@idBeverage INT,
@count INT
AS
BEGIN

	DECLARE @billInfoIsExist INT
	DECLARE @beverageCount INT = 1

	SELECT @billInfoIsExist = id, @beverageCount = count FROM dbo.BillInfo WHERE idBill = @idBill AND idBeverage = @idBeverage --kiểm tra xem có tồn tại chưa

	IF (@billInfoIsExist > 0)
	BEGIN
		DECLARE @newCount INT = @beverageCount - @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET count = @beverageCount - @count WHERE idBeverage = @idBeverage --nếu đã tồn tại thì cộng thêm, nếu là số âm sẽ trừ bớt
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idBeverage = @idBeverage
	END
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateBillInfoByMinus]    Script Date: 26-05-2024 8:32:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateBillInfoByMinus]
@idBill INT,
@idBeverage INT,
@count INT
AS
BEGIN
	IF @count <= 0
    BEGIN
        RETURN
    END
	
	DECLARE @billInfoIsExist INT
	DECLARE @beverageCount INT = 1

	SELECT @billInfoIsExist = id, @beverageCount = count FROM dbo.BillInfo WHERE idBill = @idBill AND idBeverage = @idBeverage --kiểm tra xem có tồn tại chưa

	IF (@billInfoIsExist > 0)
	BEGIN
		DECLARE @newCount INT = @beverageCount - @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET count = @beverageCount - @count WHERE idBeverage = @idBeverage --nếu đã tồn tại thì cộng thêm, nếu là số âm sẽ trừ bớt
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idBeverage = @idBeverage
	END
	ELSE
		RETURN
END

GO
USE [master]
GO
ALTER DATABASE [CoffeeShopManagement] SET  READ_WRITE 
GO
