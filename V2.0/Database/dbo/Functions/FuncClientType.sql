
CREATE FUNCTION FuncClientType
(
	@кодКлієнта INT
)
RETURNS NVARCHAR(45)
AS --Повертає значення типу клієнта залежно від коду
BEGIN

--	DECLARE @myCount INT
	--SET @myCount = (SELECT COUNT(*)
		--			FROM Прокат_автомобілів
			--		WHERE Прокат_автомобілів.Код_клієнта=@кодКлієнта)
	DECLARE @типКлієнта NVARCHAR(45)
	SET @типКлієнта = (SELECT TypeOfClient FROM Clients WHERE @кодКлієнта=Id)
	--if(@myCount>5) --Більше 5 прокатів - Постійний
		--SET @типКлієнта='Постійний'
	--else --В іншому випадку - NULL
		--SET @типКлієнта=NULL*/
	RETURN @типКлієнта
END
--GO
--ALTER TABLE Клієнти
--ADD Тип_клієнта	AS(dbo.ClientType(Код_клієнта)) 
