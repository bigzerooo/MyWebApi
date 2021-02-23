using System;

namespace BusinessLogicLayer.DTO
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}