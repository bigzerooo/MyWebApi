using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.DTO.Identity;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;

namespace BusinessLogicLayer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarHire, CarHireDTO>()
                .ReverseMap();

            CreateMap<CarType, CarTypeDTO>()
                .ReverseMap();

            CreateMap<CarState, CarStateDTO>()
                .ReverseMap();

            CreateMap<Car, CarDTO>()
                .ReverseMap();

            CreateMap<Client, ClientDTO>()
                .ReverseMap();

            CreateMap<ClientType, ClientTypeDTO>()
                .ReverseMap();

            CreateMap<Role, RoleDTO>()
                .ReverseMap();

            CreateMap<News, NewsDTO>()
                .ReverseMap();

            CreateMap<Log, LogDTO>()
                .ReverseMap();
        }
    }
}