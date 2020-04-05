using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DTO;

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

        public async Task<int> AddCarHireAsync(CarHireDTO carHire)
        {
            var x = _mapper.Map<CarHireDTO, CarHire>(carHire);
            return await _unitOfWork.carHireRepository.AddAsync(x);
            //_sqlunitOfWork.Complete();
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
    }
}
