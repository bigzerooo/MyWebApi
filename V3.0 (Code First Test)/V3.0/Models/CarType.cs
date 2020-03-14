using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace V3._0.Models
{
    public class CarType
    {
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
