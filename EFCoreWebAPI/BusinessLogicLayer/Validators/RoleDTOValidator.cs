using BusinessLogicLayer.DTO.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class RoleDTOValidator  : AbstractValidator<RoleDTO>
    {
        public RoleDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
        }
    }
}
