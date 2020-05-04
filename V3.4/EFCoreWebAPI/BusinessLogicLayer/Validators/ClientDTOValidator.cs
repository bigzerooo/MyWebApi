using BusinessLogicLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Validators
{
    public class ClientDTOValidator: AbstractValidator<ClientDTO>
    {
        public ClientDTOValidator()
        {
            RuleFor(x => x.ClientTypeId).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(45);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(45);
            RuleFor(x => x.SecondName).NotEmpty().MaximumLength(45);            
            RuleFor(x => x.PhoneNumber).MaximumLength(45).Matches(@"^\+?3?8?(0\d{9})$"); 
            RuleFor(x => x.Adress).MaximumLength(45);
        }
    }
}
