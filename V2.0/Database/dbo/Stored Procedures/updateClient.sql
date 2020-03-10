
CREATE PROCEDURE updateClient
	@Id INT,
	@Прізвище		NVARCHAR(45),
	@Імя			NVARCHAR(45),
	@Побатькові	NVARCHAR(45),
	@Адреса			NVARCHAR(45),
	@Телефон			NVARCHAR(45),
	@Тип_клієнта		NVARCHAR(45)
AS
BEGIN
UPDATE Clients
SET 
	LastName=@Прізвище,
	FirstName=@Імя,
	SecondName=@Побатькові,
	Adress=@Адреса,
	PhoneNumber=@Телефон,
	TypeOfClient=@Тип_клієнта
WHERE Id=@Id
END
