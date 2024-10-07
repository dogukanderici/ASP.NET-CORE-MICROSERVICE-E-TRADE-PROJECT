using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Core.DataAccess.Abstract
{
    public interface IRepositoryBase<T>
        where T : class, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> includes = null);
        T GetByFilter(Expression<Func<T, bool>> filter, string includes = null);
        void AddData(T entity);
        void UpdateData(T entity);
        void DeleteData(int id);

    }
}
