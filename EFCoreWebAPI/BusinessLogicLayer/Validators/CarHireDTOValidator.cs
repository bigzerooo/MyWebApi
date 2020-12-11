using BusinessLogicLayer.DTO;
using FluentValidation;

namespace BusinessLogicLayer.Validators
{
    public class CarHireDTOValidator : AbstractValidator<CarHireDTO>
    {
        public CarHireDTOValidator()
        {
            RuleFor(x => x.CarId).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();
        }
    }
}