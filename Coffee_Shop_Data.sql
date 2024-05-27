CREATE DATABASE CoffeeShopManagement
GO

USE CoffeeShopManagement
GO 

-- Beverage
-- TableBeverage
-- BeverageCategory
-- Account
-- Bill
-- Bill Info

CREATE TABLE TableBeverage
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL DEFAULT 'unnamed table',
	status NVARCHAR(50) NOT NULL DEFAULT 'empty' -- empty | occupied
)
GO

SELECT * FROM dbo.TableBeverage
sp_help TableBeverage

ALTER TABLE dbo.TableBeverage
ADD CONSTRAINT df_status DEFAULT N'Trống' FOR status

CREATE TABLE Account 
(
	UserName NVARCHAR(50) PRIMARY KEY,
	DisplayName NVARCHAR(50) NOT NULL DEFAULT 'Khoas staff',
	Password NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0 -- 1: admin | 0: staff
)
GO

CREATE TABLE BeverageCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL DEFAULT 'unnamed'
)
GO

CREATE TABLE Beverage 
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL DEFAULT 'unnamed',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.BeverageCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE, 
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: paid | 0: unpaid

	FOREIGN KEY (idTable) REFERENCES dbo.TableBeverage(id)
)
GO



ALTER TABLE dbo.Bill
ADD	discount INT

UPDATE dbo.Bill SET discount = 0

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idBeverage INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idBeverage) REFERENCES dbo.Beverage(id)
)
GO

INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    Password,
    Type
)
VALUES
(   N'admin', -- UserName - nvarchar(50)
    N'Khoa', -- DisplayName - nvarchar(50)
    N'123', -- Password - nvarchar(1000)
    1    -- Type - int
    )

INSERT INTO dbo.Account
(
    UserName,
    DisplayName,
    Password,
    Type
)
VALUES
(   N'staff', -- UserName - nvarchar(50)
    N'Ben', -- DisplayName - nvarchar(50)
    N'123', -- Password - nvarchar(1000)
    0    -- Type - int
    )

SELECT * FROM dbo.Account


CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100) -- parameter
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC USP_GetAccountByUserName @userName = 'admin'

SELECT * FROM dbo.Account WHERE UserName = 'admin' AND Password = '123'

SELECT * FROM dbo.Account WHERE UserName = 'admin' AND Password = ''OR 1 = 1--123'   -- sql injection

CREATE PROC USP_Login
@userName nvarchar(100), 
@password nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND Password = @password
END 
GO


INSERT INTO dbo.TableBeverage
(
    name
)
VALUES
(   N'Bàn 21') -- name - nvarchar(50)


--thêm bàn
DECLARE @i INT = 0

WHILE @i <= 20
BEGIN
	INSERT INTO dbo.TableBeverage (name) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100))) --cast: ép kiểu
	SET @i = @i +1
END

SELECT * FROM dbo.TableBeverage


--thêm danh mục
INSERT INTO dbo.BeverageCategory
(
    name
)
VALUES
(N'Cà phê' -- name - nvarchar(50)
    )

INSERT INTO dbo.BeverageCategory
(name)
VALUES
(N'Nước đóng chai')

INSERT INTO dbo.BeverageCategory
(name)
VALUES
(N'Pha chế')

SELECT * FROM dbo.BeverageCategory

--thêm đồ uống
INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Cà phê sữa', -- name - nvarchar(50)
    1,   -- idCategory - int
    12000  -- price - float
    )

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Cà phê đen', 1, 10000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Espresso đen', 1, 13000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Espresso sữa', 1, 14000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Cà phê sữa sài gòn', 1, 14000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Bò húc', 2, 20000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Nước Khoáng', 2, 12000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Nước suối', 2, 10000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Nước chanh', 3, 17000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Matcha đá xay', 3, 30000)

INSERT INTO dbo.Beverage
(
    name,
    idCategory,
    price
)
VALUES
(   N'Socola đá xay', 3, 30000)

SELECT * FROM dbo.Beverage

--thêm hóa đơn
INSERT INTO dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    NULL, -- DateCheckOut - date
    1,         -- idTable - int
    0          -- status - int
    )

INSERT INTO dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    NULL, -- DateCheckOut - date
    2,         -- idTable - int
    0          -- status - int
    )

INSERT INTO dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    GETDATE(), -- DateCheckOut - date
    2,         -- idTable - int
    1          -- status - int
    )

INSERT INTO dbo.Bill
(
    DateCheckIn,
    DateCheckOut,
    idTable,
    status
)
VALUES
(   GETDATE(), -- DateCheckIn - date
    GETDATE(), -- DateCheckOut - date
    3,         -- idTable - int
    1          -- status - int
    )

