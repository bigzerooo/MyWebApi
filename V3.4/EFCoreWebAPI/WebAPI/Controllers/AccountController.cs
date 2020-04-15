using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<MyUser> UserManager { get; }
        private SignInManager<MyUser> SignInManager { get; }
        // GET: /<controller>/
        
        public AccountController(UserManager<MyUser> userManager,
            SignInManager<MyUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        [Route("api/[controller]/register")]
        public async Task<IActionResult> Register([FromHeader]string username, [FromHeader]string email, [FromHeader]string password)
        {
            string resultMessage = "";
            try
            {
                MyUser myUser = await UserManager.FindByNameAsync(username);
                if (myUser == null)
                {
                    myUser = new MyUser();
                    myUser.UserName = username;
                    myUser.Email = email;
                    IdentityResult result = await UserManager.CreateAsync(myUser, password);
                    resultMessage = result.ToString();
                    //resultMessage = "User was created";
                    //return Ok("User was created");
                }
                else
                    resultMessage = "User already registered";
                //return Ok("User already registered");
            }
            catch (Exception x)
            {
                resultMessage = x.Message;
                //return Ok(x.Message);
            }
            return Ok(resultMessage);
        }

        [HttpGet]
        [Route("api/[controller]/login")]
        public async Task<IActionResult> Login([FromHeader]string username, [FromHeader]string password)
        {
            string resultMessage = "";
            var result = await SignInManager.PasswordSignInAsync(username, password, false, false);            
            if(result.Succeeded)
            {
                resultMessage = "Success";
            }
            else
            {
                resultMessage = result.ToString();
            }
            return Ok(resultMessage);
        }

        //[Route("api/[controller]/logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    await SignInManager.SignOutAsync();
        //    return Ok("Logged out");
        //}

        //[Route("api/[controller]/words")]
        //public IActionResult Words([FromHeader]string word1, [FromHeader]string word2)
        //{            
        //    return Ok(word1+" "+word2);
        //}
    }

}
