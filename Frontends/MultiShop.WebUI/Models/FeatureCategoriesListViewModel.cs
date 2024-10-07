using MultiShop.Dtos.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Models
{
    public class FeatureCategoriesListViewModel
    {
        public FeatureCategoriesList FeatureCategoriesList { get; set; }
    }

    public class FeatureCategoriesList
    {
        public ResultCategoryDto Categories { get; set; }
        public int ProductCount { get; set; }
    }
}
