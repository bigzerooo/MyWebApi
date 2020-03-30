using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarStateService
    {
        Task<int> AddCarStateAsync(CarState carState);
        Task UpdateCarStateAsync(CarState carState);
        Task DeleteCarStateAsync(int Id);
        Task<CarState> GetCarStateByIdAsync(int Id);
        Task<IEnumerable<CarState>> GetAllCarStatesAsync();
        Task<CarState> GetCarStateDetailsByIdAsync(int Id);
        Task<List<CarState>> GetCarStateDetailsAsync();
    }
}
