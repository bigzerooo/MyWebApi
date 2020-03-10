CREATE PROCEDURE createClientType
	@Тип_клієнта NVARCHAR(45)
AS
BEGIN
INSERT INTO ClientTypes VALUES(@Тип_клієнта)
END
