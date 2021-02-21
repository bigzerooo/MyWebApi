using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class MyUserLoginViewModelValidator : AbstractValidator<MyUserLoginViewModel>
    {
        public MyUserLoginViewModelValidator()
        {
            RuleFor(x => x.userName)
                .NotEmpty();
            RuleFor(x => x.password)
                .NotEmpty();
        }
    }
}
