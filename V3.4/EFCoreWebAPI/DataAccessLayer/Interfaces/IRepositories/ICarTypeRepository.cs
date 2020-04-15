using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarTypeRepository : IGenericRepository<CarType, int>
    {
        public Task<CarType> GetCarTypeDetailsByIdAsync(int Id);
        public Task<List<CarType>> GetCarTypeDetailsAsync();
    }
}
