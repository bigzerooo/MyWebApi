using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLCarStateRepository : SQLGenericRepository<CarState>, ICarStateRepository
    {
        public SQLCarStateRepository(SQLDbContext myDBContext) : base(myDBContext) { }

        public async Task<string> GetCarStateStringById(int id)
        {
            return (await _dbSet.FindAsync(id))?.State;
        }
    }
}