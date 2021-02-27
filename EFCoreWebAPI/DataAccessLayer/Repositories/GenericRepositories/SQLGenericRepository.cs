using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Interfaces.Entities;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.GenericRepositories
{
    public abstract class SQLGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected SQLDbContext _myDBContext;
        protected DbSet<TEntity> _dbSet;

        public SQLGenericRepository(SQLDbContext myDBContext)
        {
            _myDBContext = myDBContext;
            _dbSet = _myDBContext.Set<TEntity>();
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _myDBContext.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _myDBContext.Entry(entity).State = EntityState.Modified;
            await _myDBContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _myDBContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
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