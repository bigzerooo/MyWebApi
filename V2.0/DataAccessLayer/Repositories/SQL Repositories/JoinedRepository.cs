using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DataAccessLayer.Repositories.SQL_Repositories
{
    public class JoinedRepository: GenericRepository<Joined, int>, IJoinedRepository
    {
        private static readonly string _tableName = "";
        private static readonly bool _isSoftDelete = false;
        public JoinedRepository(IConnectionFactory connectionFactory) : base(connectionFactory, _tableName, _isSoftDelete)
        {            
            //connectionFactory.SetConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connectionFactory.SetConnection(MyConnection._connectionString);
        }
        public int AddJoined(Joined joined)
        {
            string query = "dbo.JoinInsert";
            using (var db=_connectionFactory.GetSqlConnection)
            {
                return db.Query<int>(query, new 
                {
                    joined.Brand,
                    joined.CarPrice,
                    joined.PricePerHour,
                    joined.Type,
                    joined.Year,
                    joined.LastName,
                    joined.FirstName,
                    joined.SecondName,
                    joined.Adress,
                    joined.PhoneNumber,
                    joined.TypeOfClient,
                    joined.BeginDate,
                    joined.EndDate,
                    joined.CarState
                }, commandType: CommandType.StoredProcedure).First();
            }
            
        }
        public void UpdateJoined(Joined joined)
        {
            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "JoinUpdate";
                db.Execute(query, new
                {
                    joined.Id,
                    joined.CarId,
                    joined.Brand,
                    joined.CarPrice,
                    joined.PricePerHour,
                    joined.Type,
                    joined.Year,
                    joined.ClientId,
                    joined.LastName,
                    joined.FirstName,
                    joined.SecondName,
                    joined.Adress,
                    joined.PhoneNumber,
                    joined.TypeOfClient,
                    joined.BeginDate,
                    joined.EndDate,
                    joined.CarState
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteJoined(int Id)
        {
            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "JoinDelete";
                db.Execute(query, new { Id }, commandType: CommandType.StoredProcedure);
            }
        }
        public Joined GetJoinedById(int Id)
        {
            string query = "dbo.JoinGetById";
            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<Joined>(query, new { Id }, commandType: CommandType.StoredProcedure).First();
            }
        }
        public IEnumerable<Joined> GetAllJoined()
        {
            string query = "dbo.JoinGet";                        
            using (var db = _connectionFactory.GetSqlConnection)
            {                                
                return db.Query<Joined>(query, new { }, commandType: CommandType.StoredProcedure);                
            }
           
        }

    }
}
