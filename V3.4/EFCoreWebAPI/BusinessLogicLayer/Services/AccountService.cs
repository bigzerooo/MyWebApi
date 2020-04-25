using AutoMapper;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AccountService: IAccountService
    {        
        //it's just here, but not used yet
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Register(MyUserRegisterDTO myUser)
        {
            if (myUser.Password != myUser.PasswordConfirm)
                return "Passwords are not matching";

            MyUser user = new MyUser { Email = myUser.Email, UserName = myUser.UserName };
            var result = await _unitOfWork.userManager.CreateAsync(user, myUser.Password);
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
        public async Task<string> Create(MyUserCreateDTO myUser)
        {
            MyUser user = new MyUser { Email = myUser.Email, UserName = myUser.UserName };
            var result = await _unitOfWork.userManager.CreateAsync(user, myUser.Password);
            if (result.Succeeded)
            {
                await _unitOfWork.signInManager.SignInAsync(user, false);
                return "User registered";
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
        public async Task<string> Login(MyUserLoginDTO myUser)
        {
            var result = await _unitOfWork.signInManager.PasswordSignInAsync(myUser.UserName, myUser.Password, myUser.RememberMe, false);
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
        public async Task<string> ChangePassword(MyUserChangePasswordDTO myUser)
        {
            MyUser user = await _unitOfWork.userManager.FindByIdAsync(myUser.Id.ToString());
            if (user != null)
            {
                IdentityResult result =
                    await _unitOfWork.userManager.ChangePasswordAsync(user, myUser.OldPassword, myUser.NewPassword);
                if (result.Succeeded)
                {
                    return "Password Change successful";
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
        public async Task<List<MyUser>> UserList()
        {
            return await _unitOfWork.userManager.Users.ToListAsync();
        }


    }
}
