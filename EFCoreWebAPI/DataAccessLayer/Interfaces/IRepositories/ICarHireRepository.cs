using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarHireRepository : IGenericRepository<CarHire, int>
    {
        public Task<CarHire> GetCarHireDetailsByIdAsync(int id);
        public Task<List<CarHire>> GetCarHireDetailsAsync();
        public Task<PagedList<CarHire>> GetAllPagesAsync(CarHireParameters parameters);
        public Task<int> GetReturnedCarCountByIdAsync(int id);
        public Task<List<CarHire>> GetUnreturnedCarHiresByClientIdAsync(int clientId);
        public Task<List<CarHire>> GetCarHiresByClientIdAsync(int clientId);
    }
}