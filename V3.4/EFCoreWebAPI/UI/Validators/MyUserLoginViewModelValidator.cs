using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Validators
{
    public class MyUserLoginViewModelValidator: AbstractValidator<MyUserLoginViewModel>
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
