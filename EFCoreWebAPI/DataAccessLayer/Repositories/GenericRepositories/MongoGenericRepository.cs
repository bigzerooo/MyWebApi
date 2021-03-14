using DataAccessLayer.Interfaces.Entities;
using DataAccessLayer.Interfaces.Helpers;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.GenericRepositories
{
    public abstract class MongoGenericRepository<TEntity> : IGenericRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
        protected readonly IMongoCollection<TEntity> collection;
        protected readonly IMongoHelper mongoHelper;

        public MongoGenericRepository(IMongoHelper mongoHelper)
        {
            var database = mongoHelper.GetMongoDatabase();
            var collectionName = mongoHelper.GetMongoCollectionName<TEntity>();
            this.mongoHelper = mongoHelper;
            collection = database.GetCollection<TEntity>(collectionName);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await collection.Find(doc => true).ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);
            return await collection.Find(filter).SingleOrDefaultAsync();
        }

        public virtual async Task<int> AddAsync(TEntity document)
        {
            document.Id = await mongoHelper.GetNextSequenceValue<TEntity>();
            await collection.InsertOneAsync(document);
            return document.Id;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);
            await collection.FindOneAndDeleteAsync(filter);
        }

        public virtual async Task UpdateAsync(TEntity document)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, document.Id);
            await collection.FindOneAndReplaceAsync(filter, document);
        }

        public IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return collection.AsQueryable().Where(expression);
        }
    }
}
