using FluentValidation;
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
