using System.ComponentModel.DataAnnotations;

namespace UI.ViewModels
{
    public class MyUserRegisterViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string password { get; set; }
        [Required(ErrorMessage = "Confirmed password is required!")]
        [Compare("Password", ErrorMessage = "Passwords are not the same!")]
        public string passwordConfirm { get; set; }
    }
}
