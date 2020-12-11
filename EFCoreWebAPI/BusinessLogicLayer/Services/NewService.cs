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
    public class NewService : INewService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddNewAsync(NewDTO news)
        {
            var x = _mapper.Map<NewDTO, New>(news);
            x.Date = DateTime.Now;
            return await _unitOfWork.newRepository.AddAsync(x);            
        }

        public async Task DeleteNewAsync(int id)
        {
            await _unitOfWork.newRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<NewDTO>> GetAllNewsAsync()
        {
            var x = await _unitOfWork.newRepository.GetAllAsync();
            List<NewDTO> result = new List<NewDTO>();
            foreach (var element in x)
                result.Add(_mapper.Map<New, NewDTO>(element));
            return result;
        }

        public async Task<NewDTO> GetNewByIdAsync(int Id)
        {
            var x = await _unitOfWork.newRepository.GetAsync(Id);
            return _mapper.Map<New, NewDTO>(x);
        }

        public async Task UpdateNewAsync(NewDTO news)
        {
            var x = _mapper.Map<NewDTO, New>(news);            
            await _unitOfWork.newRepository.UpdateAsync(x);
        }
    }
}
