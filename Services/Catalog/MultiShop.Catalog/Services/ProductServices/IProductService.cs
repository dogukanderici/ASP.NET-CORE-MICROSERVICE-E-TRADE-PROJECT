using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService : IGenericService<Product, ResultProductDto, CreateProductDto, UpdateProductDto, GetByIdProductDto>
    {
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id);
    }
}
