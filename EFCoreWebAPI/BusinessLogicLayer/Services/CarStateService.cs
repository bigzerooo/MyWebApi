using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarStateService : BaseService, ICarStateService
    {
        public CarStateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> AddCarStateAsync(CarStateDTO carStateDTO)
        {
            var carState = mapper.Map<CarState>(carStateDTO);
            return await unitOfWork.CarStateRepository.AddAsync(carState);
        }

        public async Task DeleteCarStateAsync(int id) =>
            await unitOfWork.CarStateRepository.DeleteAsync(id);

        public async Task<IEnumerable<CarStateDTO>> GetAllCarStatesAsync()
        {
            var carStates = await unitOfWork.CarStateRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CarStateDTO>>(carStates);
        }

        public async Task<string> GetCarStateByIdAsync(int id) =>
            await unitOfWork.CarStateRepository.GetCarStateStringById(id);

        public async Task UpdateCarStateAsync(CarStateDTO carStateDTO)
        {
            var carState = mapper.Map<CarState>(carStateDTO);
            await unitOfWork.CarStateRepository.UpdateAsync(carState);
        }

        //public async Task<CarState> GetCarStateDetailsByIdAsync(int id) =>
        //    await unitOfWork.CarStateRepository.GetCarStateDetailsByIdAsync(id);

        //public async Task<List<CarState>> GetCarStateDetailsAsync() =>
        //    await unitOfWork.CarStateRepository.GetCarStateDetailsAsync();
    }
}