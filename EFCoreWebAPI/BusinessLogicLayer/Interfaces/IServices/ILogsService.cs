using BusinessLogicLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface ILogsService
    {
        Task<int> AddLogAsync(LogDTO logDTO);
        Task<LogDTO> GetLogByIdAsync(int Id);
        Task<IEnumerable<LogDTO>> GetAllLogsAsync();
    }
}
