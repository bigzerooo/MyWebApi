using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class CarStateRepository : SQLGenericRepository<CarState>, ICarStateRepository
    {
        public CarStateRepository(SQLDbContext myDBContext) : base(myDBContext) { }
        public async Task<CarState> GetCarStateDetailsByIdAsync(int id) =>
            await _myDBContext.CarStates
                .Include(c => c.CarHires)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        public async Task<List<CarState>> GetCarStateDetailsAsync() =>
            await _myDBContext.CarStates
                .Include(c => c.CarHires)
                .ToListAsync();
        public async Task<string> GetCarStateById(int id) => (await _dbSet.FindAsync(id)).State;
    }
}