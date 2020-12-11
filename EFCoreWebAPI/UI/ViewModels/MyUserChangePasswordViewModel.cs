using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class MyUserChangePasswordViewModel
    {
        public int id { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }
        public string oldPassword { get; set; }        
    }
}
