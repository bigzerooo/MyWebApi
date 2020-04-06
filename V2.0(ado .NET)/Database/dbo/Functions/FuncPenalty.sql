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
