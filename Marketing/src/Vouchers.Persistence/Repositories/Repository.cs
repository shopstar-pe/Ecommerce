using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Paging;
using Vouchers.Domain.Repositories;
using Vouchers.Persistence.Extensions;

namespace Vouchers.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext Db;
        protected DbSet<TEntity> DbSet;
        IMediator _mediator;

        public Repository(DbContext context, IMediator mediator)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
            _mediator = mediator;
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual async Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
            }
            else
            {
                return await DbSet.FirstOrDefaultAsync(predicate);
            }

        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false)
        {
            if (asNoTracking)
            {
                return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
            }
            else
            {
                return await DbSet.Where(predicate).ToListAsync();
            }

        }

        public async Task<int> SaveChanges()
        {
            var result = await Db.SaveChangesAsync();

            var domainEntities = this.Db.ChangeTracker.Entries<BaseEntity>()
               .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);

            return result;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public PagedResult<TEntity> FindPaged(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Func<TEntity, object> order, string sortType)
        {
            var query = DbSet.AsNoTracking().Where(predicate);
            return query.GetPaged<TEntity>(page, pageSize, order, sortType);
        }

        public async Task<List<TEntity>> FindAll()
        {
            return await DbSet.ToListAsync();
        }

    }
}