SELECT * FROM dbo.Bill

--thêm thông tin hóa đơn
INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   1, -- idBill - int
    1, -- idBeverage - int
    2  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   1, -- idBill - int
    3, -- idBeverage - int
    4  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   1, -- idBill - int
    6, -- idBeverage - int
    1  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   2, -- idBill - int
    6, -- idBeverage - int
    2  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   2, -- idBill - int
    9, -- idBeverage - int
    1  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   2, -- idBill - int
    10, -- idBeverage - int
    1  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   3, -- idBill - int
    7, -- idBeverage - int
    1  -- count - int
    )

INSERT INTO dbo.BillInfo
(
    idBill,
    idBeverage,
    count
)
VALUES
(   4, -- idBill - int
    2, -- idBeverage - int
    1  -- count - int
    )

SELECT * FROM dbo.BillInfo

CREATE PROC USP_GetTableList
AS 
	SELECT * FROM dbo.TableBeverage
GO

EXEC USP_GetTableList

UPDATE dbo.TableBeverage SET status = N'Trống' WHERE status = 'empty'

SELECT * FROM dbo.Bill WHERE idTable = 2 AND status = 1

SELECT * FROM dbo.BillInfo WHERE idBill = 3

SELECT be.name, bi.count, be.price, be.price*bi.count AS totalPrice FROM dbo.Bill AS b, dbo.BillInfo AS bi, dbo.Beverage AS be
WHERE bi.idBill = b.id AND bi.idBeverage = be.id AND b.status = 0 AND b.idTable = 2

SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Bill

CREATE PROC USP_InsertBill
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

CREATE PROC USP_InsertBillInfo
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

CREATE PROC USP_UpdateBillInfoByMinus
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




CREATE TRIGGER UTG_UpdateBillInffo
ON dbo.BillInfo FOR INSERT, UPDATE 
AS 
BEGIN
	DECLARE @idBill INT	
	SELECT @idBill = idBill FROM Inserted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill

	IF(@count > 0)
		UPDATE dbo.TableBeverage SET status = N'Có người' WHERE id = @idTable
	ELSE
		UPDATE dbo.TableBeverage SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
    DECLARE @idBill INT
    SELECT @idBill = id FROM Inserted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0

	IF(@count = 0)
		UPDATE dbo.TableBeverage SET status = N'Trống' WHERE id = @idTable
END
GO

SELECT MAX(id) FROM dbo.Bill
GO


CREATE PROC USP_SwitchTable1
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

CREATE PROC USP_SwitchTable
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



CREATE PROC USP_CombineTable
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



ALTER TABLE dbo.Bill ADD totalPrice FLOAT
go


CREATE PROC USP_GetListByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT tb.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], b.DateCheckIn AS [Ngày vào], b.DateCheckOut AS [Ngày thanh toán], b.discount AS [Giảm giá] 
	FROM bill AS b, dbo.TableBeverage AS tb
	WHERE b.DateCheckIn >= @checkIn AND b.DateCheckOut <= @checkOut AND b.status = 1
	AND tb.id = b.idTable
END
GO

SELECT * FROM dbo.Account
GO


CREATE PROC USP_UpdateAccount
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


SELECT b.id AS [ID], b.name AS [Tên món], bc.name AS [Danh mục], b.price AS [Giá thành] FROM dbo.Beverage AS b, dbo.BeverageCategory AS bc WHERE b.idCategory = bc.id
SELECT id AS 'ID', name 'Tên danh mục' FROM dbo.BeverageCategory



CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
    SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0
	SELECT @count =COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0

	IF (@count = 0)
		UPDATE dbo.TableBeverage SET status = N'Trống' WHERE id = @idTable
END
GO




--Hàm thay thế tất cả kí tự đặc biệt (tiếng việt) thành kí tự bình thường
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

SELECT * FROM dbo.Beverage WHERE dbo.fuConvertToUnsign1(name) LIKE '%' + dbo.fuConvertToUnsign1(N'ca') + '%'
SELECT * FROM dbo.BeverageCategory WHERE dbo.fuConvertToUnsign1(name) LIKE '%' + dbo.fuConvertToUnsign1(N'ca') + '%'
SELECT * FROM dbo.TableBeverage WHERE dbo.fuConvertToUnsign1(name) LIKE '%' + dbo.fuConvertToUnsign1(N'3') + '%'

SELECT * FROM dbo.Beverage

SELECT dbo.fuConvertToUnsign1(N'cà phê sữa') AS Result1;
SELECT dbo.fuConvertToUnsign1(N'ca') AS Result2;

SELECT id, name, dbo.fuConvertToUnsign1(name) AS UnsignName
FROM dbo.Beverage;

