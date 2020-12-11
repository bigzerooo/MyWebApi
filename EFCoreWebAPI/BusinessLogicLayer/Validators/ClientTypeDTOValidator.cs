using BusinessLogicLayer.DTO;
using FluentValidation;

namespace BusinessLogicLayer.Validators
{
    public class ClientTypeDTOValidator : AbstractValidator<ClientTypeDTO>
    {
        public ClientTypeDTOValidator() =>
            RuleFor(x => x.Type).NotEmpty().MaximumLength(45);
    }
}