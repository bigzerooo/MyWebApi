USE SQL4
GO
CREATE PROCEDURE createClientType
	@Тип_клієнта NVARCHAR(45)
AS
BEGIN
INSERT INTO Тип_клієнта VALUES(@Тип_клієнта)
END
GO

CREATE PROCEDURE createCarType
	@Тип_автомобіля NVARCHAR(45)	
AS
BEGIN
INSERT INTO Тип_автомобіля VALUES(@Тип_автомобіля)
END
GO

CREATE PROCEDURE createCarState
	@Стан_автомобіля	NVARCHAR(45)	
AS
BEGIN
INSERT INTO Стан_автомобіля VALUES(@Стан_автомобіля)
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
INSERT INTO Клієнти VALUES(@Прізвище, @Імя, @Побатькові, @Адреса, @Телефон, @Тип_клієнта)
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
INSERT INTO Автомобілі VALUES(@Марка, @Вартість_автомобіля,@Вартість_години_прокату,@Тип_автомобіля,@Рік_випуску)
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
INSERT INTO Прокат_автомобілів VALUES(@Код_автомобіля,@Код_клієнта,@Дата_видачі,@Дата_повернення,@Стан_автомобіля)
END
GO

CREATE PROCEDURE readAll
AS
BEGIN
SELECT Код_прокату, Прокат_автомобілів.Код_автомобіля, Марка, Вартість_автомобіля, Вартість_години_прокату,
	Тип_автомобіля,Рік_випуску, Прокат_автомобілів.Код_клієнта, Прізвище, [Ім'я], [По-батькові], Адреса, Телефон, 
	Тип_клієнта, Дата_видачі, Дата_повернення, Стан_автомобіля, Знижка, Штраф, Вартість_прокату
FROM Прокат_автомобілів
	JOIN Клієнти
	ON Клієнти.Код_клієнта=Прокат_автомобілів.Код_клієнта
	JOIN Автомобілі
	ON Автомобілі.Код_автомобіля=Прокат_автомобілів.Код_автомобіля
END
GO

CREATE PROCEDURE readAllCar
AS
BEGIN
SELECT * FROM Автомобілі
END
GO

CREATE PROCEDURE readAllClient
AS
BEGIN
SELECT * FROM Клієнти
END
GO

CREATE PROCEDURE readAllById
@Id INT
AS
BEGIN
SELECT Код_прокату, Прокат_автомобілів.Код_автомобіля, Марка, Вартість_автомобіля, Вартість_години_прокату,
	Тип_автомобіля,Рік_випуску, Прокат_автомобілів.Код_клієнта, Прізвище, [Ім'я], [По-батькові], Адреса, Телефон, 
	Тип_клієнта, Дата_видачі, Дата_повернення, Стан_автомобіля, Знижка, Штраф, Вартість_прокату
FROM Прокат_автомобілів
	JOIN Клієнти
	ON Клієнти.Код_клієнта=Прокат_автомобілів.Код_клієнта
	JOIN Автомобілі
	ON Автомобілі.Код_автомобіля=Прокат_автомобілів.Код_автомобіля
WHERE Код_прокату=@Id
END
GO

CREATE PROCEDURE readCarById
@Id INT
AS
BEGIN
SELECT * FROM Автомобілі
WHERE Код_автомобіля=@Id
END
GO

CREATE PROCEDURE readClientById
@Id INT
AS
BEGIN
SELECT * FROM Клієнти
WHERE Код_клієнта=@Id
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
UPDATE Автомобілі
SET	
	Марка=@Марка,
	Вартість_автомобіля=@Вартість_автомобіля,
	Вартість_години_прокату=@Вартість_години_прокату,
	Тип_автомобіля=@Тип_автомобіля,
	Рік_випуску=@Рік_випуску
WHERE Код_автомобіля=@Id
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
UPDATE Клієнти
SET 
	Прізвище=@Прізвище,
	[Ім'я]=@Імя,
	[По-батькові]=@Побатькові,
	Адреса=@Адреса,
	Телефон=@Телефон,
	Тип_клієнта=@Тип_клієнта
WHERE Код_клієнта=@Id
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
UPDATE Прокат_автомобілів
SET
	Код_автомобіля=@Код_автомобіля,
	Код_клієнта=@Код_клієнта,
	Дата_видачі=@Дата_видачі,
	Дата_повернення=@Дата_повернення,
	Стан_автомобіля=@Стан_автомобіля
WHERE Код_прокату=@Id
END
GO

CREATE PROCEDURE deleteClientType
	@Тип_клієнта NVARCHAR(45)
AS
BEGIN
DELETE
FROM Тип_клієнта
WHERE Тип_клієнта=@Тип_клієнта
END
GO

CREATE PROCEDURE deleteCarType
	@Тип_автомобіля NVARCHAR(45)	
AS
BEGIN
DELETE
FROM Тип_автомобіля
WHERE Тип_автомобіля=@Тип_автомобіля
END
GO

CREATE PROCEDURE deleteCarState
	@Стан_автомобіля	NVARCHAR(45)	
AS
BEGIN
DELETE
FROM Стан_автомобіля
WHERE Стан_автомобіля=@Стан_автомобіля
END
GO

CREATE PROCEDURE deleteCar
	@Id INT
AS
BEGIN
DELETE
FROM Автомобілі
WHERE Код_автомобіля=@Id
END
GO

CREATE PROCEDURE deleteClient
	@Id INT
AS
BEGIN
DELETE
FROM Клієнти
WHERE Код_клієнта=@Id
END
GO

CREATE PROCEDURE deleteCarHire
	@Id INT
AS
BEGIN
DELETE
FROM Прокат_автомобілів
WHERE Код_прокату=@Id
END
GO

USE master
GO
