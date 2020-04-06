using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Interfaces.IRepositories;
namespace DataAccessLayer.Repositories.SQL_Repositories
{
    public class CarRepository: GenericRepository<Car,int>, ICarRepository
    {
        private static readonly string _tableName = "Cars";
        private static readonly bool _isSoftDelete = false;
        public CarRepository(IConnectionFactory connectionFactory/*, bool IsTest*/) : base(connectionFactory, _tableName, _isSoftDelete)
        {            
            /*if (!IsTest)*/
            //connectionFactory.SetConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connectionFactory.SetConnection(MyConnection._connectionString);
        }
    }
}
