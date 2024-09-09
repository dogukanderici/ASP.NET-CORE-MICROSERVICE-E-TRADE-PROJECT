using Microsoft.VisualBasic;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService : IGenericService<ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
    }
}
