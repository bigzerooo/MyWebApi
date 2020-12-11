using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Parameters;
using DataAccessLayer.Helpers;

namespace BusinessLogicLayer.Services
{
    public class CarHireService : ICarHireService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;                   
        public CarHireService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> HireCarAsync(CarHireDTO carHire)
        {
            /* принимает CarId, Client Id и ExpectedEndDate
             * BeginDate ставит поточную, ExpectedPrice считает само,Returned - false
             * всё остальное - null*/

            var x = _mapper.Map<CarHireDTO, CarHire>(carHire);

            x.BeginDate = DateTime.Now;//Время заказа - поточное время
            var car = await _unitOfWork.carRepository.GetAsync(x.CarId);
            if (car == null)//нет машины
                return -1;

            var client = await _unitOfWork.clientRepository.GetAsync(x.ClientId);
            if (client == null)//нет клиента
                return -2;

            if (x.ExpectedEndDate < x.BeginDate)//неправильное время
                return -3;

            var timeGap = (x.ExpectedEndDate - x.BeginDate).TotalSeconds;//ожидаемое время проката

            x.ExpectedPrice = car.PricePerHour / 3600 * (decimal)timeGap;//ожидаемая цена проката

            x.Returned = false;//машина взята, но еще не вернулась

            if (x.ExpectedPrice <= 0)//на всякий случай если цена уйдёт в минус (по идее не должна)
                x.ExpectedPrice = 0;

            return await _unitOfWork.carHireRepository.AddAsync(x);            
        }
        public async Task<List<CarHireDTO>> GetUnreturnedCarHiresByClientIdAsync(int clientId)
        {
            var x = await _unitOfWork.carHireRepository.GetUnreturnedCarHiresByClientIdAsync(clientId);
            List<CarHireDTO> result = _mapper.Map<List<CarHireDTO>>(x);
            return result;
        }
        public async Task<List<CarHireDTO>> GetCarHiresByClientIdAsync(int clientId)
        {
            var x = await _unitOfWork.carHireRepository.GetCarHiresByClientIdAsync(clientId);
            List<CarHireDTO> result = _mapper.Map<List<CarHireDTO>>(x);
            return result;
        }
        public async Task<int> ReturnCarAsync(CarHireDTO carHireDTO)
        {
            /* принимает Id,CarStateId и EndDate(либо EndDate считает поточную)
             * считает Discount и Penalty, потом Price
             * Returned - true*/
            var carHire = await _unitOfWork.carHireRepository.GetAsync(carHireDTO.Id);
            var car = await _unitOfWork.carRepository.GetAsync(carHire.CarId);
            var client = await _unitOfWork.clientRepository.GetAsync(carHire.ClientId);

            //carHire.EndDate = carHireDTO.EndDate; если принимает
            var EndDate = DateTime.Now;            

            var timeGap = (EndDate - carHire.BeginDate).TotalSeconds;//Настоящий срок
            carHire.EndDate = EndDate;

            var price = car.PricePerHour / 3600 * (decimal)timeGap;//настоящая цена

            if(client.ClientTypeId != 2 && await _unitOfWork.carHireRepository.GetReturnedCarCountByIdAsync(client.Id)>5)//если клиент подходит, то стаёт постоянным
            {
                client.ClientTypeId = 2;
                await _unitOfWork.clientRepository.UpdateAsync(client);
            }                

            if (client.ClientTypeId == 2)//если клиент постоянный, получает скидку 1%
            {
                var discount = price * 0.01M;
                carHire.Discount = discount;
                price -= discount;
            }

            carHire.CarStateId = carHireDTO.CarStateId;
            if (carHireDTO.CarStateId==2)//если состояние машины плохое, штраф - 30% от цены
            {
                var penalty = price * 0.3M;
                carHire.Penalty = penalty;
                price += penalty;
            }
            if (carHire.Penalty == null)
            {
                carHire.Penalty = 0;
            }
            if (carHire.Discount == null)
            {
                carHire.Discount = 0;
            }

            carHire.Price = price;
            carHire.Returned = true;
            await _unitOfWork.carHireRepository.UpdateAsync(carHire);
            return 1;

        }
        

        public async Task DeleteCarHireAsync(int Id)
        {
            await _unitOfWork.carHireRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CarHireDTO>> GetAllCarHiresAsync()
        {            
            var x = await _unitOfWork.carHireRepository.GetAllAsync();

            List<CarHireDTO> result = new List<CarHireDTO>();
            foreach (var element in x)            
                result.Add(_mapper.Map<CarHire, CarHireDTO>(element));

            return result;
        }

        public async Task<CarHireDTO> GetCarHireByIdAsync(int Id)
        {
            var x = await _unitOfWork.carHireRepository.GetAsync(Id);
            return _mapper.Map<CarHire, CarHireDTO>(x);
        }

        public async Task UpdateCarHireAsync(CarHireDTO carHire)
        {
            var x = _mapper.Map<CarHireDTO, CarHire>(carHire);
            await _unitOfWork.carHireRepository.UpdateAsync(x);
        }
        public async Task<CarHire> GetCarHireDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.carHireRepository.GetCarHireDetailsByIdAsync(Id);
        }
        public async Task<List<CarHire>> GetCarHireDetailsAsync()
        {
            return await _unitOfWork.carHireRepository.GetCarHireDetailsAsync();
        }
        public async Task<PagedList<CarHireDTO>> GetCarHirePages(CarHireParameters parameters)
        {
            var x = await _unitOfWork.carHireRepository.GetAllPagesAsync(parameters);
            var result = _mapper.Map<PagedList<CarHireDTO>>(x);
            return result;
        }
    }
}
