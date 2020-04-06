using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces.IRepositories;
namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ICarHireRepository carHireRepository { get; }
        ICarRepository carRepository { get; }
        IClientRepository clientRepository { get; }
        IJoinedRepository joinedRepository { get; }
        void Complete();
    }
}
