using AutoMapper;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.DTO.Identity.Results;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLogicLayer.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IConfiguration _configuration;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(unitOfWork, mapper) =>
            _configuration = configuration;

        public async Task<IdentityResult> Register(MyUserRegisterDTO myUser)
        {
            int clientId = await _unitOfWork.ClientRepository.AddAsync(new Client { ClientTypeId = 1 });
            MyUser user = new MyUser { Email = myUser.Email, UserName = myUser.UserName, ClientId = clientId };
            return await _unitOfWork.UserManager.CreateAsync(user, myUser.Password);
        }
        public async Task<LoginResult> Login(MyUserLoginDTO myUser)
        {
            MyUser user = await _unitOfWork.UserManager.FindByNameAsync(myUser.UserName);
            if (user != null)
            {
                SignInResult result = await _unitOfWork.SignInManager.PasswordSignInAsync(myUser.UserName, myUser.Password, myUser.RememberMe, false);
                if (result.Succeeded)
                    return new LoginResult { token = await BuildToken(user), successful = true };
                else
                    return new LoginResult { successful = false, error = "Invalid password" };
            }
            return new LoginResult { successful = false, error = "User not found" };
        }
        public async Task<string> Logout()
        {
            await _unitOfWork.SignInManager.SignOutAsync();
            return "Logout successful";
        }
        public async Task<string> Edit(MyUserEditDTO myUser)
        {
            MyUser user = await _unitOfWork.UserManager.FindByIdAsync(myUser.Id.ToString());
            if (user != null)
            {
                user.Email = myUser.Email;
                user.UserName = myUser.UserName;
                IdentityResult result = await _unitOfWork.UserManager.UpdateAsync(user);
                if (result.Succeeded)
                    return "User edited successfuly";
                else
                {
                    string ErrorMessage = "";
                    foreach (IdentityError error in result.Errors)
                        ErrorMessage += error.Description + "\n";
                    return ErrorMessage;
                }
            }
            return "User not found";
        }
        public async Task<IdentityResult> ChangePassword(MyUserChangePasswordDTO myUser)
        {
            MyUser user = await _unitOfWork.UserManager.FindByIdAsync(myUser.Id.ToString());
            return await _unitOfWork.UserManager.ChangePasswordAsync(user, myUser.OldPassword, myUser.NewPassword);
        }
        public async Task<string> Delete(int Id)
        {
            MyUser user = await _unitOfWork.UserManager.FindByIdAsync(Id.ToString());
            if (user == null)
                return "User not found";
            await _unitOfWork.UserManager.DeleteAsync(user);
            return "User deleted";
        }
        public async Task<List<MyUser>> UserList() =>
            await _unitOfWork.UserManager.Users.ToListAsync();
        private async Task<string> BuildToken(MyUser user)
        {
            IList<string> roles = await _unitOfWork.SignInManager.UserManager.GetRolesAsync(user);
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("accountId", user.Id.ToString()));
            claims.Add(new Claim("clientId", user.ClientId.ToString()));
            claims.Add(new Claim("email", user.Email));

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expiration = DateTime.UtcNow.AddDays(double.Parse(_configuration["JwtExpiryInDays"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JwtIssuer"],
                audience: _configuration["JwtAudience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}