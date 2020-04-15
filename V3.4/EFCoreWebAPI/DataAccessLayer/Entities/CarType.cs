using DataAccessLayer.Interfaces.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CarType : IEntity<int>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; } //может быть от этого надо избавится?
    }
}
