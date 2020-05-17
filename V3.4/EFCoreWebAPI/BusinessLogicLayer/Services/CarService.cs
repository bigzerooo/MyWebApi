using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarService : ICarService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> GetCarCountAsync(CarParameters parameters)
        {
            if(parameters.Brand!=null)
                parameters.Brand = parameters.Brand.Trim().ToLower();
            return await _unitOfWork.carRepository.GetCarCountAsync(parameters);
        }
        public async Task<int> AddCarAsync(CarDTO car)
        {
            var x = _mapper.Map<CarDTO, Car>(car);
            return await _unitOfWork.carRepository.AddAsync(x);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteCarAsync(int id)
        {
            await _unitOfWork.carRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            var x = await _unitOfWork.carRepository.GetAllAsync();
            List<CarDTO> result = _mapper.Map<List<CarDTO>>(x);//надо проверить
            //List<CarDTO> result = new List<CarDTO>();
            //foreach (var element in x)
            //    result.Add(_mapper.Map<Car, CarDTO>(element));
            return result;                                
        }

        public async Task<CarDTO> GetCarByIdAsync(int Id)
        {
            var x = await _unitOfWork.carRepository.GetAsync(Id);
            return _mapper.Map<Car, CarDTO>(x);
        }

        public async Task UpdateCarAsync(CarDTO car)
        {
            var x = _mapper.Map<CarDTO, Car>(car);
            await _unitOfWork.carRepository.UpdateAsync(x);
        }
        public async Task<Car> GetCarDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.carRepository.GetCarDetailsByIdAsync(Id);
        }
        public async Task<List<Car>> GetCarDetailsAsync()
        {
            return await _unitOfWork.carRepository.GetCarDetailsAsync();
        }
        public async Task<PagedList<CarDTO>> GetCarPagesFilteredAsync(CarParameters parameters)
        {
            var x = await _unitOfWork.carRepository.GetAllPagesFilteredAsync(parameters);
            var result = _mapper.Map<PagedList<CarDTO>>(x);            
            return result;
        }
    }
}
