using DataAccessLayer.Interfaces.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ClientType : IEntity<int>
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
