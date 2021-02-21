using DataAccessLayer.Interfaces.EntityInterfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class ClientType : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}