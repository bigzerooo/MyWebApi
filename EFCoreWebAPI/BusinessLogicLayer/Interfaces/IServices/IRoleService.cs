using BusinessLogicLayer.DTO.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IRoleService
    {
        Task CreateRole(RoleDTO role);
        Task AppointRole(string id, string role);
        Task<IList<string>> GetAllRolesByUserId(string id);
    }
}