	CREATE PROCEDURE Pagination
	@tableName NVARCHAR(50),
	@pageNumber INT,
	@objectsNumber INT
	AS
	BEGIN		
	declare @sql as NVARCHAR(MAX)=NULL
	select @sql=   'SELECT * 
					FROM 
					( SELECT ROW_NUMBER() OVER (ORDER BY Id) AS row_id, * FROM '+@tableName+')
					as z 
					WHERE z.row_id BETWEEN '
					+CAST((1+(@pageNumber-1)*@objectsNumber) as nvarchar)+
					' AND '
					+cast(((@pageNumber-1)*@objectsNumber+@objectsNumber)as nvarchar)+';'
	exec (@sql)
	END
