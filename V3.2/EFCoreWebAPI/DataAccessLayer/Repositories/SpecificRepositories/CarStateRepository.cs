using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarStateRepository : GenericRepository<CarState, int>, ICarStateRepository
    {
        public CarStateRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public async Task<CarState> GetCarStateDetailsByIdAsync(int Id)
        {
            var carState = await _myDBContext.CarStates
                .Include(c => c.CarHires)
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();
            return carState;
        }
        public async Task<List<CarState>> GetCarStateDetailsAsync()
        {
            var carStates = await _myDBContext.CarStates
                .Include(c => c.CarHires)
                .ToListAsync();
            return carStates;
        }
    }
}
