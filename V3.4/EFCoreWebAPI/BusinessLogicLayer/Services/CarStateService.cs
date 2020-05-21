using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarStateService : ICarStateService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CarStateService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddCarStateAsync(CarStateDTO carState)
        {
            var x = _mapper.Map<CarStateDTO, CarState>(carState);
            return await _unitOfWork.carStateRepository.AddAsync(x);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteCarStateAsync(int id)
        {
            await _unitOfWork.carStateRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarStateDTO>> GetAllCarStatesAsync()
        {
            var x = await _unitOfWork.carStateRepository.GetAllAsync();
            List<CarStateDTO> result = new List<CarStateDTO>();
            foreach (var element in x)
                result.Add(_mapper.Map<CarState,CarStateDTO>(element));
            return result;
        }

        public async Task<string> GetCarStateByIdAsync(int Id)
        {
            return await _unitOfWork.carStateRepository.GetCarStateById(Id);            
        }

        public async Task UpdateCarStateAsync(CarStateDTO carState)
        {
            var x = _mapper.Map<CarStateDTO, CarState>(carState);
            await _unitOfWork.carStateRepository.UpdateAsync(x);
        }

        public async Task<CarState> GetCarStateDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.carStateRepository.GetCarStateDetailsByIdAsync(Id);
        }
        public async Task<List<CarState>> GetCarStateDetailsAsync()
        {
            return await _unitOfWork.carStateRepository.GetCarStateDetailsAsync();
        }
    }
}
