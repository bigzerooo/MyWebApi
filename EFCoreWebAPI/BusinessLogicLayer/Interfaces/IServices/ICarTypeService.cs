using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarTypeService
    {
        Task<int> AddCarTypeAsync(CarTypeDTO carTypeDTO);
        Task UpdateCarTypeAsync(CarTypeDTO carTypeDTO);
        Task DeleteCarTypeAsync(int id);
        Task<string> GetCarTypeByIdAsync(int id);
        Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync();
        Task<CarType> GetCarTypeDetailsByIdAsync(int id);
        Task<List<CarType>> GetCarTypeDetailsAsync();
    }
}