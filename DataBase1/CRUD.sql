USE SQL4
GO
CREATE PROCEDURE createClientType
	@Тип_клієнта NVARCHAR(45)
AS
BEGIN
INSERT INTO ClientTypes VALUES(@Тип_клієнта)
END
GO

CREATE PROCEDURE createCarType
	@Тип_автомобіля NVARCHAR(45)	
AS
BEGIN
INSERT INTO CarTypes VALUES(@Тип_автомобіля)
END
GO

CREATE PROCEDURE createCarState
	@Стан_автомобіля	NVARCHAR(45)	
AS
BEGIN
INSERT INTO CarStates VALUES(@Стан_автомобіля)
END
GO

CREATE PROCEDURE createClient	
	@Прізвище		NVARCHAR(45),
	@Імя			NVARCHAR(45),
	@Побатькові		NVARCHAR(45),
	@Адреса			NVARCHAR(45),
	@Телефон		NVARCHAR(45),
	@Тип_клієнта	NVARCHAR(45)
AS
BEGIN
INSERT INTO Clients VALUES(@Прізвище, @Імя, @Побатькові, @Адреса, @Телефон, @Тип_клієнта)
END
GO

CREATE PROCEDURE createCar	
	@Марка						NVARCHAR(45),
	@Вартість_автомобіля		DECIMAL(19,4),
	@Вартість_години_прокату	DECIMAL(19,4),
	@Тип_автомобіля				NVARCHAR(45),
	@Рік_випуску				INT
AS
BEGIN
INSERT INTO Cars VALUES(@Марка, @Вартість_автомобіля,@Вартість_години_прокату,@Тип_автомобіля,@Рік_випуску)
END
GO

CREATE PROCEDURE createCarHire
	@Код_автомобіля			INT,
	@Код_клієнта			INT,
	@Дата_видачі			DATETIME,
	@Дата_повернення		DATETIME,
	@Стан_автомобіля		NVARCHAR(45)
AS
BEGIN
INSERT INTO CarHires VALUES(@Код_автомобіля,@Код_клієнта,@Дата_видачі,@Дата_повернення,@Стан_автомобіля)
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
	@Марка					NVARCHAR(45),
	@Вартість_автомобіля		DECIMAL(19,4),
	@Вартість_години_прокату DECIMAL(19,4),
	@Тип_автомобіля			NVARCHAR(45),
	@Рік_випуску				INT
AS
BEGIN
UPDATE Cars
SET	
	Brand=@Марка,
	Price=@Вартість_автомобіля,
	PricePerHour=@Вартість_години_прокату,
	Type=@Тип_автомобіля,
	Year=@Рік_випуску
WHERE Id=@Id
END
GO

CREATE PROCEDURE updateClient
	@Id INT,
	@Прізвище		NVARCHAR(45),
	@Імя			NVARCHAR(45),
	@Побатькові	NVARCHAR(45),
	@Адреса			NVARCHAR(45),
	@Телефон			NVARCHAR(45),
	@Тип_клієнта		NVARCHAR(45)
AS
BEGIN
UPDATE Clients
SET 
	LastName=@Прізвище,
	FirstName=@Імя,
	SecondName=@Побатькові,
	Adress=@Адреса,
	PhoneNumber=@Телефон,
	TypeOfClient=@Тип_клієнта
WHERE Id=@Id
END
GO

CREATE PROCEDURE updateCarHire
	@Id INT,
	@Код_автомобіля		INT,
	@Код_клієнта			INT,
	@Дата_видачі			DATETIME,
	@Дата_повернення		DATETIME,
	@Стан_автомобіля		NVARCHAR(45)
AS
BEGIN
UPDATE CarHires
SET
	CarId=@Код_автомобіля,
	ClientId=@Код_клієнта,
	BeginDate=@Дата_видачі,
	EndDate=@Дата_повернення,
	CarState=@Стан_автомобіля
WHERE Id=@Id
END
GO

CREATE PROCEDURE deleteClientType
	@Тип_клієнта NVARCHAR(45)
AS
BEGIN
DELETE
FROM ClientTypes
WHERE Type=@Тип_клієнта
END
GO

CREATE PROCEDURE deleteCarType
	@Тип_автомобіля NVARCHAR(45)	
AS
BEGIN
DELETE
FROM CarTypes
WHERE Type=@Тип_автомобіля
END
GO

CREATE PROCEDURE deleteCarState
	@Стан_автомобіля	NVARCHAR(45)	
AS
BEGIN
DELETE
FROM CarStates
WHERE State=@Стан_автомобіля
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
