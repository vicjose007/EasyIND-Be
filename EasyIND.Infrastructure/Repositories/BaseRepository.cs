using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EasyIND.Domain.BaseModel.BaseEntity;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.UnitOfWorks;

namespace EasyIND.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public readonly IUnitOfWork<IEasyINDDbContext> _uow;
        public readonly IEasyINDDbContext _context;
        public readonly DbSet<T> _dbSet;

        public BaseRepository(IUnitOfWork<IEasyINDDbContext> uow)
        {
            _uow = uow;
            _context = _uow.context;
            _dbSet = _context.GetDbSet<T>();
        }

        public T First(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }
            if (predicate != null)
                return list.FirstOrDefault(predicate);

            return list.FirstOrDefault();
        }
        public T FirstAsNoTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsNoTracking().AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }

            if (predicate != null)
                return list.FirstOrDefault(predicate);

            return list.FirstOrDefault();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }

            if (predicate is null)
                return list;

            return list.Where(predicate);
        }
        public virtual T GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }

            return list.FirstOrDefault(x => x.Id == id);
        }
        public virtual T GetByIdAsNoTracking(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsNoTracking().AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }

            return list.FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Add(params T[] entities)
        {
            _dbSet.AddRange(entities);
        }
        public void Add(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Delete(int id)
        {
            T entity = GetById(id);
            _dbSet.Remove(entity);
        }
        public void Delete(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Update(params T[] entities)
        {
            foreach (T entity in entities)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        public virtual void Update(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public virtual void Detached(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }

            if (predicate is null)
                return list;

            return list.Where(predicate);
        }
        public IQueryable<T> WhereAsNoTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsQueryable().AsNoTracking();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }

            if (predicate is null)
                return list;

            return list.Where(predicate);
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public bool Any(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> list = _dbSet.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                list = list.Include(includeProperty);
            }

            if (predicate is null)
                return false;

            return list.Any(predicate);
        }
    }
}
