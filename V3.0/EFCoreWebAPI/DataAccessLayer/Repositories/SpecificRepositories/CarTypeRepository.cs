using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarTypeRepository : GenericRepository<CarType, int>, ICarTypeRepository
    {
        public CarTypeRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
    }
}
