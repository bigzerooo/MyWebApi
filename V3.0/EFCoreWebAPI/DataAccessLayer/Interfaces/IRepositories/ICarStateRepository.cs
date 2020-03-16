using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarStateRepository : IGenericRepository<CarState, int>
    {
    }
}
