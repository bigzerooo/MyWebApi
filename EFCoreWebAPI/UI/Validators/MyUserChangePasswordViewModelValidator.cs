using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class MyUserChangePasswordViewModelValidator : AbstractValidator<MyUserChangePasswordViewModel>
    {
        public MyUserChangePasswordViewModelValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6);
            RuleFor(x => x.NewPasswordConfirm).NotEmpty().Equal(x => x.NewPassword).WithMessage("Passwords are not equal");
        }
    }
}
