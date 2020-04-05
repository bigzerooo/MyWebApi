using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarStateService
    {
        Task<int> AddCarStateAsync(CarStateDTO carState);
        Task UpdateCarStateAsync(CarStateDTO carState);
        Task DeleteCarStateAsync(int Id);
        Task<CarStateDTO> GetCarStateByIdAsync(int Id);
        Task<IEnumerable<CarStateDTO>> GetAllCarStatesAsync();

        Task<CarState> GetCarStateDetailsByIdAsync(int Id);
        Task<List<CarState>> GetCarStateDetailsAsync();
    }
}
