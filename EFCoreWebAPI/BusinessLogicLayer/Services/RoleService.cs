using AutoMapper;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task CreateRole(RoleDTO roleDTO) =>
            await _unitOfWork.RoleManager.CreateAsync(_mapper.Map<MyRole>(roleDTO));
        public async Task AppointRole(string id, string role) =>
            await _unitOfWork.UserManager.AddToRoleAsync(await _unitOfWork.UserManager.FindByIdAsync(id), role);
        public async Task<IList<string>> GetAllRolesByUserId(string id)
        {
            MyUser user = await _unitOfWork.UserManager.FindByIdAsync(id);
            IList<string> userRoles = null;
            if (user != null)
                userRoles = await _unitOfWork.UserManager.GetRolesAsync(user);
            return userRoles;
        }
    }
}