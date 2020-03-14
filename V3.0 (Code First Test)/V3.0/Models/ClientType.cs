using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace V3._0.Models
{
    public class ClientType
    {
        public string Type { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
