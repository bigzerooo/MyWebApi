using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Parameters;
using DataAccessLayer.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLCarHireRepository : SQLGenericRepository<CarHire>, ICarHireRepository
    {
        public SQLCarHireRepository(SQLDbContext myDBContext) : base(myDBContext) { }

        public async Task<int> GetReturnedCarCountByIdAsync(int clientId)
        {
            return await _dbSet
                .CountAsync(ch => ch.ClientId == clientId && ch.Returned);
        }

        public async Task<IEnumerable<CarHire>> GetReturnedCarHiresByClientIdAsync(int clientId)
        {
            return await _dbSet
                .Where(ch => ch.ClientId == clientId && ch.Returned)
                .ToListAsync();
        }

        public async Task<IEnumerable<CarHire>> GetUnreturnedCarHiresByClientIdAsync(int clientId)
        {
            return await _dbSet
                .Where(ch => ch.ClientId == clientId && !ch.Returned)
                .ToListAsync();
        }

        public async Task<PagedList<CarHire>> GetAllPagesAsync(CarHireParameters parameters)
        {
            return await PagedList<CarHire>
                .ToPagedListAsync(_dbSet, parameters.PageNumber, parameters.PageSize);
        }

        //details закрыты на переработку
        //public async Task<CarHire> GetCarHireDetailsByIdAsync(int Id) =>
        //    await _myDBContext.CarHires
        //        .Include(c => c.Car)
        //            .ThenInclude(s => s.CarType)
        //        .Include(c => c.Client)
        //            .ThenInclude(s => s.ClientType)
        //        .Include(c => c.State)
        //        .Where(c => c.Id == Id)
        //        .FirstOrDefaultAsync();
        //public async Task<List<CarHire>> GetCarHireDetailsAsync() =>
        //    await _myDBContext.CarHires
        //        .Include(c => c.Car)
        //            .ThenInclude(s => s.CarType)
        //        .Include(c => c.Client)
        //            .ThenInclude(s => s.ClientType)
        //        .Include(c => c.State)
        //        .ToListAsync();
    }
}