using BlogSolutionSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BlogSolutionSystem.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IList<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T Add(T entity);
        T Delete(T entity);
        T Update(T entity);
        int Count(Expression<Func<T, bool>> predicate = null);
        bool Any(Expression<Func<T, bool>> predicate);

    }
}
