using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces.EntityInterfaces;
namespace DataAccessLayer.Entities
{
    public class Client :IEntity<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Adress { get; set; }  
        public string PhoneNumber { get; set; }
        public string TypeOfClient { get; set; }
    }
}
