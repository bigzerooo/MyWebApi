using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarStateRepository CarStateRepository { get; }
        ICarTypeRepository CarTypeRepository { get; }
        IClientTypeRepository ClientTypeRepository { get; }
        ICarHireRepository CarHireRepository { get; }
        ICarRepository CarRepository { get; }
        IClientRepository ClientRepository { get; }
        INewRepository NewRepository { get; }
        ILogsRepository LogsRepository { get; }
        UserManager<MyUser> UserManager { get; }
        RoleManager<MyRole> RoleManager { get; }
        SignInManager<MyUser> SignInManager { get; }
        Task<int> Complete();
    }
}