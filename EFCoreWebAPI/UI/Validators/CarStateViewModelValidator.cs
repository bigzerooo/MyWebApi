using FluentValidation;
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
