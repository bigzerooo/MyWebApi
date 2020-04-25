using BusinessLogicLayer.DTO.Identity;
using DataAccessLayer.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IAccountService
    {
        public Task<string> Register(MyUserRegisterDTO myUser);
        public Task<string> Create(MyUserCreateDTO myUser);
        public Task<string> Login(MyUserLoginDTO myUser);        
        public Task<string> Logout();
        public Task<string> Edit(MyUserEditDTO myUser);
        public Task<string> ChangePassword(MyUserChangePasswordDTO myUser);
        public Task<string> Delete(int Id);
        public Task<List<MyUser>> UserList();
    }
}
