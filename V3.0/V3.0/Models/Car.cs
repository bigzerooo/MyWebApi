using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace V3._0.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerHour { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
    }
}
