
CREATE PROCEDURE deleteCarState
	@Стан_автомобіля	NVARCHAR(45)	
AS
BEGIN
DELETE
FROM CarStates
WHERE State=@Стан_автомобіля
END
