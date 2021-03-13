using FluentValidation;
using UI.ViewModels;

namespace UI.Validators
{
    public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
    {
        public ClientViewModelValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(45);
            RuleFor(x => x.LastName).MaximumLength(45);
            RuleFor(x => x.SecondName).MaximumLength(45);
            RuleFor(x => x.PhoneNumber).MaximumLength(45).Matches(@"^\+?3?8?(0\d{9})$");
            RuleFor(x => x.Adress).MaximumLength(45);
        }
    }
}
