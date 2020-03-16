using DataAccessLayer.Interfaces.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CarState : IEntity<int>
    {
        public int Id { get; set; }
        public string State { get; set; }
        public ICollection<CarHire> CarHires { get; set; }
    }
}
