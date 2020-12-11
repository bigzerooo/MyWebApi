using AutoMapper;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task CreateRole(RoleDTO roleDTO) =>
            await _uow.RoleManager.CreateAsync(_mapper.Map<RoleDTO, MyRole>(roleDTO));
        public async Task AppointRole(string id, string role) =>
            await _uow.UserManager.AddToRoleAsync(await _uow.UserManager.FindByIdAsync(id), role);
        public async Task<IList<string>> GetAllRolesByUserId(string id)
        {
            MyUser user = await _uow.UserManager.FindByIdAsync(id);
            IList<string> userRoles = null;
            if (user != null)
                userRoles = await _uow.UserManager.GetRolesAsync(user);
            return userRoles;
        }
    }
}