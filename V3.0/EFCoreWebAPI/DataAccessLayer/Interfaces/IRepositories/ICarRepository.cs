using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarRepository : IGenericRepository<Car, int>
    {
        public Car GetCarDetailsById(int Id);
        public List<Car> GetCarDetails();
    }
}
