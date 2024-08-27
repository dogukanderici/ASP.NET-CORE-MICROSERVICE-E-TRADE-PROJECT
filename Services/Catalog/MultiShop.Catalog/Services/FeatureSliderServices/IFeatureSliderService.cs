using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.FeatureSliderService
{
    public interface IFeatureSliderService : IGenericService<FeatureSlider, ResultFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto, GetByIdFeatureSliderDto>
    {
        Task ChangeFeatureSliderStatusAsync(string id, bool status);
    }
}
