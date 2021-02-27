using DataAccessLayer.Interfaces.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Helpers
{
    public interface IMongoHelper
    {
        string GetMongoCollectionName<T>();
        Task<int> GetNextSequenceValue<TEntity>() where TEntity : IEntity;
        IMongoDatabase GetMongoDatabase();
    }
}
