using BusinessLogicLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface INewsService
    {
        Task<int> AddNewAsync(NewsDTO carState);
        Task UpdateNewAsync(NewsDTO carState);
        Task DeleteNewAsync(int Id);
        Task<NewsDTO> GetNewByIdAsync(int Id);
        Task<IEnumerable<NewsDTO>> GetAllNewsAsync();
    }
}