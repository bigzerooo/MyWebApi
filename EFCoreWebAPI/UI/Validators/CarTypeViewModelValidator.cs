using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Validators
{
    public class CarTypeViewModelValidator : AbstractValidator<CarTypeViewModel>
    {
        public CarTypeViewModelValidator()
        {
            RuleFor(x => x.type).NotEmpty().MaximumLength(45);
        }
    }    
}
