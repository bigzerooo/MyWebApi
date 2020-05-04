using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class CarTypeDTOValidator : AbstractValidator<CarTypeDTO>
    {
        public CarTypeDTOValidator()
        {
            RuleFor(x => x.Type).NotEmpty().MaximumLength(45);
        }
    }
}
