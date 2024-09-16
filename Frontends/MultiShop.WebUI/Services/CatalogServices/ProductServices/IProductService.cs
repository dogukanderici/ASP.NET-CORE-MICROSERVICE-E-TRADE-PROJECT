using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService : IGenericService<ResultProductDto, CreateProductDto, UpdateProductDto>
    {
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id);
    }
}
