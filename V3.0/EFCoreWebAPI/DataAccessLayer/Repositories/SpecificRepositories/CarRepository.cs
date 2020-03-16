using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarRepository : GenericRepository<Car, int>, ICarRepository
    {
        public CarRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
    }
}
