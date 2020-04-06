using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.EntityInterfaces;
namespace DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity, TId> :IGenericRepository<TEntity,TId> where TEntity : IEntity<TId>
    {
        protected IConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly bool _isSoftDelete;
        public GenericRepository(IConnectionFactory connectionFactory, string tableName, bool isSoftDelete)
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
            _isSoftDelete = isSoftDelete;
        }
        public int Add(TEntity entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            //var stringOfProperties = string.Join(", ", columns.Select(e => "@" + e)); //так оно было
            //var stringOfProperties = string.Join(", ", columns.Select(e => $"'{typeof(TEntity).GetProperty(e).GetValue(entity)}'"));//так я сделаль но оно не пахало
            var query = "SP_InsertRecordToTable";
            //var query = "SP_GetInsertionRecordStatementToTable";//неизвестная функция

            //ща будет большой костыль
            List<string> listOfProperties = new List<string>();//мой рабочий костыль
            foreach (var col in columns)
            {
                var t = typeof(TEntity).GetProperty(col);
                string x;
                if (t.PropertyType == typeof(string))
                    x = $"'{t.GetValue(entity)}'";
                else
                {
                    x = $"{t.GetValue(entity)}";
                    x = x.Replace(',', '.');
                }
                listOfProperties.Add(x);
            }
            string stringOfProperties = string.Join(", ", listOfProperties);


            using (var db = _connectionFactory.GetSqlConnection)
            {
                //var InsertionStatement = db.Query<string>(
                //    sql: query,
                //    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                //    commandType: CommandType.StoredProcedure).FirstOrDefault();

                //var InsertedEntityId = db.Execute(
                //    sql: InsertionStatement,
                //    param: entity,
                //    commandType: CommandType.Text);

                //тут костыли
                SqlCommand sqlCommand = new SqlCommand(query,(SqlConnection)db);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@P_tableName",_tableName));
                sqlCommand.Parameters.Add(new SqlParameter("@P_columnsString",stringOfColumns));
                sqlCommand.Parameters.Add(new SqlParameter("@P_propertiesString",stringOfProperties));
                int InsertedEntityId = (int)sqlCommand.ExecuteScalar();
                return InsertedEntityId;
            }
        }

        public void Update(TEntity entity)
        {
            var columns = GetColumns();
            //var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}")); так оно было

            //var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = '{typeof(TEntity).GetProperty(e).GetValue(entity)}'"));//так я сделаль но оно не пахало

            List<string> listOfColumns = new List<string>();//мой рабочий костыль
            foreach(var col in columns)
            {
                var t = typeof(TEntity).GetProperty(col);
                string x;
                if (t.PropertyType == typeof(string))
                    x = $"{col} = '{t.GetValue(entity)}'";
                else
                {
                    x = $"{col} = {t.GetValue(entity)}";
                    x=x.Replace(',', '.');
                }                    
                listOfColumns.Add(x);
            }
            string stringOfColumns = string.Join(", ",listOfColumns);

            

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "SP_UpdateRecordInTable";//мои костыли
                SqlCommand sqlCommand = new SqlCommand(query,(SqlConnection)db);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@P_tableName", _tableName));
                sqlCommand.Parameters.Add(new SqlParameter("@P_columnsString", stringOfColumns));
                sqlCommand.Parameters.Add(new SqlParameter("@P_Id", entity.Id));
                sqlCommand.ExecuteNonQuery();

                //var query = "SP_UpdateRecordStatementInTable";//неизвестная функция

                //так было
                //var UpdateStatement = db.Query<string>(
                //    sql: query,
                //    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_Id = entity.Id },
                //    commandType: CommandType.StoredProcedure).FirstOrDefault();
                //db.Execute(
                //    sql: UpdateStatement,
                //    param: entity,
                //    commandType: CommandType.Text);
            }
        }

        public void Delete(TId id)
        {
            if (_isSoftDelete) // applying soft delete
            {
                //var columns = GetColumns();
                //var isActiveColumnUpdateString = columns.Where(e => e == "IsActive").Select(e => $"{e} = 0").FirstOrDefault();

                //using (var db = _connectionFactory.GetSqlConnection)
                //{
                //    var query = "SP_UnActivateRecordInTable";
                //    //var query = "SP_UnActivateRecordStatementInTable";

                //    var UnActivateStatement = db.Query<string>(
                //        sql: query,
                //        param: new { P_tableName = _tableName, P_columnsString = isActiveColumnUpdateString, P_Id = entity.Id },
                //        commandType: CommandType.StoredProcedure).FirstOrDefault();

                //    db.Execute(
                //        sql: UnActivateStatement,
                //        param: entity,
                //        commandType: CommandType.Text);
                //}
            }
            else // delete directly
            {
                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var query = "SP_DeleteRecordFromTable";
                    var result = db.Execute(
                        sql: query,
                        param: new { P_tableName = _tableName, P_Id = id },
                        commandType: CommandType.StoredProcedure);
                }
            }
        }

        public TEntity Get(TId Id)
        {
            var query = "SP_GetRecordByIdFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query,
                    new { P_tableName = _tableName, P_Id = Id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = "SP_GetAllRecordsFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query,
                    new { P_tableName = _tableName },
                    commandType: CommandType.StoredProcedure);
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }
    }
}
