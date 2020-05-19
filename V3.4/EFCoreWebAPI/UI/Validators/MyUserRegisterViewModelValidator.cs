using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using UI.ViewModels;
namespace UI.Validators
{
    public class MyUserRegisterViewModelValidator: AbstractValidator<MyUserRegisterViewModel>
    {
        public MyUserRegisterViewModelValidator()
        {
            RuleFor(x => x.userName)
                .NotEmpty();

            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.password)
                .NotEmpty()
                .MinimumLength(6);                               

            RuleFor(x => x.passwordConfirm)
                .NotEmpty()
                .Equal(x => x.password)
                .WithMessage("Passwords are not equal");
        }
    }
}
