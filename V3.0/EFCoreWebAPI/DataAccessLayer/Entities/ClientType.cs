using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ClientType
    {
        public string Type { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
