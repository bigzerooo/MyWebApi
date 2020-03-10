USE SQL4
GO
CREATE PROCEDURE createClientType
	@���_�볺��� NVARCHAR(45)
AS
BEGIN
INSERT INTO ClientTypes VALUES(@���_�볺���)
END
GO

CREATE PROCEDURE createCarType
	@���_��������� NVARCHAR(45)	
AS
BEGIN
INSERT INTO CarTypes VALUES(@���_���������)
END
GO

CREATE PROCEDURE createCarState
	@����_���������	NVARCHAR(45)	
AS
BEGIN
INSERT INTO CarStates VALUES(@����_���������)
END
GO

CREATE PROCEDURE createClient	
	@�������		NVARCHAR(45),
	@���			NVARCHAR(45),
	@���������		NVARCHAR(45),
	@������			NVARCHAR(45),
	@�������		NVARCHAR(45),
	@���_�볺���	NVARCHAR(45)
AS
BEGIN
INSERT INTO Clients VALUES(@�������, @���, @���������, @������, @�������, @���_�볺���)
END
GO

CREATE PROCEDURE createCar	
	@�����						NVARCHAR(45),
	@�������_���������		DECIMAL(19,4),
	@�������_������_�������	DECIMAL(19,4),
	@���_���������				NVARCHAR(45),
	@г�_�������				INT
AS
BEGIN
INSERT INTO Cars VALUES(@�����, @�������_���������,@�������_������_�������,@���_���������,@г�_�������)
END
GO

CREATE PROCEDURE createCarHire
	@���_���������			INT,
	@���_�볺���			INT,
	@����_������			DATETIME,
	@����_����������		DATETIME,
	@����_���������		NVARCHAR(45)
AS
BEGIN
INSERT INTO CarHires VALUES(@���_���������,@���_�볺���,@����_������,@����_����������,@����_���������)
END
GO

CREATE PROCEDURE readAll
AS
BEGIN
SELECT CarHires.Id, CarId, Brand, Cars.Price, PricePerHour,
	Cars.Type, Year, ClientId, LastName, FirstName, SecondName, Adress, PhoneNumber, 
	TypeOfClient, BeginDate, EndDate, CarState, Discount, Penalty, CarHires.Price
FROM CarHires
	JOIN Clients
	ON Clients.Id=CarHires.ClientId
	JOIN Cars
	ON Cars.Id=CarHires.CarId
END
GO

CREATE PROCEDURE readAllCar
AS
BEGIN
SELECT * FROM Cars
END
GO

CREATE PROCEDURE readAllClient
AS
BEGIN
SELECT * FROM Clients
END
GO

CREATE PROCEDURE readAllById
@Id INT
AS
BEGIN
SELECT CarHires.Id, CarId, Brand, Cars.Price, PricePerHour,
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

CREATE PROCEDURE readCarById
@Id INT
AS
BEGIN
SELECT * FROM Cars
WHERE Id=@Id
END
GO

CREATE PROCEDURE readClientById
@Id INT
AS
BEGIN
SELECT * FROM Clients
WHERE Id=@Id
END
GO

CREATE PROCEDURE updateCar
	@Id INT,
	@�����					NVARCHAR(45),
	@�������_���������		DECIMAL(19,4),
	@�������_������_������� DECIMAL(19,4),
	@���_���������			NVARCHAR(45),
	@г�_�������				INT
AS
BEGIN
UPDATE Cars
SET	
	Brand=@�����,
	Price=@�������_���������,
	PricePerHour=@�������_������_�������,
	Type=@���_���������,
	Year=@г�_�������
WHERE Id=@Id
END
GO

CREATE PROCEDURE updateClient
	@Id INT,
	@�������		NVARCHAR(45),
	@���			NVARCHAR(45),
	@���������	NVARCHAR(45),
	@������			NVARCHAR(45),
	@�������			NVARCHAR(45),
	@���_�볺���		NVARCHAR(45)
AS
BEGIN
UPDATE Clients
SET 
	LastName=@�������,
	FirstName=@���,
	SecondName=@���������,
	Adress=@������,
	PhoneNumber=@�������,
	TypeOfClient=@���_�볺���
WHERE Id=@Id
END
GO

CREATE PROCEDURE updateCarHire
	@Id INT,
	@���_���������		INT,
	@���_�볺���			INT,
	@����_������			DATETIME,
	@����_����������		DATETIME,
	@����_���������		NVARCHAR(45)
AS
BEGIN
UPDATE CarHires
SET
	CarId=@���_���������,
	ClientId=@���_�볺���,
	BeginDate=@����_������,
	EndDate=@����_����������,
	CarState=@����_���������
WHERE Id=@Id
END
GO

CREATE PROCEDURE deleteClientType
	@���_�볺��� NVARCHAR(45)
AS
BEGIN
DELETE
FROM ClientTypes
WHERE Type=@���_�볺���
END
GO

CREATE PROCEDURE deleteCarType
	@���_��������� NVARCHAR(45)	
AS
BEGIN
DELETE
FROM CarTypes
WHERE Type=@���_���������
END
GO

CREATE PROCEDURE deleteCarState
	@����_���������	NVARCHAR(45)	
AS
BEGIN
DELETE
FROM CarStates
WHERE State=@����_���������
END
GO

CREATE PROCEDURE deleteCar
	@Id INT
AS
BEGIN
DELETE
FROM Cars
WHERE Id=@Id
END
GO

CREATE PROCEDURE deleteClient
	@Id INT
AS
BEGIN
DELETE
FROM Clients
WHERE Id=@Id
END
GO

CREATE PROCEDURE deleteCarHire
	@Id INT
AS
BEGIN
DELETE
FROM CarHires
WHERE Id=@Id
END
GO

USE master
GO
