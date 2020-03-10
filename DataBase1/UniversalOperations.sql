USE SQL4
GO
CREATE PROCEDURE [dbo].[SP_InsertRecordToTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_columnsString nvarchar(MAX) = null, 
	@P_propertiesString nvarchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_columnsString is not null and @P_propertiesString is not null)
		select @V_sql = 'insert into ' + @V_table + ' (' + @P_columnsString + ') values (' + @P_propertiesString + ');
		 select cast(SCOPE_IDENTITY() as int);'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END
GO
CREATE PROCEDURE [dbo].[SP_UpdateRecordInTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_columnsString nvarchar(MAX) = null,
	@P_Id bigint = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_columnsString is not null and @P_Id is not null)
		select @V_sql = 'update ' + @V_table + ' set ' + @P_columnsString + ' where Id = ' + @P_Id + '; select 1;'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END
GO
CREATE PROCEDURE [dbo].[SP_UnActivateRecordInTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_columnsString nvarchar(MAX) = null,
	@P_Id bigint = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_columnsString is not null and @P_Id is not null)
		select @V_sql = 'update ' + @V_table + ' set ' + @P_columnsString + ' where Id = ' + @P_Id + ';'

	if(@V_sql is not null)
		exec(@V_sql)
END
GO
CREATE PROCEDURE [dbo].[SP_DeleteRecordFromTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_Id int = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_Id is not null)
		select @V_sql = 'delete from ' + @V_table + 'where Id = ' + @P_Id + '; select 1;'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select 0;
END
GO
CREATE PROCEDURE [dbo].[SP_GetAllRecordsFromTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null)
		select @V_sql = 'select * from ' + @V_table + ';'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END
GO
CREATE PROCEDURE [dbo].[SP_GetRecordByIdFromTable]
	-- Add the parameters for the stored procedure here
	@P_tableName nvarchar(50) = null,
	@P_Id bigint = null
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @V_table nvarchar(50) = null
	if (@P_tableName is not null)
		select @V_table = QUOTENAME( TABLE_NAME )
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = @P_tableName

	declare @V_sql as nvarchar(MAX) = null
	if (@V_table is not null and @P_Id is not null)
		select @V_sql = 'select * from ' + @V_table + ' where Id = ' + @P_Id + ';'

	if(@V_sql is not null)
		exec(@V_sql)
	else
		select -1;
END
GO
use master
GO
