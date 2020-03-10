
CREATE PROCEDURE updateCarHire
	@Id INT,
	@Код_автомобіля		INT,
	@Код_клієнта			INT,
	@Дата_видачі			DATETIME,
	@Дата_повернення		DATETIME,
	@Стан_автомобіля		NVARCHAR(45)
AS
BEGIN
UPDATE CarHires
SET
	CarId=@Код_автомобіля,
	ClientId=@Код_клієнта,
	BeginDate=@Дата_видачі,
	EndDate=@Дата_повернення,
	CarState=@Стан_автомобіля
WHERE Id=@Id
END
