using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class CarHireRepository : SQLGenericRepository<CarHire>, ICarHireRepository
    {
        public CarHireRepository(SQLDbContext myDBContext) : base(myDBContext) { }
        public async Task<int> GetReturnedCarCountByIdAsync(int clientId) =>
            await _myDBContext.CarHires.CountAsync(x => x.Returned == true && x.ClientId == clientId);
        public async Task<List<CarHire>> GetUnreturnedCarHiresByClientIdAsync(int clientId) =>
            await _myDBContext.CarHires.Where(x => x.Returned == false && x.ClientId == clientId).ToListAsync();
        public async Task<List<CarHire>> GetCarHiresByClientIdAsync(int clientId) =>
            await _myDBContext.CarHires.Where(x => x.ClientId == clientId && x.Returned == true).ToListAsync();
        public async Task<CarHire> GetCarHireDetailsByIdAsync(int Id) =>
            await _myDBContext.CarHires
                .Include(c => c.Car)
                    .ThenInclude(s => s.CarType)
                .Include(c => c.Client)
                    .ThenInclude(s => s.ClientType)
                .Include(c => c.State)
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();
        public async Task<List<CarHire>> GetCarHireDetailsAsync() =>
            await _myDBContext.CarHires
                .Include(c => c.Car)
                    .ThenInclude(s => s.CarType)
                .Include(c => c.Client)
                    .ThenInclude(s => s.ClientType)
                .Include(c => c.State)
                .ToListAsync();
        public async Task<PagedList<CarHire>> GetAllPagesAsync(CarHireParameters parameters) =>
            await PagedList<CarHire>.ToPagedListAsync(_dbSet, parameters.PageNumber, parameters.PageSize);
    }
}