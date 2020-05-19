using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]    
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;            
        }

        // GET: /<controller>/
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] MyUserRegisterDTO myUser)
        {
            var result = await _accountService.Register(myUser);
            if (result.Succeeded)
                return Ok("User registered");
            else
            {
                string Errors = "";
                foreach (var error in result.Errors)
                    Errors += $"{error.Description}\n";
                return BadRequest(Errors);
            }
                
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] MyUserLoginDTO myUser)
        {
            var result = await _accountService.Login(myUser);
            if (result.successful)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(await _accountService.Logout());
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _accountService.Delete(id));
        }
        [HttpGet]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody]MyUserEditDTO myUser)
        {
            return Ok(await _accountService.Edit(myUser));
        }
        [HttpGet]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]MyUserChangePasswordDTO myUser)
        {
            return Ok(await _accountService.ChangePassword(myUser));
        }        
        [HttpGet]        
        public async Task<IActionResult> UserList()
        {
            return Ok(await _accountService.UserList());
        }

    }

}
