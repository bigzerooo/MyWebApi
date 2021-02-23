using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarHireService
    {
        Task<int> HireTheCarAsync(CarHireDTO carHireDTO);
        Task<int> ReturnTheCarAsync(CarHireDTO carHireDTO);
        Task UpdateCarHireAsync(CarHireDTO carHireDTO);
        Task DeleteCarHireAsync(int id);
        Task<CarHireDTO> GetCarHireByIdAsync(int id);
        Task<IEnumerable<CarHireDTO>> GetAllCarHiresAsync();
        Task<List<CarHireDTO>> GetUnreturnedCarHiresByClientIdAsync(int clientId);
        Task<List<CarHireDTO>> GetCarHiresByClientIdAsync(int clientId);
        Task<CarHire> GetCarHireDetailsByIdAsync(int id);
        Task<List<CarHire>> GetCarHireDetailsAsync();
        Task<PagedList<CarHireDTO>> GetCarHirePages(CarHireParameters parameters);
    }
}