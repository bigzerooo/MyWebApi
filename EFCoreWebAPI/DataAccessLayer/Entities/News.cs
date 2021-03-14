using DataAccessLayer.Attributes;
using DataAccessLayer.Interfaces.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataAccessLayer.Entities
{
    [BsonCollection("news")]
    public class News : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}