﻿using AutoMapper;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task CreateRole(RoleDTO roleDTO) =>
            await unitOfWork.RoleManager.CreateAsync(mapper.Map<Role>(roleDTO));
        public async Task AppointRole(string id, string role) =>
            await unitOfWork.UserManager.AddToRoleAsync(await unitOfWork.UserManager.FindByIdAsync(id), role);
        public async Task<IList<string>> GetAllRolesByUserId(string id)
        {
            User user = await unitOfWork.UserManager.FindByIdAsync(id);
            IList<string> userRoles = null;
            if (user != null)
                userRoles = await unitOfWork.UserManager.GetRolesAsync(user);
            return userRoles;
        }
    }
}