using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces.EntityInterfaces;
namespace DataAccessLayer.Entities
{
    public class Joined : IEntity<int>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Brand { get; set; }
        public decimal CarPrice { get; set; }
        public decimal PricePerHour { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public int ClientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string TypeOfClient { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarState { get; set; }
        public decimal Discount { get; set; }
        public decimal Penalty { get; set; }
        public decimal Price { get; set; }
    }
}
