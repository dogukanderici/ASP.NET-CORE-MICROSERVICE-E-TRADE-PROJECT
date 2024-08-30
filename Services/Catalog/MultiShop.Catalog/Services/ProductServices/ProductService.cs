using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;
        private ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public ProductService(IProductDal productDal, ICategoryDal categoryDal, IMapper mapper)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        public Task<List<ResultProductDto>> GetAllDataAsync()
        {
            var values = _productDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdProductDto> GetDataAsync(string id)
        {
            var value = await _productDal.GetDataAsync(p => p.ProductID == id);

            return value;
        }

        public async Task CreateDataAsync(CreateProductDto createDto)
        {
            await _productDal.CreateData(createDto);
        }

        public async Task UpdateDataAsync(UpdateProductDto updateDto)
        {
            await _productDal.UpdateData(p => p.ProductID == updateDto.ProductID, updateDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _productDal.DeleteData(p => p.ProductID == id);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var productValues = await _productDal.GetAllDataAsync();

            var productValuesFromDto = _mapper.Map<List<ResultProductWithCategoryDto>>(productValues);

            foreach (var item in productValuesFromDto)
            {
                var categoryResult = await _categoryDal.GetDataAsync(c => c.CategoryID == item.CategoryID);

                item.Category = _mapper.Map<ResultCategoryDto>(categoryResult);
            }

            return productValuesFromDto;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id)
        {
            var productValues = await _productDal.GetAllDataAsync(p => p.CategoryID == id);

            var productValuesFromDto = _mapper.Map<List<ResultProductWithCategoryDto>>(productValues);

            foreach (var item in productValuesFromDto)
            {
                var categoryResult = await _categoryDal.GetDataAsync(c => c.CategoryID == item.CategoryID);

                item.Category = _mapper.Map<ResultCategoryDto>(categoryResult);
            }

            return productValuesFromDto;
        }
    }
}
