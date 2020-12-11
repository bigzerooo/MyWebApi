using BusinessLogicLayer.DTO;
using FluentValidation;

namespace BusinessLogicLayer.Validators
{
    public class CarStateDTOValidator : AbstractValidator<CarStateDTO>
    {
        public CarStateDTOValidator() =>
            RuleFor(x => x.State).NotEmpty().MaximumLength(45);
    }
}