
CREATE PROCEDURE createCarType
	@Тип_автомобіля NVARCHAR(45)	
AS
BEGIN
INSERT INTO CarTypes VALUES(@Тип_автомобіля)
END
