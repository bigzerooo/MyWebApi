
CREATE PROCEDURE createCar	
	@Марка						NVARCHAR(45),
	@Вартість_автомобіля		DECIMAL(19,4),
	@Вартість_години_прокату	DECIMAL(19,4),
	@Тип_автомобіля				NVARCHAR(45),
	@Рік_випуску				INT
AS
BEGIN
INSERT INTO Cars VALUES(@Марка, @Вартість_автомобіля,@Вартість_години_прокату,@Тип_автомобіля,@Рік_випуску)
END
