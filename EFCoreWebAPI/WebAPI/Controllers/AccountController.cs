using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.DTO.Identity.Results;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Analyze]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) =>
            _accountService = accountService;

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] MyUserRegisterDTO myUser)
        {
            IdentityResult result = await _accountService.RegisterAsync(myUser);
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
        public async Task<IActionResult> Login([FromBody] MyUserLoginDTO myUser)
        {
            LoginResult result = await _accountService.LoginAsync(myUser);
            if (result.successful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Logout() => Ok(await _accountService.LogoutAsync());

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _accountService.DeleteUserAsync(id));

        [HttpGet]
        public async Task<IActionResult> Edit([FromBody] MyUserEditDTO myUser) => Ok(await _accountService.EditUserAsync(myUser));

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] MyUserChangePasswordDTO myUser)
        {
            IdentityResult result = await _accountService.ChangePasswordAsync(myUser);
            if (result.Succeeded)
                return Ok("Password changed");
            string errors = "";
            foreach (IdentityError error in result.Errors)
                errors += $"{error.Description}\n";
            return BadRequest(errors);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> UserList() => Ok(await _accountService.GetAllUsersAsync());
    }
}