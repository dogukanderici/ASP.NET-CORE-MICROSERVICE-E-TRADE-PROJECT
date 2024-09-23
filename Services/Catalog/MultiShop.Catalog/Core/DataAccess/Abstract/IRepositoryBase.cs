using System.Linq.Expressions;

namespace MultiShop.Catalog.Core.DataAccess.Abstract
{
    public interface IRepositoryBase<T, Tresult, Tcreate, Tupdate, Tget>
        where T : class, new()
        where Tresult : class, new()
        where Tcreate : class, new()
        where Tupdate : class, new()
        where Tget : class, new()
    {
        Task<List<Tresult>> GetAllDataAsync(Expression<Func<T, bool>> filter = null);
        Task<Tget> GetDataAsync(Expression<Func<T, bool>> filter = null);

        Task CreateData(Tcreate entity);
        Task UpdateData(Expression<Func<T, bool>> filter, Tupdate entity);
        Task DeleteData(Expression<Func<T, bool>> filter = null);

        long GetCount();
    }
}
