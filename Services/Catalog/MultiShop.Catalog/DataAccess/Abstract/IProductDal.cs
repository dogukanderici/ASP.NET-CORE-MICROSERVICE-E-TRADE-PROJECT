using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IProductDal : IRepositoryBase<Product, ResultProductDto, CreateProductDto, UpdateProductDto, GetByIdProductDto>
    {
        Task<decimal> GetProductAvgPrice();
    }
}
