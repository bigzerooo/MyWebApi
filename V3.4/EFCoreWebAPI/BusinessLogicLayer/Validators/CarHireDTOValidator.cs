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
            RuleFor(x => x.CarStateId).NotEmpty();            
            RuleFor(x => x.EndDate).NotEmpty().GreaterThanOrEqualTo(x=>x.BeginDate).GreaterThanOrEqualTo(DateTime.Now); ;            
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Discount).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Penalty).NotEmpty().GreaterThanOrEqualTo(0);
            
        }
    }
}
