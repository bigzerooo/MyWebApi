using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.MongoDBRepositories
{
    public class MongoLogsRepository : MongoGenericRepository<Log>, ILogsRepository
    {
        public MongoLogsRepository(IMongoDbSettings settings) : base(settings) { }
    }
}
