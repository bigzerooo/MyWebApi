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
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AccountService: IAccountService
    {                
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<IdentityResult> Register(MyUserRegisterDTO myUser)
        {            
            var clientId = await _unitOfWork.clientRepository.AddAsync(new Client { ClientTypeId = 1 });
            
            MyUser user = new MyUser { Email = myUser.Email, UserName = myUser.UserName, ClientId=clientId };

            var result = await _unitOfWork.userManager.CreateAsync(user, myUser.Password);            
            return result;
        }        
        public async Task<LoginResult> Login(MyUserLoginDTO myUser)
        {
            MyUser user = await _unitOfWork.userManager.FindByNameAsync(myUser.UserName);
            if(user != null)
            {
                var result = await _unitOfWork.signInManager.PasswordSignInAsync(myUser.UserName, myUser.Password, myUser.RememberMe, false);
                if (result.Succeeded)
                    return new LoginResult { token = await BuildToken(user), successful = true };
                else
                    return new LoginResult { successful = false, error = "Invalid password" };
            }
            return new LoginResult { successful = false, error = "User not found" };
        }
        public async Task<string> Logout()
        {
            await _unitOfWork.signInManager.SignOutAsync();
            return "Logout successful";
        }
        public async Task<string> Edit(MyUserEditDTO myUser)
        {
            MyUser user = await _unitOfWork.userManager.FindByIdAsync(myUser.Id.ToString());//id интовая а для метода - строковая
            if (user != null)
            {
                user.Email = myUser.Email;
                user.UserName = myUser.UserName;
                var result = await _unitOfWork.userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return "User edited successfuly";
                }
                else
                {
                    string ErrorMessage = "";
                    foreach (var error in result.Errors)
                    {
                        ErrorMessage += error.Description + "\n";
                    }
                    return ErrorMessage;
                }
            }
            else
            {
                return "User not found";
            }
        }
        public async Task<IdentityResult> ChangePassword(MyUserChangePasswordDTO myUser)
        {
            MyUser user = await _unitOfWork.userManager.FindByIdAsync(myUser.Id.ToString());
            var result = await _unitOfWork.userManager.ChangePasswordAsync(user, myUser.OldPassword, myUser.NewPassword);
            return result;                
        }
        public async Task<string> Delete (int Id)
        {
            MyUser user = await _unitOfWork.userManager.FindByIdAsync(Id.ToString());
            if(user!=null)
            {
                var result = await _unitOfWork.userManager.DeleteAsync(user);
                return "User deleted";
            }
            else
            {
                return "User not found";
            }            
        }
        public async Task<List<MyUser>> UserList()
        {
            return await _unitOfWork.userManager.Users.ToListAsync();
        }
        
        private async Task<string>  BuildToken(MyUser user)//async?
        {
            var roles = await _unitOfWork.signInManager.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim("accountId", user.Id.ToString()));
            claims.Add(new Claim("clientId", user.ClientId.ToString()));
            claims.Add(new Claim("email", user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(double.Parse(_configuration["JwtExpiryInDays"]));

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
