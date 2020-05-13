using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly MyDBContext _context;
        private readonly ICarStateRepository _carStateRepository;
        private readonly ICarTypeRepository _carTypeRepository;
        private readonly IClientTypeRepository _clientTypeRepository;
        private readonly ICarHireRepository _carHireRepository;
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly RoleManager<MyRole> _roleManager;
        private readonly ISortHelper<Car> _carSortHelper;
        private readonly ISortHelper<Client> _clientSortHelper;
        public UnitOfWork(
            MyDBContext context,
            ICarStateRepository carStateRepository,
            ICarTypeRepository carTypeRepository,
            IClientTypeRepository clientTypeRepository,
            ICarHireRepository carHireRepository,
            ICarRepository carRepository,
            IClientRepository clientRepository,
            UserManager<MyUser> userManager,
            SignInManager<MyUser> signInManager,
            RoleManager<MyRole> roleManager,
            ISortHelper<Car> carSortHelper,
            ISortHelper<Client> clientSortHelper)
        {
            _context = context;
            _carStateRepository = carStateRepository;
            _carTypeRepository = carTypeRepository;
            _clientTypeRepository = clientTypeRepository;
            _carHireRepository = carHireRepository;
            _carRepository = carRepository;
            _clientRepository = clientRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _carSortHelper = carSortHelper;
            _clientSortHelper = clientSortHelper;
        }
        public ICarStateRepository carStateRepository
        {
            get
            {
                return _carStateRepository;
            }
        }
        public ICarTypeRepository carTypeRepository
        {
            get
            {
                return _carTypeRepository;
            }
        }
        public IClientTypeRepository clientTypeRepository
        {
            get
            {
                return _clientTypeRepository;
            }
        }
        public ICarHireRepository carHireRepository
        {
            get
            {
                return _carHireRepository;
            }
        }
        public ICarRepository carRepository
        {
            get
            {
                return _carRepository;
            }
        }
        public IClientRepository clientRepository
        {
            get
            {
                return _clientRepository;
            }
        }
        public UserManager<MyUser> userManager
        {
            get
            {
                return _userManager;
            }
        }
        public RoleManager<MyRole> roleManager
        {
            get
            {
                return _roleManager;
            }
        }
        public SignInManager<MyUser> signInManager
        {
            get
            {
                return _signInManager;
            }
        }



        public Task<int> Complete() => _context.SaveChangesAsync();
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
