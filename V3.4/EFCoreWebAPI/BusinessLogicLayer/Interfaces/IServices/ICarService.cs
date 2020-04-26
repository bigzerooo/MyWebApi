using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarService
    {
        Task<int> AddCarAsync(CarDTO car);
        Task UpdateCarAsync(CarDTO car);
        Task DeleteCarAsync(int Id);
        Task<CarDTO> GetCarByIdAsync(int Id);
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();

        Task<Car> GetCarDetailsByIdAsync(int Id);
        Task<List<Car>> GetCarDetailsAsync();
        Task<PagedList<CarDTO>> GetCarPagesFilteredAsync(CarParameters parameters);
    }
}
