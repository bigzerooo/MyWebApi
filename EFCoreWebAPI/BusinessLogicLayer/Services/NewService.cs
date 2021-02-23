using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class NewService : BaseService, INewService
    {
        public NewService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> AddNewAsync(NewDTO newsDTO)
        {
            New news = _mapper.Map<NewDTO, New>(newsDTO);
            news.Date = DateTime.Now;
            return await _unitOfWork.NewRepository.AddAsync(news);
        }

        public async Task DeleteNewAsync(int id) =>
            await _unitOfWork.NewRepository.DeleteAsync(id);

        public async Task<IEnumerable<NewDTO>> GetAllNewsAsync()
        {
            IEnumerable<New> news = await _unitOfWork.NewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<NewDTO>>(news);
        }

        public async Task<NewDTO> GetNewByIdAsync(int Id) =>
            _mapper.Map<New, NewDTO>(await _unitOfWork.NewRepository.GetAsync(Id));

        public async Task UpdateNewAsync(NewDTO news) =>
            await _unitOfWork.NewRepository.UpdateAsync(_mapper.Map<NewDTO, New>(news));
    }
}