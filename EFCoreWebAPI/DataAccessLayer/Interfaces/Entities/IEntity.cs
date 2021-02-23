using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Interfaces.Entities
{
    public interface IEntity
    {
        [BsonId]
        int Id { get; set; }
    }
}