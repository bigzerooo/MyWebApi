using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace V3._0.Models
{
    public class CarState
    {
        public string State { get; set; }
        public ICollection<CarHire> CarHires { get; set; }
    }
}
