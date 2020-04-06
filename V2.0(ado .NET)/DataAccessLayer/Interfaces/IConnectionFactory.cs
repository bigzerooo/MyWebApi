using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace DataAccessLayer.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetSqlConnection { get; }
        void SetConnection(string connectionString);
    }
}
