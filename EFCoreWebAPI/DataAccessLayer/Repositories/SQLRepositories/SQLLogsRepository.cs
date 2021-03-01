using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLLogsRepository : SQLGenericRepository<Log>, ILogsRepository
    {
        public SQLLogsRepository(SQLDbContext dbContext) : base(dbContext) { }
    }
}
