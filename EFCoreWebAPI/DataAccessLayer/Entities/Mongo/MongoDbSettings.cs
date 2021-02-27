using DataAccessLayer.Interfaces.Entities.Mongo;

namespace DataAccessLayer.Entities.Mongo
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
