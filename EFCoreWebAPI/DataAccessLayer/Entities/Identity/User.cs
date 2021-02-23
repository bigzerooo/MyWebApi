using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}