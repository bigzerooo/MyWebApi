
CREATE PROCEDURE createCarState
	@Стан_автомобіля	NVARCHAR(45)	
AS
BEGIN
INSERT INTO CarStates VALUES(@Стан_автомобіля)
END
