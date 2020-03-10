CREATE DATABASE SQL4
GO
USE SQL4
GO
CREATE TABLE ClientTypes
(
Type NVARCHAR(45) NOT NULL PRIMARY KEY
)
GO
INSERT INTO ClientTypes VALUES('���������')
INSERT INTO ClientTypes VALUES('��������')
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
INSERT INTO CarTypes VALUES('��������')
INSERT INTO CarTypes VALUES('��������')
INSERT INTO CarTypes VALUES('�������')
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
INSERT INTO CarStates VALUES('��������')
INSERT INTO CarStates VALUES('����������')
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
	@����볺��� INT
)
RETURNS NVARCHAR(45)
AS --������� �������� ���� �볺��� ������� �� ����
BEGIN

--	DECLARE @myCount INT
	--SET @myCount = (SELECT COUNT(*)
		--			FROM ������_���������
			--		WHERE ������_���������.���_�볺���=@����볺���)
	DECLARE @����볺��� NVARCHAR(45)
	SET @����볺��� = (SELECT TypeOfClient FROM Clients WHERE @����볺���=Id)
	--if(@myCount>5) --������ 5 ������� - ��������
		--SET @����볺���='��������'
	--else --� ������ ������� - NULL
		--SET @����볺���=NULL*/
	RETURN @����볺���
END
--GO
--ALTER TABLE �볺���
--ADD ���_�볺���	AS(dbo.ClientType(���_�볺���)) 
GO
CREATE FUNCTION FuncDiscount
(
	@����볺��� INT
)
RETURNS DECIMAL(5,4)
AS --������� �������� ������ �� ����
BEGIN
DECLARE @������ DECIMAL(5,4)
IF (dbo.FuncClientType(@����볺���)='��������')
	SET @������=0.1 --���� �볺�� �������� - 0.1
ELSE
	SET @������=0 --� ������ ������� - 0
RETURN @������
END
GO
CREATE FUNCTION FuncPenalty
(
	@����_��������� NVARCHAR(45)
)
RETURNS DECIMAL(19,4)
AS --������� �������� ������ ������� �� ����� ����
BEGIN
DECLARE @����� INT
if(@����_���������='����������')
	SET @�����=500 --���� ���������� - 500
ELSE
	SET @�����=0 --� ������ ������� - 0
RETURN @�����
END
GO
ALTER TABLE CarHires
ADD Discount AS(dbo.FuncDiscount(ClientId)),
	Penalty	AS(dbo.FuncPenalty(CarState))  
GO
CREATE FUNCTION FuncPrice
(
	@����볺��� INT,
	@������������ INT,
	@������������� NVARCHAR(45),
	@���������� DATETIME,
	@�������������� DATETIME		
)
RETURNS DECIMAL(19,4)
AS --������� ���� �������, ������� �� ������ �������, ֳ�� ���� ������, ������, ������ �� ���� ������� ����
BEGIN
DECLARE @������ DECIMAL(5,4)
SET @������=dbo.FuncDiscount(@����볺���)
DECLARE @����� DECIMAL(19,4)
SET @�����=dbo.FuncPenalty(@�������������)
DECLARE @����������������� DECIMAL(19,4)
SET @����������������� =  (SELECT TOP(1) PricePerHour
							FROM Cars
							WHERE Id=@������������)
DECLARE @���������������� DECIMAL(19,4)
SET @���������������� = @�����������������/60
DECLARE @��������� INT
SET @��������� =  (SELECT TOP(1) Year
					FROM Cars
					WHERE Id=@������������)
