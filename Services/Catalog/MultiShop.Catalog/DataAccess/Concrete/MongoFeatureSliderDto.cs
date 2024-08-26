using AutoMapper;
using MultiShop.Catalog.Core.DataAccess.Concrete;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.DataAccess.Concrete
{
    public class MongoFeatureSliderDto : MongoRepositoryBase<FeatureSlider, ResultFeatureSliderDto, CreateFeatureSliderDto, UpdateFeatureSliderDto, GetByIdFeatureSliderDto>, IFeatureSliderDal
    {
        public MongoFeatureSliderDto(IMapper mapper, IDatabaseSettings databaseSettings, IConfiguration configuration, string collectionName) : base(mapper, databaseSettings, configuration, collectionName)
        {
        }
    }
}