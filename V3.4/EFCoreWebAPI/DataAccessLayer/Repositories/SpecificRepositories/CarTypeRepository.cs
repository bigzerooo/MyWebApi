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
    public class CarTypeRepository : GenericRepository<CarType, int>, ICarTypeRepository
    {
        public CarTypeRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public async Task<CarType> GetCarTypeDetailsByIdAsync(int Id)
        {
            var carType = await _myDBContext.CarTypes
                .Include(c => c.Cars)
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();
            return carType;
        }
        public async Task<List<CarType>> GetCarTypeDetailsAsync()
        {
            var carTypes = await _myDBContext.CarTypes
                .Include(c => c.Cars)
                .ToListAsync();            
            return carTypes;
        }
        public async Task<string> GetCarTypeById(int Id)
        {
            return (await _dbSet.FindAsync(Id)).Type;
        }
    }
}
