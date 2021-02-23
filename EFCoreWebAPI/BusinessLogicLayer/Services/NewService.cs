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
            New news = mapper.Map<New>(newsDTO);
            news.Date = DateTime.Now;
            return await unitOfWork.NewRepository.AddAsync(news);
        }

        public async Task DeleteNewAsync(int id) =>
            await unitOfWork.NewRepository.DeleteAsync(id);

        public async Task<IEnumerable<NewDTO>> GetAllNewsAsync()
        {
            IEnumerable<New> news = await unitOfWork.NewRepository.GetAllAsync();
            return mapper.Map<IEnumerable<NewDTO>>(news);
        }

        public async Task<NewDTO> GetNewByIdAsync(int Id) =>
            mapper.Map<NewDTO>(await unitOfWork.NewRepository.GetAsync(Id));

        public async Task UpdateNewAsync(NewDTO news) =>
            await unitOfWork.NewRepository.UpdateAsync(mapper.Map<New>(news));
    }
}