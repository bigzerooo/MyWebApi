using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext _context;
        private readonly ISortHelper<Car> _carSortHelper;
        private readonly ISortHelper<Client> _clientSortHelper;
        public ICarStateRepository CarStateRepository { get; }
        public ICarTypeRepository CarTypeRepository { get; }
        public IClientTypeRepository ClientTypeRepository { get; }
        public ICarHireRepository CarHireRepository { get; }
        public ICarRepository CarRepository { get; }
        public IClientRepository ClientRepository { get; }
        public INewRepository NewRepository { get; }
        public UserManager<MyUser> UserManager { get; }
        public RoleManager<MyRole> RoleManager { get; }
        public SignInManager<MyUser> SignInManager { get; }
        public UnitOfWork(
            MyDBContext context,
            ICarStateRepository carStateRepository,
            ICarTypeRepository carTypeRepository,
            IClientTypeRepository clientTypeRepository,
            ICarHireRepository carHireRepository,
            ICarRepository carRepository,
            IClientRepository clientRepository,
            INewRepository newRepository,
            UserManager<MyUser> userManager,
            SignInManager<MyUser> signInManager,
            RoleManager<MyRole> roleManager,
            ISortHelper<Car> carSortHelper,
            ISortHelper<Client> clientSortHelper)
        {
            _context = context;
            CarStateRepository = carStateRepository;
            CarTypeRepository = carTypeRepository;
            ClientTypeRepository = clientTypeRepository;
            CarHireRepository = carHireRepository;
            CarRepository = carRepository;
            ClientRepository = clientRepository;
            NewRepository = newRepository;
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
            _carSortHelper = carSortHelper;
            _clientSortHelper = clientSortHelper;
        }       
        public Task<int> Complete() => _context.SaveChangesAsync();
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
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