using DataAccessLayer.DBContext;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.EntityInterfaces;
using DataAccessLayer.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity,TId> : IGenericRepository<TEntity,TId> where TEntity : class,IEntity<TId>
    {
        protected MyDBContext _myDBContext;
        protected DbSet<TEntity> _dbSet;
        public GenericRepository(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
            _dbSet = _myDBContext.Set<TEntity>();
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _myDBContext.SaveChangesAsync();
            try
            {
                return Int32.Parse(entity.Id.ToString());
            }
            catch
            {
                return 0;
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _myDBContext.Entry(entity).State = EntityState.Modified;
            await _myDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            TEntity x =await _dbSet.FindAsync(id);
            _dbSet.Remove(x);
            await _myDBContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(TId Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);            
        }
    }
}
