using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class NewsService : BaseService, INewsService
    {
        public NewsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> AddNewAsync(NewsDTO newsDTO)
        {
            News news = mapper.Map<News>(newsDTO);
            news.Date = DateTime.Now;
            return await unitOfWork.NewRepository.AddAsync(news);
        }

        public async Task DeleteNewAsync(int id) =>
            await unitOfWork.NewRepository.DeleteAsync(id);

        public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
        {
            IEnumerable<News> news = await unitOfWork.NewRepository.GetAllAsync();
            return mapper.Map<IEnumerable<NewsDTO>>(news);
        }

        public async Task<NewsDTO> GetNewByIdAsync(int Id) =>
            mapper.Map<NewsDTO>(await unitOfWork.NewRepository.GetAsync(Id));

        public async Task UpdateNewAsync(NewsDTO news) =>
            await unitOfWork.NewRepository.UpdateAsync(mapper.Map<News>(news));
    }
}