using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkLog.Dal.Entities;

namespace WorkLog.Dal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly WorkLogContext _context;

        public Repository(WorkLogContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(TEntity entity)
        {
            await _context.AddAsync(entity);
            return entity.Id;
        }

        public IQueryable<TEntity> Query => _context.Set<TEntity>();

        public void Remove(TEntity entity) => _context.Remove(entity);

        public void Update(TEntity entity) => _context.Update(entity);
        public void UpdateAll(List<TEntity> entity) => _context.Update(entity);

        public async Task<TEntity> Find(Guid id) => await Query.FirstOrDefaultAsync(x =>  x.Id == id);

        public async Task<IList<TEntity>> Find() => await Query.ToListAsync();

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

    }
}
