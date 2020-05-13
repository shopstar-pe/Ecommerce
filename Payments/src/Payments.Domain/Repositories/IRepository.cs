using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Payments.Domain.Entities;
using Payments.Domain.Paging;

namespace Payments.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity id);
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false);
        Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false);
        Task<List<TEntity>> FindAll();
        PagedResult<TEntity> FindPaged(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Func<TEntity, object> order, string sortType);
        Task<int> SaveChanges();
    }
}
