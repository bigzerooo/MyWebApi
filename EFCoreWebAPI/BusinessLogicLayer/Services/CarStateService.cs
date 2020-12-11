using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarStateService : ICarStateService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarStateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddCarStateAsync(CarStateDTO carState) =>
            await _unitOfWork.CarStateRepository.AddAsync(_mapper.Map<CarStateDTO, CarState>(carState));
        public async Task DeleteCarStateAsync(int id) =>
            await _unitOfWork.CarStateRepository.DeleteAsync(id);
        public async Task<IEnumerable<CarStateDTO>> GetAllCarStatesAsync()
        {
            IEnumerable<CarState> x = await _unitOfWork.CarStateRepository.GetAllAsync();
            List<CarStateDTO> result = new List<CarStateDTO>();
            foreach (var element in x)
                result.Add(_mapper.Map<CarState, CarStateDTO>(element));
            return result;
        }
        public async Task<string> GetCarStateByIdAsync(int Id) =>
            await _unitOfWork.CarStateRepository.GetCarStateById(Id);
        public async Task UpdateCarStateAsync(CarStateDTO carState) =>
            await _unitOfWork.CarStateRepository.UpdateAsync(_mapper.Map<CarStateDTO, CarState>(carState));
        public async Task<CarState> GetCarStateDetailsByIdAsync(int Id) =>
            await _unitOfWork.CarStateRepository.GetCarStateDetailsByIdAsync(Id);
        public async Task<List<CarState>> GetCarStateDetailsAsync() =>
            await _unitOfWork.CarStateRepository.GetCarStateDetailsAsync();
    }
}