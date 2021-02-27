using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities.Mongo
{
    public class Sequence
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name;
        public int Value { get; set; }
    }
}
