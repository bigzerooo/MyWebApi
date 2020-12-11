﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Validators
{
    public class MyUserChangePasswordViewModelValidator: AbstractValidator<MyUserChangePasswordViewModel>
    {
        public MyUserChangePasswordViewModelValidator()
        {
            RuleFor(x => x.oldPassword).NotEmpty();
            RuleFor(x => x.newPassword).NotEmpty().MinimumLength(6);
            RuleFor(x => x.newPasswordConfirm).NotEmpty().Equal(x=>x.newPassword).WithMessage("Passwords are not equal");
        }
    }
}