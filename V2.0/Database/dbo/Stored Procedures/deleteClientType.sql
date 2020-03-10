
CREATE PROCEDURE deleteClientType
	@Тип_клієнта NVARCHAR(45)
AS
BEGIN
DELETE
FROM ClientTypes
WHERE Type=@Тип_клієнта
END
