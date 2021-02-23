using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICarStateRepository CarStateRepository { get; }
        ICarTypeRepository CarTypeRepository { get; }
        IClientTypeRepository ClientTypeRepository { get; }
        ICarHireRepository CarHireRepository { get; }
        ICarRepository CarRepository { get; }
        IClientRepository ClientRepository { get; }
        INewsRepository NewRepository { get; }
        ILogsRepository LogsRepository { get; }
        UserManager<User> UserManager { get; }
        RoleManager<Role> RoleManager { get; }
        SignInManager<User> SignInManager { get; }
        Task<int> Complete();
    }
}