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
        Task<IdentityResult> RegisterAsync(MyUserRegisterDTO userDTO);
        Task<LoginResult> LoginAsync(MyUserLoginDTO userDTO);
        Task LogoutAsync();
        Task<string> EditUserAsync(MyUserEditDTO userDTO);
        Task<IdentityResult> ChangePasswordAsync(MyUserChangePasswordDTO userDTO);
        Task<string> DeleteUserAsync(int id);
        Task<List<User>> GetAllUsersAsync();
    }
}