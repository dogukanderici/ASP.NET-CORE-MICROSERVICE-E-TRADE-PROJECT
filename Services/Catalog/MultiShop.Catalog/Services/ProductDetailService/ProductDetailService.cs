using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Catalog.Services.ProductDetailService
{
    public class ProductDetailService : IProductDetailService
    {
        private IProductDetailDal _productDetailDal;

        public ProductDetailService(IProductDetailDal productDetailDal)
        {
            _productDetailDal = productDetailDal;
        }

        public async Task CreateDataAsync(CreateProductDetailDto createDto)
        {
            await _productDetailDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _productDetailDal.DeleteData(pd => pd.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllDataAsync()
        {
            var values = await _productDetailDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdProductDetailDto> GetDataAsync(string id)
        {
            var value = await _productDetailDal.GetDataAsync(pd => pd.ProductDetailID == id);

            return value;
        }

        public async Task<GetByIdProductDetailDto> GetProductDetailsWithProductIdAsync(string id)
        {
            var value = await _productDetailDal.GetDataAsync(pd => pd.ProductID == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateProductDetailDto updateDto)
        {
            await _productDetailDal.UpdateData(pd => pd.ProductDetailID == updateDto.ProductDetailID, updateDto);
        }
    }
}
