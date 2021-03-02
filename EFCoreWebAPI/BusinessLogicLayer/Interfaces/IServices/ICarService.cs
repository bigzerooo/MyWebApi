using BusinessLogicLayer.DTO;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarService
    {
        Task<int> AddCarAsync(CarDTO carDTO);
        Task UpdateCarAsync(CarDTO carDTO);
        Task DeleteCarAsync(int id);
        Task<CarDTO> GetCarByIdAsync(int id);
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();
        //Task<Car> GetCarDetailsByIdAsync(int id);
        //Task<List<Car>> GetCarDetailsAsync();
        Task<PagedList<CarDTO>> GetCarPagesFilteredAsync(CarParameters parameters);
        Task<int> GetCarsCountAsync(CarParameters parameters);
    }
}