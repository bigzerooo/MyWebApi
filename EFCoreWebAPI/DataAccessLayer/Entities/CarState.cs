using DataAccessLayer.Interfaces.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class CarState : IEntity<int>
    {
        public int Id { get; set; }
        public string State { get; set; }
        public ICollection<CarHire> CarHires { get; set; }
    }
}