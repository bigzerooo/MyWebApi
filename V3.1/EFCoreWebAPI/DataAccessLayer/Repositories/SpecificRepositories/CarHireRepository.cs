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
    public class CarHireRepository: GenericRepository<CarHire,int>,ICarHireRepository
    {
        public CarHireRepository(MyDBContext myDBContext) : base(myDBContext)
        {
            
        }
        public CarHire GetCarHireDetailsById(int Id)
        {
            var carHire = _myDBContext.CarHires
                .Include(c => c.Car)
                    .ThenInclude(s=>s.CarType)
                .Include(c => c.Client)
                    .ThenInclude(s=>s.ClientType)
                .Include(c => c.State)
                .Where(c=>c.Id==Id)
                .FirstOrDefault();
            return carHire;                
        }
        public List<CarHire> GetCarHireDetails()
        {
            var carHires = _myDBContext.CarHires
                .Include(c => c.Car)
                    .ThenInclude(s => s.CarType)
                .Include(c => c.Client)
                    .ThenInclude(s => s.ClientType)
                .Include(c => c.State)
                .ToList();
            return carHires;
        }

    }
}
