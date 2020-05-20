using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Validators
{
    public class CarStateViewModelValidator : AbstractValidator<CarStateViewModel>
    {
        public CarStateViewModelValidator()
        {
            RuleFor(x => x.state).NotEmpty().MaximumLength(45);
        }
    }    
}
