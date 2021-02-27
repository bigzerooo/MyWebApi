using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Extensions;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.MongoDBRepositories
{
    public class MongoLogsRepository : MongoGenericRepository<Log>, ILogsRepository
    {
        private readonly IDistributedCache cache;

        public MongoLogsRepository(IMongoDbSettings settings, IDistributedCache cache) : base(settings)
        {
            this.cache = cache;
        }

        public override async Task<IEnumerable<Log>> GetAllAsync()
        {
            var recordKey = GetType().Name + "_Data";
            var data = await cache.GetRecordAsync<IEnumerable<Log>>(recordKey);

            if(data is null)
            {
                data = await base.GetAllAsync();
                await cache.SetRecordAsync(recordKey, data);
            }

            return data;
        }
    }
}
