using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarHireService : BaseService, ICarHireService
    {
        public CarHireService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> HireCarAsync(CarHireDTO carHire)
        {
            CarHire x = _mapper.Map<CarHire>(carHire);

            x.BeginDate = DateTime.Now;
            Car car = await _unitOfWork.CarRepository.GetAsync(x.CarId);
            if (car == null)
                return -1;

            Client client = await _unitOfWork.ClientRepository.GetAsync(x.ClientId);
            if (client == null)
                return -2;

            if (x.ExpectedEndDate < x.BeginDate)
                return -3;

            double timeGap = (x.ExpectedEndDate - x.BeginDate).TotalSeconds;

            x.ExpectedPrice = car.PricePerHour / 3600 * Convert.ToDecimal(timeGap);

            x.Returned = false;

            if (x.ExpectedPrice <= 0)
                x.ExpectedPrice = 0;

            return await _unitOfWork.CarHireRepository.AddAsync(x);
        }
        public async Task<List<CarHireDTO>> GetUnreturnedCarHiresByClientIdAsync(int clientId)
        {
            List<CarHire> x = await _unitOfWork.CarHireRepository.GetUnreturnedCarHiresByClientIdAsync(clientId);
            return _mapper.Map<List<CarHireDTO>>(x);
        }
        public async Task<List<CarHireDTO>> GetCarHiresByClientIdAsync(int clientId)
        {
            List<CarHire> x = await _unitOfWork.CarHireRepository.GetCarHiresByClientIdAsync(clientId);
            return _mapper.Map<List<CarHireDTO>>(x);
        }
        public async Task<int> ReturnCarAsync(CarHireDTO carHireDTO)
        {
            CarHire carHire = await _unitOfWork.CarHireRepository.GetAsync(carHireDTO.Id);
            Car car = await _unitOfWork.CarRepository.GetAsync(carHire.CarId);
            Client client = await _unitOfWork.ClientRepository.GetAsync(carHire.ClientId);

            DateTime EndDate = DateTime.Now;

            double timeGap = (EndDate - carHire.BeginDate).TotalSeconds;
            carHire.EndDate = EndDate;

            decimal price = car.PricePerHour / 3600 * Convert.ToDecimal(timeGap);

            if (client.ClientTypeId != 2 && await _unitOfWork.CarHireRepository.GetReturnedCarCountByIdAsync(client.Id) > 5)
            {
                client.ClientTypeId = 2;
                await _unitOfWork.ClientRepository.UpdateAsync(client);
            }

            if (client.ClientTypeId == 2)
            {
                decimal discount = price * 0.01M;
                carHire.Discount = discount;
                price -= discount;
            }

            carHire.CarStateId = carHireDTO.CarStateId;
            if (carHireDTO.CarStateId == 2)
            {
                decimal penalty = price * 0.3M;
                carHire.Penalty = penalty;
                price += penalty;
            }
            if (carHire.Penalty == null)
                carHire.Penalty = 0;
            if (carHire.Discount == null)
                carHire.Discount = 0;

            carHire.Price = price;
            carHire.Returned = true;
            await _unitOfWork.CarHireRepository.UpdateAsync(carHire);
            return 1;
        }
        public async Task DeleteCarHireAsync(int Id) =>
            await _unitOfWork.CarHireRepository.DeleteAsync(Id);
        public async Task<IEnumerable<CarHireDTO>> GetAllCarHiresAsync()
        {
            IEnumerable<CarHire> carHires = await _unitOfWork.CarHireRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarHireDTO>>(carHires);
        }
        public async Task<CarHireDTO> GetCarHireByIdAsync(int Id)
        {
            var x = await _unitOfWork.CarHireRepository.GetAsync(Id);
            return _mapper.Map<CarHireDTO>(x);
        }

        public async Task UpdateCarHireAsync(CarHireDTO carHire)
        {
            var x = _mapper.Map<CarHire>(carHire);
            await _unitOfWork.CarHireRepository.UpdateAsync(x);
        }
        public async Task<CarHire> GetCarHireDetailsByIdAsync(int Id) =>
            await _unitOfWork.CarHireRepository.GetCarHireDetailsByIdAsync(Id);
        public async Task<List<CarHire>> GetCarHireDetailsAsync() =>
            await _unitOfWork.CarHireRepository.GetCarHireDetailsAsync();
        public async Task<PagedList<CarHireDTO>> GetCarHirePages(CarHireParameters parameters)
        {
            PagedList<CarHire> x = await _unitOfWork.CarHireRepository.GetAllPagesAsync(parameters);
            return _mapper.Map<PagedList<CarHireDTO>>(x);
        }
    }
}