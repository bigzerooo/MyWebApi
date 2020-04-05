using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ICarHireService
    {
        Task<int> AddCarHireAsync(CarHireDTO carHire);//Принимает ДТО, превращает в Ентити и вставляет
        Task UpdateCarHireAsync(CarHireDTO carHire);//Принимает ДТО, превращает в Ентити и обновляет
        Task DeleteCarHireAsync(int Id);//принимает айдишку и удаляет Ентити
        Task<CarHireDTO> GetCarHireByIdAsync(int Id);//принимает айдишку, находит Ентити и возвращает ДТО
        Task<IEnumerable<CarHireDTO>> GetAllCarHiresAsync();//находит Ентити и возвращает ДТО

        Task<CarHire> GetCarHireDetailsByIdAsync(int Id);
        Task<List<CarHire>> GetCarHireDetailsAsync();
    }
}
