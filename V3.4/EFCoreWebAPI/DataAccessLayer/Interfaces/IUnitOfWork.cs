using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.AspNetCore.Identity;
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
        UserManager<MyUser> userManager { get; }
        RoleManager<MyRole> roleManager { get; }
        SignInManager<MyUser> signInManager { get; }
        Task<int> Complete();
    }
}
