using DataAccessLayer.DbContext;
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
    public class SQLGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected SQLDbContext _myDBContext;
        protected DbSet<TEntity> _dbSet;
        public SQLGenericRepository(SQLDbContext myDBContext)
        {
            _myDBContext = myDBContext;
            _dbSet = _myDBContext.Set<TEntity>();
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _myDBContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _myDBContext.Entry(entity).State = EntityState.Modified;
            await _myDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            TEntity x = await _dbSet.FindAsync(id);
            _dbSet.Remove(x);
            await _myDBContext.SaveChangesAsync();
        }
        public async Task<TEntity> GetAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
        public IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> expression) =>
            _dbSet.Where(expression);
    }
}