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
        //посмотреть нужна ли тут конфигурация
        private readonly IConfiguration configuration;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(unitOfWork, mapper) =>
            this.configuration = configuration;

        public async Task<IdentityResult> RegisterAsync(MyUserRegisterDTO userDTO)
        {
            var clientId = await unitOfWork.ClientRepository
                .AddAsync(new Client
                {
                    ClientTypeId = 1 //убрать хардкод
                });

            var user = new MyUser
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,//заюзать автомаппер
                ClientId = clientId
            };

            return await unitOfWork.UserManager.CreateAsync(user, userDTO.Password);
        }

        public async Task<LoginResult> LoginAsync(MyUserLoginDTO userDTO)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(userDTO.UserName);
            if (user != null)
            {
                var result = await unitOfWork.SignInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, userDTO.RememberMe, false);
                if (result.Succeeded)
                    return new LoginResult { token = await BuildToken(user), successful = true };
                else
                    return new LoginResult { successful = false, error = "Invalid password" }; //переделать ошибки
            }
            return new LoginResult { successful = false, error = "User not found" };
        }

        public async Task<string> LogoutAsync()
        {
            await unitOfWork.SignInManager.SignOutAsync();
            return "Logout successful"; //переделать вывод
        }

        public async Task<string> EditUserAsync(MyUserEditDTO userDTO)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(userDTO.Id.ToString());
            if (user != null)
            {
                user.Email = userDTO.Email; //автомаппер
                user.UserName = userDTO.UserName;
                var result = await unitOfWork.UserManager.UpdateAsync(user);
                if (result.Succeeded)
                    return "User edited successfuly"; //переделать
                else
                {
                    string ErrorMessage = "";
                    foreach (var error in result.Errors) //тем более переделать
                        ErrorMessage += error.Description + "\n";
                    return ErrorMessage;
                }
            }
            return "User not found"; //аналогично
        }

        public async Task<IdentityResult> ChangePasswordAsync(MyUserChangePasswordDTO userDTO)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(userDTO.Id.ToString());
            return await unitOfWork.UserManager.ChangePasswordAsync(user, userDTO.OldPassword, userDTO.NewPassword);
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(id.ToString());
            if (user == null)
                return "User not found"; //переделать
            await unitOfWork.UserManager.DeleteAsync(user);
            return "User deleted"; //переделать
        }

        public async Task<List<MyUser>> GetAllUsersAsync() =>
            await unitOfWork.UserManager.Users.ToListAsync();

        //пересмотреть
        private async Task<string> BuildToken(MyUser user)
        {
            var roles = await unitOfWork.SignInManager.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("accountId", user.Id.ToString()));
            claims.Add(new Claim("clientId", user.ClientId.ToString()));
            claims.Add(new Claim("email", user.Email));

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(double.Parse(configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JwtIssuer"],
                audience: configuration["JwtAudience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}