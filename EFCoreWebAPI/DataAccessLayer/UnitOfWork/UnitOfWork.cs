using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLDbContext context;
        private bool disposed = false;

        public ICarStateRepository CarStateRepository { get; }
        public ICarTypeRepository CarTypeRepository { get; }
        public IClientTypeRepository ClientTypeRepository { get; }
        public ICarHireRepository CarHireRepository { get; }
        public ICarRepository CarRepository { get; }
        public IClientRepository ClientRepository { get; }
        public INewsRepository NewRepository { get; }
        public ILogsRepository LogsRepository { get; }
        public UserManager<User> UserManager { get; }
        public RoleManager<Role> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }
        
        public UnitOfWork(
            SQLDbContext context,
            ICarStateRepository carStateRepository,
            ICarTypeRepository carTypeRepository,
            IClientTypeRepository clientTypeRepository,
            ICarHireRepository carHireRepository,
            ICarRepository carRepository,
            IClientRepository clientRepository,
            INewsRepository newRepository,
            ILogsRepository logsRepository,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager)
        {
            this.context = context;
            CarStateRepository = carStateRepository;
            CarTypeRepository = carTypeRepository;
            ClientTypeRepository = clientTypeRepository;
            CarHireRepository = carHireRepository;
            CarRepository = carRepository;
            ClientRepository = clientRepository;
            NewRepository = newRepository;
            LogsRepository = logsRepository;
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public Task<int> Complete()
        {
            return context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    context.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}