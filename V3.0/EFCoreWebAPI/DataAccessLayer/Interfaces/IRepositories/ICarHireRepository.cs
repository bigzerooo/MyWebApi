using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarHireRepository: IGenericRepository<CarHire,int>
    {
        public CarHire GetCarHireDetailsById(int Id);
        public List<CarHire> GetCarHireDetails();
    }
}
