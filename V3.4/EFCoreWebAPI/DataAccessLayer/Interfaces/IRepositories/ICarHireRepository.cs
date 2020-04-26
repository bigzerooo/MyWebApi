using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarHireRepository: IGenericRepository<CarHire,int>
    {
        public Task<CarHire> GetCarHireDetailsByIdAsync(int Id);
        public Task<List<CarHire>> GetCarHireDetailsAsync();
        public Task<PagedList<CarHire>> GetAllPagesAsync(CarHireParameters parameters);
    }
}
