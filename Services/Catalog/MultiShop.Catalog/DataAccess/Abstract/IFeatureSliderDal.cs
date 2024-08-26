using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IFeatureSliderDal : IRepositoryBase<FeatureSlider, ResultFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto, GetByIdFeatureSliderDto>
    {
    }
}
