using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLCarTypeRepository : SQLGenericRepository<CarType>, ICarTypeRepository
    {
        public SQLCarTypeRepository(SQLDbContext myDBContext) : base(myDBContext) { }
        public async Task<CarType> GetCarTypeDetailsByIdAsync(int id) => await _myDBContext.CarTypes
                .Include(c => c.Cars)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        public async Task<List<CarType>> GetCarTypeDetailsAsync() =>
            await _myDBContext.CarTypes
                .Include(c => c.Cars)
                .ToListAsync();
        public async Task<string> GetCarTypeById(int id) => (await _dbSet.FindAsync(id)).Type;
    }
}