using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService : IGenericService<ResultFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto>
    {
        Task ChangeFeatureSliderStatusAsync(string id, bool status);
    }
}
