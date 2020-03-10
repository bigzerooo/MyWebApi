
CREATE PROCEDURE createClient	
	@Прізвище		NVARCHAR(45),
	@Імя			NVARCHAR(45),
	@Побатькові		NVARCHAR(45),
	@Адреса			NVARCHAR(45),
	@Телефон		NVARCHAR(45),
	@Тип_клієнта	NVARCHAR(45)
AS
BEGIN
INSERT INTO Clients VALUES(@Прізвище, @Імя, @Побатькові, @Адреса, @Телефон, @Тип_клієнта)
END