DECLARE @������������� INT
SET @�������������=DATEDIFF(MINUTE,@����������,@��������������)
DECLARE @�������������� DECIMAL(19,4)
SET @�������������� =	@�������������*@����������������-@�������������*@����������������*@������+@�����-0.001*DATEDIFF(yyyy,@���������,GETDATE())
if (@��������������<0)
SET @��������������=0
RETURN @��������������
END
GO
ALTER TABLE CarHires
ADD Price AS(dbo.FuncPrice(ClientId, CarId, CarState	, BeginDate, EndDate))  
GO
INSERT INTO Clients VALUES('��������', '�����','���������',		'���. ���������� 1','+38(050)0000001', '���������')
INSERT INTO Clients VALUES('�����', '�����','�������������',		'���. ���������� 2','+38(050)0000002', '���������')
INSERT INTO Clients VALUES('�����', '������','���������',			'���. ���������� 3','+38(050)0000003', '���������')
INSERT INTO Clients VALUES('������', '�����','���������',			'���. ���������� 4','+38(050)0000004', '���������')
INSERT INTO Clients VALUES('���������', '�����','����������',		'���. ���������� 5','+38(050)0000005', '���������')
INSERT INTO Clients VALUES('������', '�������','����',				'���. ���������� 6','+38(050)0000006', '���������')
INSERT INTO Clients VALUES('���������', '�����','���������',		'���. ���������� 7','+38(050)0000007', '���������')
INSERT INTO Clients VALUES('������', '�����','����������',		'���. ���������� 8','+38(050)0000008', '���������')
INSERT INTO Clients VALUES('����', '�����','��������',			'���. ���������� 9','+38(050)0000009', '���������')
INSERT INTO Clients VALUES('��������', '���������','���������',		'���. ���������� 10','+38(050)0000010', '���������')
GO
INSERT INTO Cars VALUES('Volkswagen Passat B8 2.0 TDI AT',	38455,	38,	'��������',	2019)
INSERT INTO Cars VALUES('Skoda Octavia A7 New 1.4 TSI MT',	23789,	23,	'��������',	2019)
INSERT INTO Cars VALUES('Renault Sandero 1.5DCi 5MT',			14309,	14,	'��������',	2019)
INSERT INTO Cars VALUES('Mercedes-Benz GLE-Class 400d AT',	89999,	89,	'��������',	2018)
INSERT INTO Cars VALUES('Toyota Corolla 1.6 AT',				20535,	20,	'��������',	2019)
INSERT INTO Cars VALUES('Opel Astra K 1.4 AT',				23383,	23,	'��������',	2018)
INSERT INTO Cars VALUES('Ford Kuga New 1.5D AT',				24802,	24,	'��������',	2019)
INSERT INTO Cars VALUES('BMW X5 25d Steptronic',				70561,	70,	'��������',	2019)
INSERT INTO Cars VALUES('Hyundai Kona Electric',				46500,	46,	'�������',	2019)
INSERT INTO Cars VALUES('Hyundai Ioniq Electric',				29251,	29,	'�������',	2018)
GO
/*
INSERT INTO CarHires VALUES(1,1,'2019-11-26 12:00','2019-11-26 13:30:00.000','��������')
INSERT INTO CarHires VALUES(2,1,'2019-11-26 13:00','2019-11-26 14:30','����������')
INSERT INTO CarHires VALUES(3,1,'2019-11-26 14:00','2019-11-26 15:30','��������')
INSERT INTO CarHires VALUES(4,1,'2019-11-26 15:00','2019-11-26 16:30','����������')
INSERT INTO CarHires VALUES(5,1,'2019-11-26 16:00','2019-11-26 17:30','��������')
INSERT INTO CarHires VALUES(6,7,'2019-11-26 17:00','2019-11-26 18:30','����������')
INSERT INTO CarHires VALUES(1,2,'2019-11-26 18:00','2019-11-26 19:30','��������')
INSERT INTO CarHires VALUES(3,2,'2019-11-26 19:00','2019-11-26 20:30','����������')
INSERT INTO CarHires VALUES(4,2,'2019-11-26 20:00','2019-11-26 21:30','��������')
INSERT INTO CarHires VALUES(9,2,'2019-11-26 21:00','2019-11-26 22:30','����������')
INSERT INTO CarHires VALUES(8,2,'2019-11-26 22:00','2019-11-26 23:30','��������')
INSERT INTO CarHires VALUES(1,7,'2019-11-26 10:00','2019-11-26 11:30','����������')
INSERT INTO CarHires VALUES(1,3,'2019-11-26 11:00','2019-11-26 12:30','��������')
INSERT INTO CarHires VALUES(1,4,'2019-11-26 12:00','2019-11-26 13:30','����������')
INSERT INTO CarHires VALUES(1,5,'2019-11-26 13:00','2019-11-26 14:30','��������')
*/

INSERT INTO CarHires VALUES(1,1,'26.11.2019 12:00','26.11.2019 13:30:00.000','��������')
INSERT INTO CarHires VALUES(2,1,'26.11.2019 13:00','26.11.2019 14:30','����������')
INSERT INTO CarHires VALUES(3,1,'26.11.2019 14:00','26.11.2019 15:30','��������')
INSERT INTO CarHires VALUES(4,1,'26.11.2019 15:00','26.11.2019 16:30','����������')
INSERT INTO CarHires VALUES(5,1,'26.11.2019 16:00','26.11.2019 17:30','��������')
INSERT INTO CarHires VALUES(6,7,'26.11.2019 17:00','26.11.2019 18:30','����������')
INSERT INTO CarHires VALUES(1,2,'26.11.2019 18:00','26.11.2019 19:30','��������')
INSERT INTO CarHires VALUES(3,2,'26.11.2019 19:00','26.11.2019 20:30','����������')
INSERT INTO CarHires VALUES(4,2,'26.11.2019 20:00','26.11.2019 21:30','��������')
INSERT INTO CarHires VALUES(9,2,'26.11.2019 21:00','26.11.2019 22:30','����������')
INSERT INTO CarHires VALUES(8,2,'26.11.2019 22:00','26.11.2019 23:30','��������')
INSERT INTO CarHires VALUES(1,7,'26.11.2019 10:00','26.11.2019 11:30','����������')
INSERT INTO CarHires VALUES(1,3,'26.11.2019 11:00','26.11.2019 12:30','��������')
INSERT INTO CarHires VALUES(1,4,'26.11.2019 12:00','26.11.2019 13:30','����������')
INSERT INTO CarHires VALUES(1,5,'26.11.2019 13:00','26.11.2019 14:30','��������')

GO
USE master
