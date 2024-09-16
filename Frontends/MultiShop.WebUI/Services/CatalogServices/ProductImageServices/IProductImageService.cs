using MultiShop.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService : IGenericService<ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto>
    {
        Task<GetByIdProductImageDto> GetByProductIdProductImagesAsync(string id);
    }
}
