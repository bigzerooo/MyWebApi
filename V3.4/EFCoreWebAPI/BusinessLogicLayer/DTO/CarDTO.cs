using System;
using System.Collections.Generic;
using System.Text;
namespace BusinessLogicLayer.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerHour { get; set; }
        public int CarTypeId { get; set; }
        public int? Year { get; set; }        
    }
}
