using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IProductDetailDal : IRepositoryBase<ProductDetail, ResultProductDetailDto, CreateProductDetailDto, UpdateProductDetailDto, GetByIdProductDetailDto>
    {
    }
}
