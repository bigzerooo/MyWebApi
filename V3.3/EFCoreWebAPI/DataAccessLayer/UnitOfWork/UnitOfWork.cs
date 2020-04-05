using DataAccessLayer.DBContext;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IRepositories;
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
        public UnitOfWork(
            MyDBContext context,
            ICarStateRepository carStateRepository,
            ICarTypeRepository carTypeRepository,
            IClientTypeRepository clientTypeRepository,
            ICarHireRepository carHireRepository,
            ICarRepository carRepository,
            IClientRepository clientRepository)
        {
            _context = context;
            _carStateRepository = carStateRepository;
            _carTypeRepository = carTypeRepository;
            _clientTypeRepository = clientTypeRepository;
            _carHireRepository = carHireRepository;
            _carRepository = carRepository;
            _clientRepository = clientRepository;
            
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
