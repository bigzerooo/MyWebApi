using FluentValidation;
using UI.ViewModels;
namespace UI.Validators
{
    public class MyUserRegisterViewModelValidator : AbstractValidator<MyUserRegisterViewModel>
    {
        public MyUserRegisterViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.PasswordConfirm)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Passwords are not equal");
        }
    }
}
