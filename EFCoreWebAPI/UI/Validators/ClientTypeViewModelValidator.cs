using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class ClientTypeViewModelValidator : AbstractValidator<ClientTypeViewModel>
    {
        public ClientTypeViewModelValidator()
        {
            RuleFor(x => x.type).NotEmpty().MaximumLength(45);
        }

    }
}
