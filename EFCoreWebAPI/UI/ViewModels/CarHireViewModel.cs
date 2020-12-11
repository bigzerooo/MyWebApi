using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class CarHireViewModel
    {
        public int id { get; set; }

        public int carId { get; set; }
        public int clientId { get; set; }

        public DateTime beginDate { get; set; }
        public DateTime expectedEndDate { get; set; }
        public decimal expectedPrice { get; set; }

        public int? carStateId { get; set; }
        public decimal? discount { get; set; }
        public decimal? penalty { get; set; }

        public DateTime endDate { get; set; }
        public decimal? price { get; set; }
        public bool returned { get; set; }
    }
}
