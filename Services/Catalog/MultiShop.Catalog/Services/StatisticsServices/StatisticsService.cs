using AutoMapper;
using MultiShop.Catalog.DataAccess.Abstract;

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
    }
}
