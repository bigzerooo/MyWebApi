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
