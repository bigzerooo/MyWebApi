using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.UnitOfWork;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarHireService : BaseService, ICarHireService
    {
        public CarHireService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        //пересмотреть
        public async Task<int> HireTheCarAsync(CarHireDTO carHireDTO)
        {
            var carHire = mapper.Map<CarHire>(carHireDTO);

            carHire.BeginDate = DateTime.Now;
            var car = await unitOfWork.CarRepository.GetAsync(carHire.CarId);
            if (car == null)
                return -1; //переделать

            var client = await unitOfWork.ClientRepository.GetAsync(carHire.ClientId);
            if (client == null)
                return -2; //переделать

            if (carHire.ExpectedEndDate < carHire.BeginDate)
                return -3; //переделать

            var timeGap = (carHire.ExpectedEndDate - carHire.BeginDate).TotalSeconds;

            carHire.ExpectedPrice = car.PricePerHour / 3600 * Convert.ToDecimal(timeGap); //упростить/вынести в другой метод

            carHire.Returned = false;

            if (carHire.ExpectedPrice <= 0) //очень интересная проверка
                carHire.ExpectedPrice = 0;

            return await unitOfWork.CarHireRepository.AddAsync(carHire);
        }
        public async Task<List<CarHireDTO>> GetUnreturnedCarHiresByClientIdAsync(int clientId)
        {
            var carHires = await unitOfWork.CarHireRepository.GetUnreturnedCarHiresByClientIdAsync(clientId);
            return mapper.Map<List<CarHireDTO>>(carHires);
        }
        public async Task<List<CarHireDTO>> GetCarHiresByClientIdAsync(int clientId)
        {
            var carHires = await unitOfWork.CarHireRepository.GetReturnedCarHiresByClientIdAsync(clientId);
            return mapper.Map<List<CarHireDTO>>(carHires);
        }
        public async Task<int> ReturnTheCarAsync(CarHireDTO carHireDTO)
        {
            var carHire = await unitOfWork.CarHireRepository.GetAsync(carHireDTO.Id);
            var car = await unitOfWork.CarRepository.GetAsync(carHire.CarId);
            var client = await unitOfWork.ClientRepository.GetAsync(carHire.ClientId);

            var EndDate = DateTime.Now;

            var timeGap = (EndDate - carHire.BeginDate).TotalSeconds;
            carHire.EndDate = EndDate;

            var price = car.PricePerHour / 3600 * Convert.ToDecimal(timeGap); //аналогично с верхним пересмотреть

            if (client.ClientTypeId != 2 && await unitOfWork.CarHireRepository.GetReturnedCarCountByIdAsync(client.Id) > 5) //избавиться от хардкода
            {
                client.ClientTypeId = 2;
                await unitOfWork.ClientRepository.UpdateAsync(client);
            }

            if (client.ClientTypeId == 2) //избавиться от хардкода
            {
                var discount = price * 0.01M; //тут тоже
                carHire.Discount = discount;
                price -= discount;
            }

            carHire.CarStateId = carHireDTO.CarStateId; //избавиться от хардкода
            if (carHireDTO.CarStateId == 2)
            {
                var penalty = price * 0.3M; //тут тоже
                carHire.Penalty = penalty;
                price += penalty;
            }
            if (carHire.Penalty == null)
                carHire.Penalty = 0;
            if (carHire.Discount == null) //пересмотреть
                carHire.Discount = 0;

            carHire.Price = price;
            carHire.Returned = true;
            await unitOfWork.CarHireRepository.UpdateAsync(carHire);
            return 1;
        }

        public async Task DeleteCarHireAsync(int id) =>
            await unitOfWork.CarHireRepository.DeleteAsync(id);

        public async Task<IEnumerable<CarHireDTO>> GetAllCarHiresAsync()
        {
            var carHires = await unitOfWork.CarHireRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CarHireDTO>>(carHires);
        }

        public async Task<CarHireDTO> GetCarHireByIdAsync(int Id)
        {
            var carHire = await unitOfWork.CarHireRepository.GetAsync(Id);
            return mapper.Map<CarHireDTO>(carHire);
        }

        public async Task UpdateCarHireAsync(CarHireDTO carHireDTO)
        {
            var carHire = mapper.Map<CarHire>(carHireDTO);
            await unitOfWork.CarHireRepository.UpdateAsync(carHire);
        }

        //public async Task<CarHire> GetCarHireDetailsByIdAsync(int id) =>
        //    await unitOfWork.CarHireRepository.GetCarHireDetailsByIdAsync(id);

        //public async Task<List<CarHire>> GetCarHireDetailsAsync() =>
        //    await unitOfWork.CarHireRepository.GetCarHireDetailsAsync();

        public async Task<PagedList<CarHireDTO>> GetCarHirePages(CarHireParameters parameters)
        {
            var carHires = await unitOfWork.CarHireRepository.GetAllPagesAsync(parameters);
            return mapper.Map<PagedList<CarHireDTO>>(carHires);
        }
    }
}