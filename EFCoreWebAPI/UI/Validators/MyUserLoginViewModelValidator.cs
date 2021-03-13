using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class MyUserLoginViewModelValidator : AbstractValidator<MyUserLoginViewModel>
    {
        public MyUserLoginViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
