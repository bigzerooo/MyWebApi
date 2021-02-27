using DataAccessLayer.Attributes;
using DataAccessLayer.Entities.Mongo;
using DataAccessLayer.Interfaces.Entities;
using DataAccessLayer.Interfaces.Entities.Mongo;
using DataAccessLayer.Interfaces.Helpers;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers
{
    public class MongoHelper : IMongoHelper
    {
        private const string SequenceSufix = "sequence";
        private readonly IMongoCollection<Sequence> sequence;
        private readonly IMongoDatabase database;

        public MongoHelper(IMongoDbSettings settings)
        {
            database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            sequence = database.GetCollection<Sequence>(GetMongoCollectionName<Sequence>());
        }

        public string GetMongoCollectionName<T>()
        {
            var documentType = typeof(T);
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault())?.CollectionName
                ?? documentType.Name.ToLower() + "s";
        }

        public async Task<int> GetNextSequenceValue<TEntity>() where TEntity : IEntity
        {
            var collectionName = GetMongoCollectionName<TEntity>();
            var sequenceCollectionName = GetMongoCollectionName<Sequence>();
            var sequenceDocumentName = $"{collectionName}_{SequenceSufix}";
            var filter = Builders<Sequence>.Filter.Eq(doc => doc.Name, sequenceDocumentName);
            var update = Builders<Sequence>.Update.Inc(doc => doc.Value, 1);
            var sequence = await this.sequence.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Sequence> { ReturnDocument = ReturnDocument.After });
            if (sequence == null)
            {
                sequence = new Sequence { Name = sequenceDocumentName, Value = 1 };
                await this.sequence.InsertOneAsync(sequence);
            }
            return sequence.Value;
        }

        public IMongoDatabase GetMongoDatabase()
        {
            return database;
        }
    }
}
