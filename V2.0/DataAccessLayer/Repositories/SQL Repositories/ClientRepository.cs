using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.Interfaces.IRepositories;
using System.Configuration;
namespace DataAccessLayer.Repositories.SQL_Repositories
{
    public class ClientRepository: GenericRepository<Client,int>,IClientRepository
    {
        private static readonly string _tableName = "Clients";
        private static readonly bool _isSoftDelete = false;
        public ClientRepository(IConnectionFactory connectionFactory/*, bool IsTest*/) : base(connectionFactory, _tableName, _isSoftDelete)
        {
            /*if (!IsTest)*/
            //connectionFactory.SetConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connectionFactory.SetConnection(MyConnection._connectionString);
        }
    }
}
