using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ICarStateRepository carStateRepository { get; }        
        ICarTypeRepository carTypeRepository { get; }
        IClientTypeRepository clientTypeRepository { get; }
        ICarHireRepository carHireRepository { get; }
        ICarRepository carRepository { get; }
        IClientRepository clientRepository { get; }        
        Task<int> Complete();
    }
}
