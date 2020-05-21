using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class CarHireDTO
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

        public DateTime EndDate { get; set; }
        public decimal? Price { get; set; }
        public bool Returned { get; set; }
    }
}
