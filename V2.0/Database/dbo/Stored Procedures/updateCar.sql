
CREATE PROCEDURE updateCar
	@Id INT,
	@Марка					NVARCHAR(45),
	@Вартість_автомобіля		DECIMAL(19,4),
	@Вартість_години_прокату DECIMAL(19,4),
	@Тип_автомобіля			NVARCHAR(45),
	@Рік_випуску				INT
AS
BEGIN
UPDATE Cars
SET	
	Brand=@Марка,
	Price=@Вартість_автомобіля,
	PricePerHour=@Вартість_години_прокату,
	Type=@Тип_автомобіля,
	Year=@Рік_випуску
WHERE Id=@Id
END
