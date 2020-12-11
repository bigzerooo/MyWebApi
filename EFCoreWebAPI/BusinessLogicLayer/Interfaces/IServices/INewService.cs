using BusinessLogicLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface INewService
    {
        Task<int> AddNewAsync(NewDTO carState);
        Task UpdateNewAsync(NewDTO carState);
        Task DeleteNewAsync(int Id);
        Task<NewDTO> GetNewByIdAsync(int Id);
        Task<IEnumerable<NewDTO>> GetAllNewsAsync();
    }
}