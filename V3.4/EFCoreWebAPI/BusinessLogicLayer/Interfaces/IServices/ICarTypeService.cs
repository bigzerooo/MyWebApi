using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarTypeService
    {
        Task<int> AddCarTypeAsync(CarTypeDTO carType);
        Task UpdateCarTypeAsync(CarTypeDTO carType);
        Task DeleteCarTypeAsync(int Id);
        Task<CarTypeDTO> GetCarTypeByIdAsync(int Id);
        Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync();

        Task<CarType> GetCarTypeDetailsByIdAsync(int Id);
        Task<List<CarType>> GetCarTypeDetailsAsync();
    }
}
