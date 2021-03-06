﻿using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLNewsRepository : SQLGenericRepository<News, int>, INewsRepository
    {
        public SQLNewsRepository(SQLDbContext myDBContext) : base(myDBContext) { }
    }
}