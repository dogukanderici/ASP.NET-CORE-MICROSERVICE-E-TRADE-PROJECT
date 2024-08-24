using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IProductImageDal : IRepositoryBase<ProductImage, ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto, GetByIdProductImageDto>
    {
    }
}
