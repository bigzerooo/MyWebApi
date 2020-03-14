using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace V3._0.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }        
        public string Adress { get; set; }        
        public string PhoneNumber { get; set; }        
        public string TypeOfClient { get; set; }


        public ClientType ClientType { get; set; }
        public ICollection<CarHire> CarHires { get; set; }
    }
}
