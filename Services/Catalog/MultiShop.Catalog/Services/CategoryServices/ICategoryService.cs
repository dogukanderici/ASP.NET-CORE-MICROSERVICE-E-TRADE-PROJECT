using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService : IGenericService<Category, ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto>
    {
    }
}