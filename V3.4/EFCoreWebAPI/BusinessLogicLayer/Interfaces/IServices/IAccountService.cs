using BusinessLogicLayer.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IAccountService
    {
        public Task<string> Register(MyUserRegisterDTO userDTO);
        public Task<string> Login(MyUserLoginDTO userDTO);
        public Task<string> Logout();
        public Task<string> Edit(MyUserEditDTO userDTO);
        public Task<string> Delete(int Id);
    }
}
