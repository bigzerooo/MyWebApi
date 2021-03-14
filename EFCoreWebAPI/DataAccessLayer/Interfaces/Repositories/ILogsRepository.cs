using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface ILogsRepository : IGenericRepository<Log, int> { }
}
