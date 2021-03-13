using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UI.ViewModels
{
    public class IdentityResultViewModel
    {
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
