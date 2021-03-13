using BusinessLogicLayer.DTO;
using BusinessLogicLayer.DTO.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarStateService
    {
        Task<IEnumerable<CarStateDTO>> GetAllCarStatesAsync();
        Task<string> GetCarStateByIdAsync(int id);
        Task<RequestResultDTO> AddCarStateAsync(CarStateDTO carStateDTO);
        Task<RequestResultDTO> UpdateCarStateAsync(CarStateDTO carStateDTO);
        Task<RequestResultDTO> DeleteCarStateAsync(int id);
    }
}