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
        Task<int> HireCarAsync(CarHireDTO carHire);
        Task<int> ReturnCarAsync(CarHireDTO carHireDTO);
        Task UpdateCarHireAsync(CarHireDTO carHire);
        Task DeleteCarHireAsync(int Id);
        Task<CarHireDTO> GetCarHireByIdAsync(int Id);
        Task<IEnumerable<CarHireDTO>> GetAllCarHiresAsync();
        Task<List<CarHireDTO>> GetUnreturnedCarHiresByClientIdAsync(int clientId);
        Task<List<CarHireDTO>> GetCarHiresByClientIdAsync(int clientId);
        Task<CarHire> GetCarHireDetailsByIdAsync(int Id);
        Task<List<CarHire>> GetCarHireDetailsAsync();
        Task<PagedList<CarHireDTO>> GetCarHirePages(CarHireParameters parameters);
    }
}