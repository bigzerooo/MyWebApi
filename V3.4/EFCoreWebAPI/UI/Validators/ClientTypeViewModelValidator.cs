using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Validators
{
    public class ClientTypeViewModelValidator : AbstractValidator<ClientTypeViewModel>
    {
        public ClientTypeViewModelValidator()
        {
            RuleFor(x => x.type).NotEmpty().MaximumLength(45);
        }

    }
}
