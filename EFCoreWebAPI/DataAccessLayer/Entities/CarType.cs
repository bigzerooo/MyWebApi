using DataAccessLayer.Interfaces.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class CarType : IEntity<int>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}