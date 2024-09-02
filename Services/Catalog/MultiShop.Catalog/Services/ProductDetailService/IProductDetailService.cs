using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.ProductDetailService
{
    public interface IProductDetailService : IGenericService<ProductDetail, ResultProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto, GetByIdProductDetailDto>
    {
        Task<GetByIdProductDetailDto> GetProductDetailsWithProductIdAsync(string id);
    }
}
