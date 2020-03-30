using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarHireRepository: IGenericRepository<CarHire,int>
    {
        public Task<CarHire> GetCarHireDetailsByIdAsync(int Id);
        public Task<List<CarHire>> GetCarHireDetailsAsync();
    }
}
