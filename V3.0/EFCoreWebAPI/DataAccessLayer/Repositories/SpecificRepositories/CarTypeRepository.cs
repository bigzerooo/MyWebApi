using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarTypeRepository : GenericRepository<CarType, int>, ICarTypeRepository
    {
        public CarTypeRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public CarType GetCarTypeDetailsById(int Id)
        {
            var carType = _myDBContext.CarTypes
                .Include(c => c.Cars)
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            return carType;
        }
        public List<CarType> GetCarTypeDetails()
        {
            var carTypes = _myDBContext.CarTypes
                .Include(c => c.Cars)
                .ToList();            
            return carTypes;
        }
    }
}
