using AutoMapper;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RoleService:IRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task CreateRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<RoleDTO, MyRole>(roleDTO);
            await _uow.roleManager.CreateAsync(role);
        }
        public async Task AppointRole(string id, string role)
        {
            MyUser user = await _uow.userManager.FindByIdAsync(id);
            await _uow.userManager.AddToRoleAsync(user, role);
        }
        public async Task<IList<string>> GetAllRolesByUserId(string id)
        {
            MyUser user = await _uow.userManager.FindByIdAsync(id);
            IList<string> userRoles = null;
            if (user != null)
                userRoles = await _uow.userManager.GetRolesAsync(user);
            return userRoles;
        }
    }
}
