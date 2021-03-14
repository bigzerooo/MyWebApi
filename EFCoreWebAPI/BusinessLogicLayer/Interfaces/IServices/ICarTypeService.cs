using BusinessLogicLayer.DTO;
using BusinessLogicLayer.DTO.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarTypeService
    {
        Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync();
        Task<string> GetCarTypeByIdAsync(int id);
        Task<RequestResultDTO> AddCarTypeAsync(CarTypeDTO carTypeDTO);
        Task<RequestResultDTO> UpdateCarTypeAsync(CarTypeDTO carTypeDTO);
        Task<RequestResultDTO> DeleteCarTypeAsync(int id);
    }
}