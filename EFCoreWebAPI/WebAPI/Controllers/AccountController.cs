using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.DTO.Identity.Results;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) =>
            _accountService = accountService;

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] MyUserRegisterDTO myUser)
        {
            IdentityResult result = await _accountService.Register(myUser);
            if (result.Succeeded)
                return Ok("User registered");
            else
            {
                string errors = "";
                foreach (var error in result.Errors)
                    errors += $"{error.Description}\n";
                return BadRequest(errors);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] MyUserLoginDTO myUser)
        {
            LoginResult result = await _accountService.Login(myUser);
            if (result.successful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout() => Ok(await _accountService.Logout());

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _accountService.Delete(id));

        [HttpGet]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody]MyUserEditDTO myUser) => Ok(await _accountService.Edit(myUser));

        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody]MyUserChangePasswordDTO myUser)
        {
            IdentityResult result = await _accountService.ChangePassword(myUser);
            if (result.Succeeded)
                return Ok("Password changed");
            string errors = "";
            foreach (IdentityError error in result.Errors)
                errors += $"{error.Description}\n";
            return BadRequest(errors);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> UserList() => Ok(await _accountService.UserList());
    }
}