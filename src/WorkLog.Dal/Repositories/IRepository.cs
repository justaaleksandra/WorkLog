using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkLog.Dal.Entities;

namespace WorkLog.Dal.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> Query { get; }
        Task<Guid> Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity> Find(Guid id);
        Task<IList<TEntity>> Find();
        Task<int> SaveChanges();
    }
}
