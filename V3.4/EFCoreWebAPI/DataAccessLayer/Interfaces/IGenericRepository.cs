using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.EntityInterfaces;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IGenericRepository<TEntity,TId> where TEntity : IEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(TId Id);

        Task<int> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TId id);
        IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
    }
}
