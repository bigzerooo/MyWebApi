USE SQL4
GO
CREATE PROCEDURE createClientType
	@���_�볺��� NVARCHAR(45)
AS
BEGIN
INSERT INTO ���_�볺��� VALUES(@���_�볺���)
END
GO

CREATE PROCEDURE createCarType
	@���_��������� NVARCHAR(45)	
AS
BEGIN
INSERT INTO ���_��������� VALUES(@���_���������)
END
GO

CREATE PROCEDURE createCarState
	@����_���������	NVARCHAR(45)	
AS
BEGIN
INSERT INTO ����_��������� VALUES(@����_���������)
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
INSERT INTO �볺��� VALUES(@�������, @���, @���������, @������, @�������, @���_�볺���)
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
INSERT INTO �������� VALUES(@�����, @�������_���������,@�������_������_�������,@���_���������,@г�_�������)
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
INSERT INTO ������_��������� VALUES(@���_���������,@���_�볺���,@����_������,@����_����������,@����_���������)
END
GO

CREATE PROCEDURE readAll
AS
BEGIN
SELECT ���_�������, ������_���������.���_���������, �����, �������_���������, �������_������_�������,
	���_���������,г�_�������, ������_���������.���_�볺���, �������, [��'�], [��-�������], ������, �������, 
	���_�볺���, ����_������, ����_����������, ����_���������, ������, �����, �������_�������
FROM ������_���������
	JOIN �볺���
	ON �볺���.���_�볺���=������_���������.���_�볺���
	JOIN ��������
	ON ��������.���_���������=������_���������.���_���������
END
GO

CREATE PROCEDURE readAllCar
AS
BEGIN
SELECT * FROM ��������
END
GO

CREATE PROCEDURE readAllClient
AS
BEGIN
SELECT * FROM �볺���
END
GO

CREATE PROCEDURE readAllById
@Id INT
AS
BEGIN
SELECT ���_�������, ������_���������.���_���������, �����, �������_���������, �������_������_�������,
	���_���������,г�_�������, ������_���������.���_�볺���, �������, [��'�], [��-�������], ������, �������, 
	���_�볺���, ����_������, ����_����������, ����_���������, ������, �����, �������_�������
FROM ������_���������
	JOIN �볺���
	ON �볺���.���_�볺���=������_���������.���_�볺���
	JOIN ��������
	ON ��������.���_���������=������_���������.���_���������
WHERE ���_�������=@Id
END
GO

CREATE PROCEDURE readCarById
@Id INT
AS
BEGIN
SELECT * FROM ��������
WHERE ���_���������=@Id
END
GO

CREATE PROCEDURE readClientById
@Id INT
AS
BEGIN
SELECT * FROM �볺���
WHERE ���_�볺���=@Id
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
UPDATE ��������
SET	
	�����=@�����,
	�������_���������=@�������_���������,
	�������_������_�������=@�������_������_�������,
	���_���������=@���_���������,
	г�_�������=@г�_�������
WHERE ���_���������=@Id
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
UPDATE �볺���
SET 
	�������=@�������,
	[��'�]=@���,
	[��-�������]=@���������,
	������=@������,
	�������=@�������,
	���_�볺���=@���_�볺���
WHERE ���_�볺���=@Id
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
UPDATE ������_���������
SET
	���_���������=@���_���������,
	���_�볺���=@���_�볺���,
	����_������=@����_������,
	����_����������=@����_����������,
	����_���������=@����_���������
WHERE ���_�������=@Id
END
GO

CREATE PROCEDURE deleteClientType
	@���_�볺��� NVARCHAR(45)
AS
BEGIN
DELETE
FROM ���_�볺���
WHERE ���_�볺���=@���_�볺���
END
GO

CREATE PROCEDURE deleteCarType
	@���_��������� NVARCHAR(45)	
AS
BEGIN
DELETE
FROM ���_���������
WHERE ���_���������=@���_���������
END
GO

CREATE PROCEDURE deleteCarState
	@����_���������	NVARCHAR(45)	
AS
BEGIN
DELETE
FROM ����_���������
WHERE ����_���������=@����_���������
END
GO

CREATE PROCEDURE deleteCar
	@Id INT
AS
BEGIN
DELETE
FROM ��������
WHERE ���_���������=@Id
END
GO

CREATE PROCEDURE deleteClient
	@Id INT
AS
BEGIN
DELETE
FROM �볺���
WHERE ���_�볺���=@Id
END
GO

CREATE PROCEDURE deleteCarHire
	@Id INT
AS
BEGIN
DELETE
FROM ������_���������
WHERE ���_�������=@Id
END
GO

USE master
GO
