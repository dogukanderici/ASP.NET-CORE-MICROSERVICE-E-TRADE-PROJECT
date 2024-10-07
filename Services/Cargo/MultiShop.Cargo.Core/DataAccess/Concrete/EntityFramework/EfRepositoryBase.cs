using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Core.DataAccess.Concrete.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public void AddData(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void DeleteData(int id)
        {
            using (var context = new TContext())
            {
                var deletedData = context.Find<TEntity>(id);

                if (deletedData != null)
                {
                    var deletedEntity = context.Entry(deletedData);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> includes = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includes != null)
                {
                    query = query.Include(includes);
                }

                return query.ToList();
            }
        }

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> filter, string includes = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includes != null)
                {
                    query = query.Include(includes);
                }

                return query.FirstOrDefault();
            }
        }

        public void UpdateData(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
