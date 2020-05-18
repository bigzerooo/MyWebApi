using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Client : IEntity<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int ClientTypeId { get; set; }
        
        public MyUser User { get; set; }

        public ClientType ClientType { get; set; }
        public ICollection<CarHire> CarHires { get; set; }
    }
}
