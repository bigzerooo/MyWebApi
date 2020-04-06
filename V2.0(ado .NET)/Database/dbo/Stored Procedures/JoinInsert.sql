CREATE PROCEDURE JoinInsert
@Brand NVARCHAR(45),
@CarPrice DECIMAL(19,4),
@PricePerHour DECIMAL(19,4),
@Type NVARCHAR(45),
@Year INT,
@LastName NVARCHAR(45),
@FirstName NVARCHAR(45),
@SecondName NVARCHAR(45),
@Adress NVARCHAR(45),
@PhoneNumber NVARCHAR(45),
@TypeOfClient NVARCHAR(45),
@BeginDate DATETIME,
@EndDate DATETIME,
@CarState NVARCHAR(45)
AS
BEGIN
DECLARE @CarId INT
DECLARE @ClientId INT
INSERT INTO Cars Values(@Brand, @CarPrice,@PricePerHour, @Type,@Year)
SET @CarId=SCOPE_IDENTITY()
INSERT INTO Clients Values(@LastName,@FirstName,@SecondName,@Adress,@PhoneNumber,@TypeOfClient)
SET @ClientId=SCOPE_IDENTITY()
INSERT INTO CarHires Values(@CarId,@ClientId,@BeginDate,@EndDate,@CarState)
SELECT SCOPE_IDENTITY()
END
