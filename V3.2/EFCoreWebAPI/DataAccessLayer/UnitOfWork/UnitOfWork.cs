using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICarStateRepository _carStateRepository;
        private readonly ICarTypeRepository _carTypeRepository;
        private readonly IClientTypeRepository _clientTypeRepository;
        private readonly ICarHireRepository _carHireRepository;
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;        
        public UnitOfWork(
            ICarStateRepository carStateRepository,
            ICarTypeRepository carTypeRepository,
            IClientTypeRepository clientTypeRepository,
            ICarHireRepository carHireRepository,
            ICarRepository carRepository,
            IClientRepository clientRepository)
        {
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
        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
