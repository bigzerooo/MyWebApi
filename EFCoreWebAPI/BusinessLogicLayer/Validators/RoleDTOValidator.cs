using BusinessLogicLayer.DTO.Identity;
using FluentValidation;

namespace BusinessLogicLayer.Validators
{
    public class RoleDTOValidator : AbstractValidator<RoleDTO>
    {
        public RoleDTOValidator() =>
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
    }
}