using Microsoft.VisualBasic;

namespace MultiShop.WebUI.Services.CatalogServices.GenericServices
{
    public interface IGenericService<TResult, TCreate, TUpdate>
        where TResult : class, new()
        where TCreate : class, new()
        where TUpdate : class, new()
    {
        Task<List<TResult>> GetAllDataAsync();
        Task<HttpResponseMessage> CreateDataAsync(TCreate createDto);
        Task<HttpResponseMessage> UpdateDataAsync(TUpdate updateDto);
        Task<HttpResponseMessage> DeleteDataAsync(string id);
        Task<TUpdate> GetDataAsync(string id);
    }
}
