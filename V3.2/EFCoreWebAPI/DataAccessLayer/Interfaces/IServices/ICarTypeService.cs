    using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarTypeService
    {
        Task<int> AddCarTypeAsync(CarType carType);
        Task UpdateCarTypeAsync(CarType carType);
        Task DeleteCarTypeAsync(int Id);
        Task<CarType> GetCarTypeByIdAsync(int Id);
        Task<IEnumerable<CarType>> GetAllCarTypesAsync();
        Task<CarType> GetCarTypeDetailsByIdAsync(int Id);
        Task<List<CarType>> GetCarTypeDetailsAsync();
    }
}
