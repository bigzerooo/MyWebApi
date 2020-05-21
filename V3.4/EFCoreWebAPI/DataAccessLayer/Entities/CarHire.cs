using DataAccessLayer.Interfaces.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CarHire : IEntity<int>
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public int ClientId { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public decimal ExpectedPrice { get; set; }
        
        public int? CarStateId { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Penalty { get; set; }

        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
        public bool Returned { get; set; }

        public Car Car { get; set; }
        public Client Client { get; set; }
        public CarState State { get; set; }
    }
}
