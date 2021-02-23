using AutoMapper;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
