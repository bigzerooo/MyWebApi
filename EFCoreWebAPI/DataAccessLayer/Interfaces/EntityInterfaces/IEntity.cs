using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Interfaces.EntityInterfaces
{
    public interface IEntity
    {
        [BsonId]
        int Id { get; set; }
    }
}