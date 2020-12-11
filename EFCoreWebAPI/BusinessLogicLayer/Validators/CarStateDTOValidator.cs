using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class CarStateDTOValidator : AbstractValidator<CarStateDTO>
    {
        public CarStateDTOValidator()
        {
            RuleFor(x => x.State).NotEmpty().MaximumLength(45);
        }
    }
}
