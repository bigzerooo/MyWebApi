using AutoMapper;
using BusinessLogicLayer.DTO.Identity;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AccountService
    {        
        //it's just here, but not used yet
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Register(MyUserRegisterDTO userDTO)
        {
            if (userDTO.Password != userDTO.PasswordConfirm)
                return "Passwords are not matching";

            MyUser user = new MyUser { Email = userDTO.Email, UserName = userDTO.UserName };
            var result = await _unitOfWork.userManager.CreateAsync(user,userDTO.Password);
            if (result.Succeeded)
            {
                await _unitOfWork.signInManager.SignInAsync(user, false);
                return "User registered";
            }
            else
            {
                string ErrorMessage="";
                foreach(var error in result.Errors)
                {
                    ErrorMessage+=error.Description+"\n";
                }
                return ErrorMessage;                
            }
        }
        public async Task<string> Login(MyUserLoginDTO userDTO)
        {
            var result = await _unitOfWork.signInManager.PasswordSignInAsync(userDTO.UserName, userDTO.Password, userDTO.RememberMe, false);
            if (result.Succeeded)
            {
                return "Login successful";
            }
            else
            {
                return "Invalid username and (or) password";
            }
        }
        public async Task<string> Logout()
        {
            await _unitOfWork.signInManager.SignOutAsync();
            return "Logout successful";
        }
        public async Task<string> Edit(MyUserEditDTO userDTO)
        {
            MyUser user = await _unitOfWork.userManager.FindByIdAsync(userDTO.Id.ToString());//id интовая а для метода - строковая
            if (user != null)
            {
                user.Email = userDTO.Email;
                user.UserName = userDTO.UserName;
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

    }
}
