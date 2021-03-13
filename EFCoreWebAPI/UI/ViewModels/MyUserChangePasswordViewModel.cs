namespace UI.ViewModels
{
    public class MyUserChangePasswordViewModel
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
        public string OldPassword { get; set; }
    }
}
