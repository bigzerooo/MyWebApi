using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;

namespace DataAccessLayer.Repositories.MongoDBRepositories
{
    public class MongoNewRepository : MongoGenericRepository<New>, INewRepository
    {
        public MongoNewRepository(IMongoDbSettings settings) : base(settings) { }
    }
}
