using BusinessLogicLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IClientTypeService
    {
        Task<int> AddClientTypeAsync(ClientTypeDTO clientType);
        Task UpdateClientTypeAsync(ClientTypeDTO clientType);
        Task DeleteClientTypeAsync(int Id);
        Task<string> GetClientTypeByIdAsync(int Id);
        Task<IEnumerable<ClientTypeDTO>> GetAllClientTypesAsync();
        //Task<ClientType> GetClientTypeDetailsByIdAsync(int Id);
        //Task<List<ClientType>> GetClientTypeDetailsAsync();
    }
}