using AutoMapper;
using MultiShop.Catalog.Core.DataAccess.Concrete;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.DataAccess.Concrete
{
    public class MongoSpecialOfferDal : MongoRepositoryBase<SpecialOffer, ResultSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto, GetByIdSpecialOfferDto>, ISpecialOfferDal
    {
        public MongoSpecialOfferDal(IMapper mapper, IDatabaseSettings databaseSettings, IConfiguration configuration, string collectionName) : base(mapper, databaseSettings, configuration, collectionName)
        {
        }
    }
}
