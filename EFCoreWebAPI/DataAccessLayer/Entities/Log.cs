﻿using DataAccessLayer.Attributes;
using DataAccessLayer.Interfaces.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DataAccessLayer.Entities
{
    [BsonCollection("logs")]
    public class Log : IEntity<int>
    {
        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ActionType { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
    }
}
