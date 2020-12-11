using BusinessLogicLayer.DTO;
using FluentValidation;

namespace BusinessLogicLayer.Validators
{
    public class CarTypeDTOValidator : AbstractValidator<CarTypeDTO>
    {
        public CarTypeDTOValidator() =>
            RuleFor(x => x.Type).NotEmpty().MaximumLength(45);
    }
}