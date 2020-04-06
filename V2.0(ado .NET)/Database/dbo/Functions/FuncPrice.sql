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
