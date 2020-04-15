using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO.Identity
{
    public class MyUserRegisterDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
