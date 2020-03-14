using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerHour { get; set; }
        public string Type { get; set; }
        public int? Year { get; set; }

        public CarType CarType { get; set; }
        public ICollection<CarHire> CarHires { get; set; }
    }
}
