using MultiShop.Catalog.Dtos.CategoryDtos;
using System.Linq.Expressions;

namespace MultiShop.Catalog.Services.GenericServices
{
    public interface IGenericService<T,TResult, TCreate, TUpdate, TGet>
        where T : class, new()
        where TResult : class, new()
        where TCreate : class, new()
        where TUpdate : class, new()
        where TGet : class, new()

    {
        Task<List<TResult>> GetAllDataAsync();
        Task CreateDataAsync(TCreate createDto);
        Task UpdateDataAsync(TUpdate updateDto);
        Task DeleteDataAsync(string id);
        Task<TGet> GetDataAsync(string id);
    }
}
