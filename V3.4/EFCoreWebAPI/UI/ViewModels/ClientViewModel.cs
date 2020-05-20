using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class ClientViewModel
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string adress { get; set; }
        public string phoneNumber { get; set; }
        public int clientTypeId { get; set; }
        public byte[] photo { get; set; }
    }
}
