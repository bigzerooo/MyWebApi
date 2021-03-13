using FluentValidation;
using System;
using UI.ViewModels;

namespace UI.Validators
{
    public class CarViewModelValidator : AbstractValidator<CarViewModel>
    {
        public CarViewModelValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty()
                .MaximumLength(45);

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PricePerHour)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Year)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThanOrEqualTo(1900);

            RuleFor(x => x.Description)
                .MaximumLength(1000);
        }
    }
}
