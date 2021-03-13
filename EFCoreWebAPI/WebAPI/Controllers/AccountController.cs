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
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] MyUserRegisterDTO myUser)
        {
            IdentityResult result = await accountService.RegisterAsync(myUser);
            return Json(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] MyUserLoginDTO myUser)
        {
            LoginResult result = await accountService.LoginAsync(myUser);

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await accountService.LogoutAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] MyUserChangePasswordDTO myUser)
        {
            IdentityResult result = await accountService.ChangePasswordAsync(myUser);

            return Json(result);
        }

        //имплементировать на UI или удалить
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await accountService.DeleteUserAsync(id));

        [HttpGet]
        public async Task<IActionResult> Edit([FromBody] MyUserEditDTO myUser) => Ok(await accountService.EditUserAsync(myUser));

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> UserList() => Ok(await accountService.GetAllUsersAsync());
    }
}