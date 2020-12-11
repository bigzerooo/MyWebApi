using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.DTO.Identity.Results;
using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IAccountService
    {
        public Task<IdentityResult> Register(MyUserRegisterDTO myUser);
        public Task<LoginResult> Login(MyUserLoginDTO myUser);
        public Task<string> Logout();
        public Task<string> Edit(MyUserEditDTO myUser);
        public Task<IdentityResult> ChangePassword(MyUserChangePasswordDTO myUser);
        public Task<string> Delete(int Id);
        public Task<List<MyUser>> UserList();
    }
}