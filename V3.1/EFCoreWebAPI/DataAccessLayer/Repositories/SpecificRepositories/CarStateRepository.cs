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
    public class CarStateRepository : GenericRepository<CarState, int>, ICarStateRepository
    {
        public CarStateRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public CarState GetCarStateDetailsById(int Id)
        {
            var carState = _myDBContext.CarStates
                .Include(c => c.CarHires)
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            return carState;
        }
        public List<CarState> GetCarStateDetails()
        {
            var carStates = _myDBContext.CarStates
                .Include(c => c.CarHires)
                .ToList();
            return carStates;
        }
    }
}
