CREATE PROCEDURE JoinDelete
@Id INT
AS
BEGIN
DECLARE @carId INT
DECLARE @clientId INT

SET @carId = (SELECT TOP(1) CarHires.CarId FROM CarHires where CarHires.Id=@Id)
SET @clientId = (SELECT TOP(1) CarHires.ClientId FROM CarHires where CarHires.Id=@Id)

EXEC SP_DeleteRecordFromTable CarHires, @Id
EXEC SP_DeleteRecordFromTable Cars, @carId
EXEC SP_DeleteRecordFromTable Clients, @clientId

END
