
CREATE PROCEDURE readAllById
@Id INT
AS
BEGIN
SELECT CarHires.Id, CarId, Brand, Cars.Price, PricePerHour,
	Cars.Type, Year, ClientId, LastName, FirstName, SecondName, Adress, PhoneNumber, 
	TypeOfClient, BeginDate, EndDate, CarState, Discount, Penalty, CarHires.Price
FROM CarHires
	JOIN Clients
	ON Clients.Id=CarHires.ClientId
	JOIN Cars
	ON Cars.Id=CarHires.CarId
WHERE CarHires.Id=@Id
END
