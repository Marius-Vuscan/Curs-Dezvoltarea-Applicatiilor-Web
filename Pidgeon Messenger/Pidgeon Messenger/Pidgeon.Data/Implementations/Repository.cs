using Microsoft.EntityFrameworkCore;
using Pidgeon.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Pidgeon.Data.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        protected Repository(DbContext context)
        {
            this.context = context;
        }

        public DbContext DbContext
        {
            get { return context; }
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll(params string[] includes)
        {
            IQueryable<TEntity> result = context.Set<TEntity>();

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    result = result.Include(include);
                }
            }

            return result.ToList();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
