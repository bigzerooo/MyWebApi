using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class LogsService : BaseService, ILogsService
    {
        public LogsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> AddLogAsync(LogDTO logDTO)
        {
            Log log = _mapper.Map<LogDTO, Log>(logDTO);
            return await _unitOfWork.LogsRepository.AddAsync(log);
        }

        public async Task<LogDTO> GetLogByIdAsync(int id)
        {
            Log log = await _unitOfWork.LogsRepository.GetAsync(id);
            return _mapper.Map<LogDTO>(log);
        }


        public async Task<IEnumerable<LogDTO>> GetAllLogsAsync()
        {
            IEnumerable<Log> logs = await _unitOfWork.LogsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Log>, IEnumerable<LogDTO>>(logs);
        }
    }
}
