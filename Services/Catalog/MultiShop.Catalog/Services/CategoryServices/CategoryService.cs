using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;
using System.Linq.Expressions;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task CreateDataAsync(CreateCategoryDto createDto)
        {
            await _categoryDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _categoryDal.DeleteData(c => c.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllDataAsync()
        {
            var values = await _categoryDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdCategoryDto> GetDataAsync(string id)
        {
            var value = await _categoryDal.GetDataAsync(c => c.CategoryID == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateCategoryDto updateDto)
        {
            await _categoryDal.UpdateData(c => c.CategoryID == updateDto.CategoryID, updateDto);
        }
    }
}
