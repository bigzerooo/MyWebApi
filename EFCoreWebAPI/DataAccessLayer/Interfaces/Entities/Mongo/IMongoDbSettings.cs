﻿namespace DataAccessLayer.Interfaces.Entities.Mongo
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
