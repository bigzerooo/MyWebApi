using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LogsService : BaseService, ILogsService
    {
        public LogsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> AddLogAsync(LogDTO logDTO)
        {
            Log log = mapper.Map<Log>(logDTO);
            return await unitOfWork.LogsRepository.AddAsync(log);
        }

        public async Task<LogDTO> GetLogByIdAsync(int id)
        {
            Log log = await unitOfWork.LogsRepository.GetAsync(id);
            return mapper.Map<LogDTO>(log);
        }


        public async Task<IEnumerable<LogDTO>> GetAllLogsAsync()
        {
            IEnumerable<Log> logs = await unitOfWork.LogsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<LogDTO>>(logs);
        }

        //implement GetLogsByControllerName and GetLogsByActionName
    }
}
