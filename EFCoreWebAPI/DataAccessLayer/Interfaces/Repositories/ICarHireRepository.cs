using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface ICarHireRepository : IGenericRepository<CarHire>
    {
        public Task<CarHire> GetCarHireDetailsByIdAsync(int id);
        public Task<List<CarHire>> GetCarHireDetailsAsync();
        public Task<PagedList<CarHire>> GetAllPagesAsync(CarHireParameters parameters);
        public Task<int> GetReturnedCarCountByIdAsync(int id);
        public Task<List<CarHire>> GetUnreturnedCarHiresByClientIdAsync(int clientId);
        public Task<List<CarHire>> GetCarHiresByClientIdAsync(int clientId);
    }
}