using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface ICarHireRepository : IGenericRepository<CarHire, int>
    {
        Task<int> GetReturnedCarCountByIdAsync(int id);
        Task<IEnumerable<CarHire>> GetReturnedCarHiresByClientIdAsync(int clientId);
        Task<IEnumerable<CarHire>> GetUnreturnedCarHiresByClientIdAsync(int clientId);
        Task<PagedList<CarHire>> GetAllPagesAsync(CarHireParameters parameters);
        //public Task<CarHire> GetCarHireDetailsByIdAsync(int id);
        //public Task<List<CarHire>> GetCarHireDetailsAsync();
    }
}