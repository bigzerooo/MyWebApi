using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
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
            if (parameters.Brand != null)
                parameters.Brand = parameters.Brand.Trim().ToLower();
            return await _unitOfWork.CarRepository.GetCarCountAsync(parameters);
        }
        public async Task<int> AddCarAsync(CarDTO car) =>
            await _unitOfWork.CarRepository.AddAsync(_mapper.Map<CarDTO, Car>(car));
        public async Task DeleteCarAsync(int id) =>
            await _unitOfWork.CarRepository.DeleteAsync(id);
        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync() =>
            _mapper.Map<List<CarDTO>>(await _unitOfWork.CarRepository.GetAllAsync());
        public async Task<CarDTO> GetCarByIdAsync(int Id) =>
            _mapper.Map<Car, CarDTO>(await _unitOfWork.CarRepository.GetAsync(Id));
        public async Task UpdateCarAsync(CarDTO car) =>
            await _unitOfWork.CarRepository.UpdateAsync(_mapper.Map<CarDTO, Car>(car));
        public async Task<Car> GetCarDetailsByIdAsync(int Id) =>
            await _unitOfWork.CarRepository.GetCarDetailsByIdAsync(Id);
        public async Task<List<Car>> GetCarDetailsAsync() =>
            await _unitOfWork.CarRepository.GetCarDetailsAsync();
        public async Task<PagedList<CarDTO>> GetCarPagesFilteredAsync(CarParameters parameters) =>
            _mapper.Map<PagedList<CarDTO>>(await _unitOfWork.CarRepository.GetAllPagesFilteredAsync(parameters));
    }
}