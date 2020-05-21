using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Validators
{
    public class NewViewModelValidator: AbstractValidator<NewViewModel>
    {
        public NewViewModelValidator()
        {
            RuleFor(x => x.name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.description).NotEmpty().MaximumLength(5000);
        }
        
    }
}
