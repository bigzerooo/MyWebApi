﻿using BusinessLogicLayer.DTO;
using FluentValidation;

namespace BusinessLogicLayer.Validators
{
    public class NewsDTOValidator : AbstractValidator<NewsDTO>
    {
        public NewsDTOValidator()
        {
            RuleFor(x => x.Date);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(45);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(5000);
        }
    }
}