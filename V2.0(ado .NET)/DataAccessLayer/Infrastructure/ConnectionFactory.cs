using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccessLayer.Infrastructure
{
    public class ConnectionFactory: IConnectionFactory
    {
        private static string _connectionString;
        public void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection GetSqlConnection
        {
            get
            {
                SqlConnection connection;
                if (!string.IsNullOrEmpty(_connectionString))
                    connection = new SqlConnection(_connectionString);
                else
                    connection = new SqlConnection(MyConnection._connectionString);
//                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                connection.Open();
                return connection;
            }
        }
        

    }
}
