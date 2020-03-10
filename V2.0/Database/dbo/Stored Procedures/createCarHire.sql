
CREATE PROCEDURE createCarHire
	@Код_автомобіля			INT,
	@Код_клієнта			INT,
	@Дата_видачі			DATETIME,
	@Дата_повернення		DATETIME,
	@Стан_автомобіля		NVARCHAR(45)
AS
BEGIN
INSERT INTO CarHires VALUES(@Код_автомобіля,@Код_клієнта,@Дата_видачі,@Дата_повернення,@Стан_автомобіля)
END
