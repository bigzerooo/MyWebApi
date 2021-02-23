using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.Repositories.MongoDBRepositories
{
    public class MongoNewsRepository : MongoGenericRepository<News>, INewsRepository
    {
        public MongoNewsRepository(IMongoDbSettings settings) : base(settings) { }
    }
}
