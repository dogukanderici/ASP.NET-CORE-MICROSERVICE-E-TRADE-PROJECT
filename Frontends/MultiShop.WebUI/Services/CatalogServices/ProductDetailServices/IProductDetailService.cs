using MultiShop.Dtos.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService : IGenericService<ResultProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto>
    {
        Task<GetByIdProductDetailDto> GetProductDetailsWithProductIdAsync(string id);
    }
}
