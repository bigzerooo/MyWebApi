using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CarState
    {
        public string State { get; set; }
        public ICollection<CarHire> CarHires { get; set; }
    }
}
