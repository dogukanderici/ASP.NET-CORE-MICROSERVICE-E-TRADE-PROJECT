using AutoMapper;
using MultiShop.Catalog.Core.DataAccess.Concrete;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.DataAccess.Concrete
{
    public class MongoAboutDal : MongoRepositoryBase<About, ResultAboutDto, CreateAboutDto, UpdateAboutDto, GetByIdAboutDto>, IAboutDal
    {
        public MongoAboutDal(IMapper mapper, IDatabaseSettings databaseSettings, IConfiguration configuration, string collectionName) : base(mapper, databaseSettings, configuration, collectionName)
        {
        }
    }
}
