CREATE DATABASE SQL4
GO
USE SQL4
GO
CREATE TABLE ClientTypes
(
Type NVARCHAR(45) NOT NULL PRIMARY KEY
)
GO
INSERT INTO ClientTypes VALUES('Звичайний')
INSERT INTO ClientTypes VALUES('Постійний')
GO
CREATE TABLE Clients
(
Id		INT				NOT NULL	IDENTITY(1,1) PRIMARY KEY,
LastName		NVARCHAR(45)	NOT NULL,
FirstName			NVARCHAR(45)	NOT NULL,
SecondName	NVARCHAR(45)	NOT NULL,
Adress			NVARCHAR(45)	NULL,
PhoneNumber			NVARCHAR(45)	NULL		CHECK(PhoneNumber LIKE '+38([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
TypeOfClient		NVARCHAR(45)	NULL		REFERENCES ClientTypes(Type) ON DELETE SET NULL  
)
GO
CREATE TABLE CarTypes
(
Type NVARCHAR(45) NOT NULL PRIMARY KEY
)
GO
INSERT INTO CarTypes VALUES('Легковий')
INSERT INTO CarTypes VALUES('Грузовий')
INSERT INTO CarTypes VALUES('Електро')
GO
CREATE TABLE Cars
(
Id			INT				NOT NULL	IDENTITY(1,1) PRIMARY KEY,
Brand					NVARCHAR(45)	NOT NULL,
Price		DECIMAL(19,4)	NOT NULL,
PricePerHour DECIMAL(19,4)	NOT NULL,
Type			NVARCHAR(45)	NULL		REFERENCES CarTypes(Type) ON DELETE SET NULL,
Year				INT				NULL		CHECK(Year>=1900 AND Year<=YEAR(GETDATE()))
)
GO
CREATE TABLE CarStates
(
State	NVARCHAR(45) NOT NULL PRIMARY KEY
)
GO
INSERT INTO CarStates VALUES('Належний')
INSERT INTO CarStates VALUES('Неналежний')
GO
CREATE TABLE CarHires
(
Id			INT				NOT NULL IDENTITY(1,1) PRIMARY KEY,
CarId		INT				NOT NULL REFERENCES Cars (Id)		ON DELETE CASCADE,
ClientId			INT				NOT NULL REFERENCES Clients (Id)			ON DELETE CASCADE,
BeginDate			DATETIME		NOT NULL CHECK(BeginDate<=GETDATE()),
EndDate		DATETIME		NOT NULL CHECK(EndDate<=GETDATE()),
CarState		NVARCHAR(45)	NOT NULL REFERENCES CarStates(State)ON DELETE CASCADE,
CHECK(BeginDate<=EndDate)
)
GO

CREATE FUNCTION FuncClientType
(
	@кодКлієнта INT
)
RETURNS NVARCHAR(45)
AS --Повертає значення типу клієнта залежно від коду
BEGIN

--	DECLARE @myCount INT
	--SET @myCount = (SELECT COUNT(*)
		--			FROM Прокат_автомобілів
			--		WHERE Прокат_автомобілів.Код_клієнта=@кодКлієнта)
	DECLARE @типКлієнта NVARCHAR(45)
	SET @типКлієнта = (SELECT TypeOfClient FROM Clients WHERE @кодКлієнта=Id)
	--if(@myCount>5) --Більше 5 прокатів - Постійний
		--SET @типКлієнта='Постійний'
	--else --В іншому випадку - NULL
		--SET @типКлієнта=NULL*/
	RETURN @типКлієнта
END
--GO
--ALTER TABLE Клієнти
--ADD Тип_клієнта	AS(dbo.ClientType(Код_клієнта)) 
GO
CREATE FUNCTION FuncDiscount
(
	@кодКлієнта INT
)
RETURNS DECIMAL(5,4)
AS --повертає значення знижки по коду
BEGIN
DECLARE @знижка DECIMAL(5,4)
IF (dbo.FuncClientType(@кодКлієнта)='Постійний')
	SET @знижка=0.1 --якщо Клієнт Постійний - 0.1
ELSE
	SET @знижка=0 --в іншому випадку - 0
RETURN @знижка
END
GO
CREATE FUNCTION FuncPenalty
(
	@стан_автомобіля NVARCHAR(45)
)
RETURNS DECIMAL(19,4)
AS --повертає значення Штрафу залежно від Стану авто
BEGIN
DECLARE @штраф INT
if(@стан_автомобіля='Неналежний')
	SET @штраф=500 --Якщо Неналежний - 500
ELSE
	SET @штраф=0 --В іншому випадку - 0
RETURN @штраф
END
GO
ALTER TABLE CarHires
ADD Discount AS(dbo.FuncDiscount(ClientId)),
	Penalty	AS(dbo.FuncPenalty(CarState))  
GO
CREATE FUNCTION FuncPrice
(
	@кодКлієнта INT,
	@кодАвтомобіля INT,
	@станАвтомобіля NVARCHAR(45),
	@датаВидачі DATETIME,
	@датаПовернення DATETIME		
)
RETURNS DECIMAL(19,4)
AS --Повертає ціну прокату, залежну від Строку прокату, Ціни однієї години, Знижки, Штрафу та Року випуску авто
BEGIN
DECLARE @знижка DECIMAL(5,4)
SET @знижка=dbo.FuncDiscount(@кодКлієнта)
DECLARE @штраф DECIMAL(19,4)
SET @штраф=dbo.FuncPenalty(@станАвтомобіля)
DECLARE @вартістьГодПрокату DECIMAL(19,4)
SET @вартістьГодПрокату =  (SELECT TOP(1) PricePerHour
							FROM Cars
							WHERE Id=@кодАвтомобіля)
DECLARE @вартістьХвПрокату DECIMAL(19,4)
SET @вартістьХвПрокату = @вартістьГодПрокату/60
DECLARE @рікВипуску INT
SET @рікВипуску =  (SELECT TOP(1) Year
					FROM Cars
					WHERE Id=@кодАвтомобіля)
DECLARE @кількістьХвилин INT
SET @кількістьХвилин=DATEDIFF(MINUTE,@датаВидачі,@датаПовернення)
DECLARE @вартістьПрокату DECIMAL(19,4)
SET @вартістьПрокату =	@кількістьХвилин*@вартістьХвПрокату-@кількістьХвилин*@вартістьХвПрокату*@знижка+@штраф-0.001*DATEDIFF(yyyy,@рікВипуску,GETDATE())
if (@вартістьПрокату<0)
SET @вартістьПрокату=0
RETURN @вартістьПрокату
END
GO
ALTER TABLE CarHires
ADD Price AS(dbo.FuncPrice(ClientId, CarId, CarState	, BeginDate, EndDate))  
GO
INSERT INTO Clients VALUES('Українець', 'Антон','Дмитрович',		'вул. Чернівецька 1','+38(050)0000001', 'Звичайний')
INSERT INTO Clients VALUES('Рябов', 'Леонід','Костянтинович',		'вул. Чернівецька 2','+38(050)0000002', 'Звичайний')
INSERT INTO Clients VALUES('Дунаєв', 'Богдан','Сергійович',			'вул. Чернівецька 3','+38(050)0000003', 'Звичайний')
INSERT INTO Clients VALUES('Кордон', 'Вадим','Сергійович',			'вул. Чернівецька 4','+38(050)0000004', 'Звичайний')
INSERT INTO Clients VALUES('Скібінський', 'Денис','Русланович',		'вул. Чернівецька 5','+38(050)0000005', 'Звичайний')
INSERT INTO Clients VALUES('Цинтар', 'Михайло','Ілліч',				'вул. Чернівецька 6','+38(050)0000006', 'Звичайний')
INSERT INTO Clients VALUES('Онуфрійчук', 'Андрій','Батькович',		'вул. Чернівецька 7','+38(050)0000007', 'Звичайний')
INSERT INTO Clients VALUES('Котюга', 'Андрій','Генадійович',		'вул. Чернівецька 8','+38(050)0000008', 'Звичайний')
INSERT INTO Clients VALUES('Потій', 'Андрій','Олегович',			'вул. Чернівецька 9','+38(050)0000009', 'Звичайний')
INSERT INTO Clients VALUES('Слободян', 'Олександр','Дмитрович',		'вул. Чернівецька 10','+38(050)0000010', 'Звичайний')
GO
INSERT INTO Cars VALUES('Volkswagen Passat B8 2.0 TDI AT',	38455,	38,	'Легковий',	2019)
INSERT INTO Cars VALUES('Skoda Octavia A7 New 1.4 TSI MT',	23789,	23,	'Легковий',	2019)
INSERT INTO Cars VALUES('Renault Sandero 1.5DCi 5MT',			14309,	14,	'Легковий',	2019)
INSERT INTO Cars VALUES('Mercedes-Benz GLE-Class 400d AT',	89999,	89,	'Грузовий',	2018)
INSERT INTO Cars VALUES('Toyota Corolla 1.6 AT',				20535,	20,	'Легковий',	2019)
INSERT INTO Cars VALUES('Opel Astra K 1.4 AT',				23383,	23,	'Легковий',	2018)
INSERT INTO Cars VALUES('Ford Kuga New 1.5D AT',				24802,	24,	'Легковий',	2019)
INSERT INTO Cars VALUES('BMW X5 25d Steptronic',				70561,	70,	'Легковий',	2019)
INSERT INTO Cars VALUES('Hyundai Kona Electric',				46500,	46,	'Електро',	2019)
INSERT INTO Cars VALUES('Hyundai Ioniq Electric',				29251,	29,	'Електро',	2018)
GO
/*
INSERT INTO CarHires VALUES(1,1,'2019-11-26 12:00','2019-11-26 13:30:00.000','Належний')
INSERT INTO CarHires VALUES(2,1,'2019-11-26 13:00','2019-11-26 14:30','Неналежний')
INSERT INTO CarHires VALUES(3,1,'2019-11-26 14:00','2019-11-26 15:30','Належний')
INSERT INTO CarHires VALUES(4,1,'2019-11-26 15:00','2019-11-26 16:30','Неналежний')
INSERT INTO CarHires VALUES(5,1,'2019-11-26 16:00','2019-11-26 17:30','Належний')
INSERT INTO CarHires VALUES(6,7,'2019-11-26 17:00','2019-11-26 18:30','Неналежний')
INSERT INTO CarHires VALUES(1,2,'2019-11-26 18:00','2019-11-26 19:30','Належний')
INSERT INTO CarHires VALUES(3,2,'2019-11-26 19:00','2019-11-26 20:30','Неналежний')
INSERT INTO CarHires VALUES(4,2,'2019-11-26 20:00','2019-11-26 21:30','Належний')
INSERT INTO CarHires VALUES(9,2,'2019-11-26 21:00','2019-11-26 22:30','Неналежний')
INSERT INTO CarHires VALUES(8,2,'2019-11-26 22:00','2019-11-26 23:30','Належний')
INSERT INTO CarHires VALUES(1,7,'2019-11-26 10:00','2019-11-26 11:30','Неналежний')
INSERT INTO CarHires VALUES(1,3,'2019-11-26 11:00','2019-11-26 12:30','Належний')
INSERT INTO CarHires VALUES(1,4,'2019-11-26 12:00','2019-11-26 13:30','Неналежний')
INSERT INTO CarHires VALUES(1,5,'2019-11-26 13:00','2019-11-26 14:30','Належний')
*/

INSERT INTO CarHires VALUES(1,1,'26.11.2019 12:00','26.11.2019 13:30:00.000','Належний')
INSERT INTO CarHires VALUES(2,1,'26.11.2019 13:00','26.11.2019 14:30','Неналежний')
INSERT INTO CarHires VALUES(3,1,'26.11.2019 14:00','26.11.2019 15:30','Належний')
INSERT INTO CarHires VALUES(4,1,'26.11.2019 15:00','26.11.2019 16:30','Неналежний')
INSERT INTO CarHires VALUES(5,1,'26.11.2019 16:00','26.11.2019 17:30','Належний')
INSERT INTO CarHires VALUES(6,7,'26.11.2019 17:00','26.11.2019 18:30','Неналежний')
INSERT INTO CarHires VALUES(1,2,'26.11.2019 18:00','26.11.2019 19:30','Належний')
INSERT INTO CarHires VALUES(3,2,'26.11.2019 19:00','26.11.2019 20:30','Неналежний')
INSERT INTO CarHires VALUES(4,2,'26.11.2019 20:00','26.11.2019 21:30','Належний')
INSERT INTO CarHires VALUES(9,2,'26.11.2019 21:00','26.11.2019 22:30','Неналежний')
INSERT INTO CarHires VALUES(8,2,'26.11.2019 22:00','26.11.2019 23:30','Належний')
INSERT INTO CarHires VALUES(1,7,'26.11.2019 10:00','26.11.2019 11:30','Неналежний')
INSERT INTO CarHires VALUES(1,3,'26.11.2019 11:00','26.11.2019 12:30','Належний')
INSERT INTO CarHires VALUES(1,4,'26.11.2019 12:00','26.11.2019 13:30','Неналежний')
INSERT INTO CarHires VALUES(1,5,'26.11.2019 13:00','26.11.2019 14:30','Належний')

GO
USE master
