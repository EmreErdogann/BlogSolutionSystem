using BlogSolutionSystem.Data.Interfaces;
using BlogSolutionSystem.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogSolutionSystem.Data.Implementaions
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _dbContext;
        public EfGenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Any(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return (predicate == null ? _dbContext.Set<T>().Count(predicate) : _dbContext.Set<T>().Count(predicate));
        }

        public T Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return entity;
        }

        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProptery in includeProperties)
                {
                    query = query.Include(includeProptery);
                }
            }
            return query.SingleOrDefault();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProptery in includeProperties)
                {
                    query = query.Include(includeProptery);
                }
            }
            return query.ToList();
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
