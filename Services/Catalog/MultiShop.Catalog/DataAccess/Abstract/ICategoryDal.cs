using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface ICategoryDal : IRepositoryBase<Category, ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto, GetByIdCategoryDto>
    {
    }
}
