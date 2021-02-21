using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
    {
        public ClientViewModelValidator()
        {
            RuleFor(x => x.firstName).MaximumLength(45);
            RuleFor(x => x.lastName).MaximumLength(45);
            RuleFor(x => x.secondName).MaximumLength(45);
            RuleFor(x => x.phoneNumber).MaximumLength(45).Matches(@"^\+?3?8?(0\d{9})$");
            RuleFor(x => x.adress).MaximumLength(45);
        }
    }
}
