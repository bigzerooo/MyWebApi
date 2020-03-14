using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CarHire
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public int ClientId { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarState { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Penalty { get; set; }
        public decimal Price { get; set; }

        public Car Car { get; set; }
        public Client Client { get; set; }
        public CarState State { get; set; }
    }
}
