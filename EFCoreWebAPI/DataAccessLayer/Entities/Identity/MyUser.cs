    using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities.Identity
{
    public class MyUser:IdentityUser<int>
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
