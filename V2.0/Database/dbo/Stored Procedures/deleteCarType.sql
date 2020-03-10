
CREATE PROCEDURE deleteCarType
	@Тип_автомобіля NVARCHAR(45)	
AS
BEGIN
DELETE
FROM CarTypes
WHERE Type=@Тип_автомобіля
END
