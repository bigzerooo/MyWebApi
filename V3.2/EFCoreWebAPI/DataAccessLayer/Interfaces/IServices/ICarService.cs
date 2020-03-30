using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarService
    {
        Task<int> AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int Id);
        Task<Car> GetCarByIdAsync(int Id);
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarDetailsByIdAsync(int Id);
        Task<List<Car>> GetCarDetailsAsync();
    }
}
