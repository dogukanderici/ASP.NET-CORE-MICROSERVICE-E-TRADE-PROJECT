using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;
using System.Linq.Expressions;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private IProductImageDal _productImageDal;
        private readonly IMapper _mapper;

        public ProductImageService(IProductImageDal productImageDal, IMapper mapper)
        {
            _productImageDal = productImageDal;
            _mapper = mapper;
        }

        public async Task CreateDataAsync(CreateProductImageDto createDto)
        {
            await _productImageDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _productImageDal.DeleteData(pi => pi.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllDataAsync()
        {
            var values = await _productImageDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImagesAsync(string id)
        {
            var productImageValues = await _productImageDal.GetDataAsync(p => p.ProductID == id);

            var productImageValuesFromDto = _mapper.Map<GetByIdProductImageDto>(productImageValues);

            return productImageValuesFromDto;
        }

        public async Task<GetByIdProductImageDto> GetDataAsync(string id)
        {
            var value = await _productImageDal.GetDataAsync(pi => pi.ProductImageID == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateProductImageDto updateDto)
        {
            await _productImageDal.UpdateData(pi => pi.ProductImageID == updateDto.ProductImageID, updateDto);
        }
    }
}
