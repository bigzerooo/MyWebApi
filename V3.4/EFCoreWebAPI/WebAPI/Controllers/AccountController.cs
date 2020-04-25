using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]    
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;            
        }

        // GET: /<controller>/
        [HttpGet]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] MyUserRegisterDTO myUser)
        {
            return Ok(await _accountService.Register(myUser));
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] MyUserLoginDTO myUser)
        {
            return Ok(await _accountService.Login(myUser));
        }
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(await _accountService.Logout());
        }
        [HttpGet]
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
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]MyUserCreateDTO myUser)
        {
            return Ok(await _accountService.Create(myUser));
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
