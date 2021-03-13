using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class CarTypeViewModelValidator : AbstractValidator<CarTypeViewModel>
    {
        public CarTypeViewModelValidator()
        {
            RuleFor(x => x.Type).NotEmpty().MaximumLength(45);
        }
    }
}
