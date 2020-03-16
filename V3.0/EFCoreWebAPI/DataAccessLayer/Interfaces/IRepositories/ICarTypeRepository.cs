using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarTypeRepository : IGenericRepository<CarType, int>
    {
    }
}
