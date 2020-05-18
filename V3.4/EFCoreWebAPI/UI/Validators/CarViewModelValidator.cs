using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Validators
{
    public class CarViewModelValidator: AbstractValidator<CarViewModel>
    {
        public CarViewModelValidator()
        {
            RuleFor(x => x.brand)
                .NotEmpty()
                .MaximumLength(45);

            RuleFor(x => x.price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.pricePerHour)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.year)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThanOrEqualTo(1900);

            RuleFor(x => x.description)
                .MaximumLength(1000);
        }
    }
}
