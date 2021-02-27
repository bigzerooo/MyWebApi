using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Helpers;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;

namespace DataAccessLayer.Repositories.MongoDBRepositories
{
    public class MongoNewsRepository : MongoGenericRepository<News>, INewsRepository
    {
        public MongoNewsRepository(IMongoHelper mongoHelper) : base(mongoHelper) { }
    }
}
