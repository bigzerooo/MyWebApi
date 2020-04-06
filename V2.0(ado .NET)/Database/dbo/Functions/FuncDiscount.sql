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
