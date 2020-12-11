using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class NewDTOValidator: AbstractValidator<NewDTO>
    {
        public NewDTOValidator()
        {
            RuleFor(x => x.Date);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(5000);
        }
    }
}
