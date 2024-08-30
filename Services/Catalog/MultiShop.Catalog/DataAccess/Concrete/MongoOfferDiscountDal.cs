using AutoMapper;
using MultiShop.Catalog.Core.DataAccess.Concrete;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Abstract;

namespace MultiShop.Catalog.DataAccess.Concrete
{
    public class MongoOfferDiscountDal : MongoRepositoryBase<OfferDiscount, ResultOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto, GetByIdOfferDiscountDto>, IOfferDiscountDal
    {
        public MongoOfferDiscountDal(IMapper mapper, IDatabaseSettings databaseSettings, IConfiguration configuration, string collectionName) : base(mapper, databaseSettings, configuration, collectionName)
        {
        }
    }
}
