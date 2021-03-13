using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class ClientTypeViewModelValidator : AbstractValidator<ClientTypeViewModel>
    {
        public ClientTypeViewModelValidator()
        {
            RuleFor(x => x.Type).NotEmpty().MaximumLength(45);
        }

    }
}
