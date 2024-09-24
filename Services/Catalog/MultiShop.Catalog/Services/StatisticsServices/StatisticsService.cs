using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings.Concrete;

namespace MultiShop.Catalog.Services.StatisticsServices
{
    public class StatisticsService : IStatisticsService
    {
        private IProductDal _productDal;
        private ICategoryDal _categoryDal;
        private IVendorDal _vendorDal;
        private readonly IMapper _mapper;

        public StatisticsService(IProductDal productDal, ICategoryDal categoryDal, IVendorDal vendorDal, IMapper mapper)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
            _vendorDal = vendorDal;
            _mapper = mapper;
        }

        public long GetCategoryCount()
        {
            return _categoryDal.GetCount();
        }

        public long GetProductCount()
        {
            return _productDal.GetCount();
        }

        public long GetVendorCount()
        {
            return _vendorDal.GetCount();
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            return await _productDal.GetProductAvgPrice();
        }

        public string GetMaxPriceProductName()
        {
            return _productDal.GetMaxPriceProductName();
        }

        public string GetMinPriceProductName()
        {
            return _productDal.GetMinPriceProductName();
        }
    }
}
