﻿using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.Repositories.MongoDBRepositories
{
    public class MongoLogsRepository : MongoGenericRepository<Log>, ILogsRepository
    {
        public MongoLogsRepository(IMongoDbSettings settings) : base(settings) { }
    }
}
