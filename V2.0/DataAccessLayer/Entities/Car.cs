﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces.EntityInterfaces;
namespace DataAccessLayer.Entities
{
    public class Car: IEntity<int>
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerHour { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
    }
}
