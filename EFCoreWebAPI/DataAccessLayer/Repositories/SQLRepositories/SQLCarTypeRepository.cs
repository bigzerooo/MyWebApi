using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLCarTypeRepository : SQLGenericRepository<CarType, int>, ICarTypeRepository
    {
        public SQLCarTypeRepository(SQLDbContext myDBContext) : base(myDBContext) { }

        public async Task<string> GetCarTypeStringById(int id)
        {
            return (await _dbSet.FindAsync(id)).Type;
        }

        //public async Task<CarType> GetCarTypeDetailsByIdAsync(int id) => await _myDBContext.CarTypes
        //        .Include(c => c.Cars)
        //        .Where(c => c.Id == id)
        //        .FirstOrDefaultAsync();
        //public async Task<List<CarType>> GetCarTypeDetailsAsync() =>
        //    await _myDBContext.CarTypes
        //        .Include(c => c.Cars)
        //        .ToListAsync();
    }
}