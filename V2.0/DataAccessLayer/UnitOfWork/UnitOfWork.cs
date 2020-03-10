using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IRepositories;
namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ICarHireRepository _carHireRepository;
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IJoinedRepository _joinedRepository;
        public UnitOfWork(ICarHireRepository carHireRepository,
            ICarRepository carRepository,
            IClientRepository clientRepository,
            IJoinedRepository joinedRepository)
        {
            _carHireRepository = carHireRepository;
            _carRepository = carRepository;
            _clientRepository = clientRepository;
            _joinedRepository = joinedRepository;
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
        
        public IJoinedRepository joinedRepository
        {
            get
            {
                return _joinedRepository;
            }
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
