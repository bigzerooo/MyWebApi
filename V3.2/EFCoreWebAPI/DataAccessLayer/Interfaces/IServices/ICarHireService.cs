using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarHireService
    {
        Task<int> AddCarHireAsync(CarHire carHire);
        Task UpdateCarHireAsync(CarHire carHire);
        Task DeleteCarHireAsync(int Id);
        Task<CarHire> GetCarHireByIdAsync(int Id);
        Task<IEnumerable<CarHire>> GetAllCarHiresAsync();
        Task<CarHire> GetCarHireDetailsByIdAsync(int Id);
        Task<List<CarHire>> GetCarHireDetailsAsync();
    }
}
