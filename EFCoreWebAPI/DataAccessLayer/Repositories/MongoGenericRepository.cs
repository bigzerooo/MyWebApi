using DataAccessLayer.Attributes;
using DataAccessLayer.DbContext;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.EntityInterfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class MongoGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private const string SequenceCollectionName = "sequence";

        private readonly string _collectionName;
        private readonly IMongoCollection<TEntity> _collection;
        private readonly IMongoCollection<Sequence> _sequence;

        public MongoGenericRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collectionName = GetCollectionName(typeof(TEntity));
            _collection = database.GetCollection<TEntity>(_collectionName);
            _sequence = database.GetCollection<Sequence>(SequenceCollectionName + "s");
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        private class Sequence
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public string Name;
            public int Value { get; set; }
        }

        private protected async Task<int> GetNextSequenceValue()
        {
            var sequenceDocumentName = $"{_collectionName}_{SequenceCollectionName}";
            var filter = Builders<Sequence>.Filter.Eq(doc => doc.Name, sequenceDocumentName);
            var update = Builders<Sequence>.Update.Inc(doc => doc.Value, 1);
            var sequence = await _sequence.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Sequence> { ReturnDocument = ReturnDocument.After });
            if (sequence == null)
            {
                sequence = new Sequence { Name = sequenceDocumentName, Value = 1 };
                await _sequence.InsertOneAsync(sequence);
            }
            return sequence.Value;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _collection.Find(doc => true).ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<int> AddAsync(TEntity document)
        {
            document.Id = await GetNextSequenceValue();
            await _collection.InsertOneAsync(document);
            return document.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);
            await _collection.FindOneAndDeleteAsync(filter);
        }

        public async Task UpdateAsync(TEntity document)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _collection.AsQueryable().Where(expression);
        }
    }
}
