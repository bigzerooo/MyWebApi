using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.UnitOfWork;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarService : BaseService, ICarService
    {
        public CarService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> GetCarsCountAsync(CarParameters parameters)
        {
            if (parameters.Brand != null)
                parameters.Brand = parameters.Brand.Trim().ToLower(); //выглядит ненужным здесь
            return await unitOfWork.CarRepository.GetCarCountAsync(parameters);
        }

        public async Task<int> AddCarAsync(CarDTO carDTO)
        {
            var car = mapper.Map<Car>(carDTO);
            return await unitOfWork.CarRepository.AddAsync(car);
        }


        public async Task DeleteCarAsync(int id) =>
            await unitOfWork.CarRepository.DeleteAsync(id);

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            var cars = await unitOfWork.CarRepository.GetAllAsync();
            return mapper.Map<List<CarDTO>>(cars);
        }


        public async Task<CarDTO> GetCarByIdAsync(int id)
        {
            var car = await unitOfWork.CarRepository.GetAsync(id);
            return mapper.Map<CarDTO>(car);
        }


        public async Task UpdateCarAsync(CarDTO carDTO)
        {
            var car = mapper.Map<Car>(carDTO);
            await unitOfWork.CarRepository.UpdateAsync(car);
        }

        //public async Task<Car> GetCarDetailsByIdAsync(int Id) =>
        //    await unitOfWork.CarRepository.GetCarDetailsByIdAsync(Id);

        //public async Task<List<Car>> GetCarDetailsAsync() =>
        //    await unitOfWork.CarRepository.GetCarDetailsAsync();

        public async Task<PagedList<CarDTO>> GetCarPagesFilteredAsync(CarParameters parameters)
        {
            var carPages = await unitOfWork.CarRepository.GetAllPagesFilteredAsync(parameters);
            return mapper.Map<PagedList<CarDTO>>(carPages);
        }
    }
}