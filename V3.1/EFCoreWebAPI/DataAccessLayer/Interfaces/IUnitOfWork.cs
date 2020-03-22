using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ICarStateRepository carStateRepository { get; }        
        ICarTypeRepository carTypeRepository { get; }
        IClientTypeRepository clientTypeRepository { get; }
        ICarHireRepository carHireRepository { get; }
        ICarRepository carRepository { get; }
        IClientRepository clientRepository { get; }        
        void Complete();
    }
}
