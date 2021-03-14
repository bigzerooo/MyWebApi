using BusinessLogicLayer.DTO;
using BusinessLogicLayer.DTO.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IClientTypeService
    {
        Task<IEnumerable<ClientTypeDTO>> GetAllClientTypesAsync();
        Task<string> GetClientTypeByIdAsync(int Id);
        Task<RequestResultDTO> AddClientTypeAsync(ClientTypeDTO clientType);
        Task<RequestResultDTO> UpdateClientTypeAsync(ClientTypeDTO clientType);
        Task<RequestResultDTO> DeleteClientTypeAsync(int Id);
    }
}