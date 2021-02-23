using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;

namespace DataAccessLayer.Repositories.MongoDBRepositories
{
    public class MongoLogsRepository : MongoGenericRepository<Log>, ILogsRepository
    {
        public MongoLogsRepository(IMongoDbSettings settings) : base(settings) { }
    }
}
