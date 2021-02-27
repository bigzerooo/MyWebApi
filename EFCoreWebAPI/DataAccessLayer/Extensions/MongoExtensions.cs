using DataAccessLayer.Attributes;
using DataAccessLayer.Interfaces.Entities;
using System.Linq;

namespace DataAccessLayer.Helpers
{
    public static class MongoExtensions
    {
        public static string GetMongoCollectionName(this IEntity document)
        {
            var documentType = document.GetType();
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault())?.CollectionName
                ?? documentType.Name.ToLower() + "s";
        }
    }
}
