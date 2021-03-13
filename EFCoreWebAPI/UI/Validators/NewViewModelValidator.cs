using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class NewViewModelValidator : AbstractValidator<NewViewModel>
    {
        public NewViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(5000);
        }

    }
}
