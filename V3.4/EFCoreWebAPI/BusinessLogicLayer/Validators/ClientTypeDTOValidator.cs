using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class ClientTypeDTOValidator: AbstractValidator<ClientTypeDTO>
    {
        public ClientTypeDTOValidator()
        {
            RuleFor(x => x.Type).NotEmpty().MaximumLength(45);
        }

    }
}
