using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Interfaces.Entities
{
    public interface IEntity<T>
    {
        [BsonId]
        T Id { get; set; }
    }
}