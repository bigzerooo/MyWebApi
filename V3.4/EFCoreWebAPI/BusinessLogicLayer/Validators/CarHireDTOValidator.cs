using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
