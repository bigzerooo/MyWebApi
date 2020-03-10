CREATE DATABASE SQL4
GO
USE SQL4
GO
CREATE TABLE ���_�볺���
(
���_�볺��� NVARCHAR(45) NOT NULL PRIMARY KEY
)
GO
INSERT INTO ���_�볺��� VALUES('���������')
INSERT INTO ���_�볺��� VALUES('��������')
GO
CREATE TABLE �볺���
(
���_�볺���		INT				NOT NULL	IDENTITY(1,1) PRIMARY KEY,
�������		NVARCHAR(45)	NOT NULL,
[��'�]			NVARCHAR(45)	NOT NULL,
[��-�������]	NVARCHAR(45)	NOT NULL,
������			NVARCHAR(45)	NULL,
�������			NVARCHAR(45)	NULL		CHECK(������� LIKE '+38([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
���_�볺���		NVARCHAR(45)	NULL		REFERENCES ���_�볺���(���_�볺���) ON DELETE CASCADE DEFAULT '���������' 
)
GO
CREATE TABLE ���_���������
(
���_��������� NVARCHAR(45) NOT NULL PRIMARY KEY
)
GO
INSERT INTO ���_��������� VALUES('��������')
INSERT INTO ���_��������� VALUES('��������')
INSERT INTO ���_��������� VALUES('�������')
GO
CREATE TABLE ��������
(
���_���������			INT				NOT NULL	IDENTITY(1,1) PRIMARY KEY,
�����					NVARCHAR(45)	NOT NULL,
�������_���������		DECIMAL(19,4)	NOT NULL,
�������_������_������� DECIMAL(19,4)	NOT NULL,
���_���������			NVARCHAR(45)	NULL		REFERENCES ���_���������(���_���������) ON DELETE CASCADE,
г�_�������				INT				NULL		CHECK(г�_�������>=1900 AND г�_�������<=YEAR(GETDATE()))
)
GO
CREATE TABLE ����_���������
(
����_���������	NVARCHAR(45) NOT NULL PRIMARY KEY
)
GO
INSERT INTO ����_��������� VALUES('��������')
INSERT INTO ����_��������� VALUES('����������')
GO
CREATE TABLE ������_���������
(
���_�������			INT				NOT NULL IDENTITY(1,1) PRIMARY KEY,
���_���������		INT				NOT NULL REFERENCES �������� (���_���������)		ON DELETE CASCADE,
���_�볺���			INT				NOT NULL REFERENCES �볺��� (���_�볺���)			ON DELETE CASCADE,
����_������			DATETIME		NOT NULL CHECK(����_������<=GETDATE()),
����_����������		DATETIME		NOT NULL CHECK(����_����������<=GETDATE()),
����_���������		NVARCHAR(45)	NOT NULL REFERENCES ����_���������(����_���������)ON DELETE CASCADE,
CHECK(����_������<=����_����������)
)
GO

CREATE FUNCTION ClientType
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
	SET @����볺��� = (SELECT ���_�볺��� FROM �볺��� WHERE @����볺���=���_�볺���)
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
CREATE FUNCTION Discount
(
	@����볺��� INT
)
RETURNS DECIMAL(5,4)
AS --������� �������� ������ �� ����
BEGIN
DECLARE @������ DECIMAL(5,4)
IF (dbo.ClientType(@����볺���)='��������')
	SET @������=0.1 --���� �볺�� �������� - 0.1
ELSE
	SET @������=0 --� ������ ������� - 0
RETURN @������
END
GO
CREATE FUNCTION Penalty
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
ALTER TABLE ������_���������
ADD ������	AS(dbo.Discount(���_�볺���)),
	�����	AS(dbo.Penalty(����_���������))  
GO
CREATE FUNCTION Price
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
SET @������=dbo.Discount(@����볺���)
DECLARE @����� DECIMAL(19,4)
SET @�����=dbo.Penalty(@�������������)
DECLARE @����������������� DECIMAL(19,4)
SET @����������������� =  (SELECT TOP(1) �������_������_�������
							FROM ��������
							WHERE ���_���������=@������������)
DECLARE @���������������� DECIMAL(19,4)
SET @���������������� = @�����������������/60
DECLARE @��������� INT
SET @��������� =  (SELECT TOP(1) г�_�������
					FROM ��������
					WHERE ���_���������=@������������)
DECLARE @������������� INT
SET @�������������=DATEDIFF(MINUTE,@����������,@��������������)
DECLARE @�������������� DECIMAL(19,4)
SET @�������������� =	@�������������*@����������������-@�������������*@����������������*@������+@�����-0.001*DATEDIFF(yyyy,@���������,GETDATE())
if (@��������������<0)
SET @��������������=0
RETURN @��������������
END
GO
ALTER TABLE ������_���������
ADD �������_������� AS(dbo.Price(���_�볺���,���_���������,����_���������,����_������,����_����������))  
GO
INSERT INTO �볺��� VALUES('��������', '�����','���������',		'���. ���������� 1','+38(050)0000001', '���������')
INSERT INTO �볺��� VALUES('�����', '�����','�������������',		'���. ���������� 2','+38(050)0000002', '���������')
INSERT INTO �볺��� VALUES('�����', '������','���������',			'���. ���������� 3','+38(050)0000003', '���������')
INSERT INTO �볺��� VALUES('������', '�����','���������',			'���. ���������� 4','+38(050)0000004', '���������')
INSERT INTO �볺��� VALUES('���������', '�����','����������',		'���. ���������� 5','+38(050)0000005', '���������')
INSERT INTO �볺��� VALUES('������', '�������','����',				'���. ���������� 6','+38(050)0000006', '���������')
INSERT INTO �볺��� VALUES('���������', '�����','���������',		'���. ���������� 7','+38(050)0000007', '���������')
INSERT INTO �볺��� VALUES('������', '�����','����������',		'���. ���������� 8','+38(050)0000008', '���������')
INSERT INTO �볺��� VALUES('����', '�����','��������',			'���. ���������� 9','+38(050)0000009', '���������')
INSERT INTO �볺��� VALUES('��������', '���������','���������',		'���. ���������� 10','+38(050)0000010', '���������')
GO
INSERT INTO �������� VALUES('Volkswagen Passat B8 2.0 TDI AT',	38455,	38,	'��������',	2019)
INSERT INTO �������� VALUES('Skoda Octavia A7 New 1.4 TSI MT',	23789,	23,	'��������',	2019)
INSERT INTO �������� VALUES('Renault Sandero 1.5DCi 5MT',			14309,	14,	'��������',	2019)
INSERT INTO �������� VALUES('Mercedes-Benz GLE-Class 400d AT',	89999,	89,	'��������',	2018)
INSERT INTO �������� VALUES('Toyota Corolla 1.6 AT',				20535,	20,	'��������',	2019)
INSERT INTO �������� VALUES('Opel Astra K 1.4 AT',				23383,	23,	'��������',	2018)
INSERT INTO �������� VALUES('Ford Kuga New 1.5D AT',				24802,	24,	'��������',	2019)
INSERT INTO �������� VALUES('BMW X5 25d Steptronic',				70561,	70,	'��������',	2019)
INSERT INTO �������� VALUES('Hyundai Kona Electric',				46500,	46,	'�������',	2019)
INSERT INTO �������� VALUES('Hyundai Ioniq Electric',				29251,	29,	'�������',	2018)
GO
INSERT INTO ������_��������� VALUES(1,1,'26.11.2019 12:00','26.11.2019 13:30:00.000','��������')
INSERT INTO ������_��������� VALUES(2,1,'26.11.2019 13:00','26.11.2019 14:30','����������')
INSERT INTO ������_��������� VALUES(3,1,'26.11.2019 14:00','26.11.2019 15:30','��������')
INSERT INTO ������_��������� VALUES(4,1,'26.11.2019 15:00','26.11.2019 16:30','����������')
INSERT INTO ������_��������� VALUES(5,1,'26.11.2019 16:00','26.11.2019 17:30','��������')
INSERT INTO ������_��������� VALUES(6,7,'26.11.2019 17:00','26.11.2019 18:30','����������')
INSERT INTO ������_��������� VALUES(1,2,'26.11.2019 18:00','26.11.2019 19:30','��������')
INSERT INTO ������_��������� VALUES(3,2,'26.11.2019 19:00','26.11.2019 20:30','����������')
INSERT INTO ������_��������� VALUES(4,2,'26.11.2019 20:00','26.11.2019 21:30','��������')
INSERT INTO ������_��������� VALUES(9,2,'26.11.2019 21:00','26.11.2019 22:30','����������')
INSERT INTO ������_��������� VALUES(8,2,'26.11.2019 22:00','26.11.2019 23:30','��������')
INSERT INTO ������_��������� VALUES(1,7,'26.11.2019 10:00','26.11.2019 11:30','����������')
INSERT INTO ������_��������� VALUES(1,3,'26.11.2019 11:00','26.11.2019 12:30','��������')
INSERT INTO ������_��������� VALUES(1,4,'26.11.2019 12:00','26.11.2019 13:30','����������')
INSERT INTO ������_��������� VALUES(1,5,'26.11.2019 13:00','26.11.2019 14:30','��������')
/*
INSERT INTO ������_��������� VALUES(1,1,1,'2019-11-26 12:00','2019-11-26 13:30:00.000','��������')
INSERT INTO ������_��������� VALUES(2,2,1,'2019-11-26 13:00','2019-11-26 14:30','����������')
INSERT INTO ������_��������� VALUES(3,3,1,'2019-11-26 14:00','2019-11-26 15:30','��������')
INSERT INTO ������_��������� VALUES(4,4,1,'2019-11-26 15:00','2019-11-26 16:30','����������')
INSERT INTO ������_��������� VALUES(5,5,1,'2019-11-26 16:00','2019-11-26 17:30','��������')
INSERT INTO ������_��������� VALUES(6,6,7,'2019-11-26 17:00','2019-11-26 18:30','����������')
INSERT INTO ������_��������� VALUES(7,1,2,'2019-11-26 18:00','2019-11-26 19:30','��������')
INSERT INTO ������_��������� VALUES(8,3,2,'2019-11-26 19:00','2019-11-26 20:30','����������')
INSERT INTO ������_��������� VALUES(9,4,2,'2019-11-26 20:00','2019-11-26 21:30','��������')
INSERT INTO ������_��������� VALUES(10,9,2,'2019-11-26 21:00','2019-11-26 22:30','����������')
INSERT INTO ������_��������� VALUES(11,8,2,'2019-11-26 22:00','2019-11-26 23:30','��������')
INSERT INTO ������_��������� VALUES(12,1,7,'2019-11-26 10:00','2019-11-26 11:30','����������')
INSERT INTO ������_��������� VALUES(13,1,3,'2019-11-26 11:00','2019-11-26 12:30','��������')
INSERT INTO ������_��������� VALUES(14,1,4,'2019-11-26 12:00','2019-11-26 13:30','����������')
INSERT INTO ������_��������� VALUES(15,1,5,'2019-11-26 13:00','2019-11-26 14:30','��������')
*/
GO
USE master
