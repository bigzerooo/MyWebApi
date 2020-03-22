using DataAccessLayer.DBContext;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public int Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _myDBContext.SaveChanges();
            return 1;

        }

        public void Update(TEntity entity)
        {
            _myDBContext.Entry(entity).State = EntityState.Modified;
            _myDBContext.SaveChanges();
        }

        public void Delete(TId id)
        {
            TEntity x = _dbSet.Find(id);
            _dbSet.Remove(x);
            _myDBContext.SaveChanges();
        }

        public TEntity Get(TId Id)
        {
            return _dbSet.Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
