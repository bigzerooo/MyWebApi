using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces.EntityInterfaces;
namespace DataAccessLayer.Entities
{
    public class CarHire : IEntity<int>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarState { get; set; }
        public decimal Discount { get; set; }
        public decimal Penalty { get; set; }
        public decimal Price { get; set; }
    }
}
