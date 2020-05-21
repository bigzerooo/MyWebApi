using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarHireRepository: GenericRepository<CarHire,int>,ICarHireRepository
    {
        public CarHireRepository(MyDBContext myDBContext) : base(myDBContext)
        {
            
        }
        public async Task<int> GetReturnedCarCountByIdAsync(int clientId)
        {
            var count = await _myDBContext.CarHires.CountAsync(x => x.Returned == true && x.ClientId == clientId);
            return count;
        }
        public async Task<List<CarHire>> GetUnreturnedCarHiresByClientIdAsync(int clientId)
        {
            var carhires = await _myDBContext.CarHires.Where(x => x.Returned == false && x.ClientId == clientId).ToListAsync();
            return carhires;                
        }
        public async Task<List<CarHire>> GetCarHiresByClientIdAsync(int clientId)
        {
            var carhires = await _myDBContext.CarHires.Where(x=>x.ClientId == clientId).ToListAsync();
            return carhires;
        }

        public async Task<CarHire> GetCarHireDetailsByIdAsync(int Id)
        {
            var carHire = await _myDBContext.CarHires
                .Include(c => c.Car)
                    .ThenInclude(s=>s.CarType)
                .Include(c => c.Client)
                    .ThenInclude(s=>s.ClientType)
                .Include(c => c.State)
                .Where(c=>c.Id==Id)
                .FirstOrDefaultAsync();
            return carHire;                
        }
        public async Task<List<CarHire>> GetCarHireDetailsAsync()
        {
            var carHires = await _myDBContext.CarHires
                .Include(c => c.Car)
                    .ThenInclude(s => s.CarType)
                .Include(c => c.Client)
                    .ThenInclude(s => s.ClientType)
                .Include(c => c.State)
                .ToListAsync();
            return carHires;
        }
        public async Task<PagedList<CarHire>> GetAllPagesAsync(CarHireParameters parameters)//он не асинхронный, надо что-то делать
        {
            return await PagedList<CarHire>.ToPagedListAsync(_dbSet, parameters.PageNumber, parameters.PageSize);
        }

    }
}
