using DataAccessLayer.Interfaces.EntityInterfaces;
using System;

namespace DataAccessLayer.Entities
{
    public class New : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}