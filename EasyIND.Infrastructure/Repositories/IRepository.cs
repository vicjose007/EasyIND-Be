using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Infrastructure.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> AsQueryable();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> WhereAsNoTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        bool Any(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);


        T FirstAsNoTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T First(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        T GetByIdAsNoTracking(int id, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);
        void Add(params T[] entities);
        void Add(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(int id);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);

        void Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);
        void Detached(T entity);
    }
}
