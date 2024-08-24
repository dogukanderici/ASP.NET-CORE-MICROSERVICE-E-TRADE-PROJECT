using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService : IGenericService<ProductImage, ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto, GetByIdProductImageDto>
    {
    }
}
