using BusinessLogicLayer.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IRoleService
    {
        Task CreateRole(RoleDTO role);
        Task AppointRole(string id, string role);
        Task<IList<string>> GetAllRolesByUserId(string id);
        //public Task<string> RoleList();
        //public Task<string> Create(string name);
        //public Task<string> Delete(int id);
        //public Task<string> Edit();

    }
}
