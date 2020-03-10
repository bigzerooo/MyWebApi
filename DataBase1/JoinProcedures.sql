USE SQL4
GO
CREATE PROCEDURE JoinGet 
AS
BEGIN
SELECT CarHires.Id, CarId, Brand, Cars.Price as CarPrice, PricePerHour,
	Cars.Type, Year, ClientId, LastName, FirstName, SecondName, Adress, PhoneNumber, 
	TypeOfClient, BeginDate, EndDate, CarState, Discount, Penalty, CarHires.Price
FROM CarHires
	JOIN Clients
	ON Clients.Id=CarHires.ClientId
	JOIN Cars
	ON Cars.Id=CarHires.CarId
END
GO
CREATE PROCEDURE JoinGetById
@Id INT
AS
BEGIN
SELECT CarHires.Id, CarId, Brand, Cars.Price as CarPrice, PricePerHour,
	Cars.Type, Year, ClientId, LastName, FirstName, SecondName, Adress, PhoneNumber, 
	TypeOfClient, BeginDate, EndDate, CarState, Discount, Penalty, CarHires.Price
FROM CarHires
	JOIN Clients
	ON Clients.Id=CarHires.ClientId
	JOIN Cars
	ON Cars.Id=CarHires.CarId
WHERE CarHires.Id=@Id
END
GO
CREATE PROCEDURE JoinDelete
@Id INT
AS
BEGIN
DECLARE @carId INT
DECLARE @clientId INT

SET @carId = (SELECT TOP(1) CarHires.CarId FROM CarHires where CarHires.Id=@Id)
SET @clientId = (SELECT TOP(1) CarHires.ClientId FROM CarHires where CarHires.Id=@Id)

EXEC SP_DeleteRecordFromTable CarHires, @Id
EXEC SP_DeleteRecordFromTable Cars, @carId
EXEC SP_DeleteRecordFromTable Clients, @clientId

END
GO
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
GO
CREATE PROCEDURE JoinUpdate
@Id INT,
@CarId INT,
@Brand NVARCHAR(45),
@CarPrice DECIMAL(19,4),
@PricePerHour DECIMAL(19,4),
@Type NVARCHAR(45),
@Year INT,
@ClientId INT,
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
UPDATE Cars
SET Brand=@Brand, Price=@CarPrice, PricePerHour=@PricePerHour, Type=@Type,Year=@Year
WHERE Id=@CarId

UPDATE Clients
SET LastName=@LastName,FirstName=@FirstName, SecondName=@SecondName, Adress=@Adress,PhoneNumber=@PhoneNumber,TypeOfClient=@TypeOfClient
WHERE Id=@ClientId

Update CarHires
SET BeginDate=@BeginDate, EndDate=@EndDate, CarState=@CarState
WHERE Id=@Id

END
GO