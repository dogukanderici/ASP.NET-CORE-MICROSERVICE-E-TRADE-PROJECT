using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        public async Task CreateAsync(TEntity entity)
        {
            using (var context = new OrderContext())
            {
                var addedEntity = context.Add(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new OrderContext())
            {
                var addedEntity = context.Add(entity);
                addedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new OrderContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                return await query.ToListAsync();
            }
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new OrderContext())
            {
                return await context.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            using (var context = new OrderContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new OrderContext())
            {
                var addedEntity = context.Add(entity);
                addedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
