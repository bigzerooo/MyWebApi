using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarStateService
    {
        Task<int> AddCarStateAsync(CarStateDTO carStateDTO);
        Task UpdateCarStateAsync(CarStateDTO carStateDTO);
        Task DeleteCarStateAsync(int id);
        Task<string> GetCarStateByIdAsync(int id);
        Task<IEnumerable<CarStateDTO>> GetAllCarStatesAsync();
        Task<CarState> GetCarStateDetailsByIdAsync(int id);
        Task<List<CarState>> GetCarStateDetailsAsync();
    }
}