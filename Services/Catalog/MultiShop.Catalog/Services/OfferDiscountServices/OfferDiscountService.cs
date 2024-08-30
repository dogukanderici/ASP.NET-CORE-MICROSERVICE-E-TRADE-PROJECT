using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IOfferDiscountDal _offerDiscountDal;

        public OfferDiscountService(IOfferDiscountDal offerDiscountDal)
        {
            _offerDiscountDal = offerDiscountDal;
        }

        public async Task CreateDataAsync(CreateOfferDiscountDto createDto)
        {
            await _offerDiscountDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _offerDiscountDal.DeleteData(od => od.OfferDiscountId == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllDataAsync()
        {
            var values = await _offerDiscountDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdOfferDiscountDto> GetDataAsync(string id)
        {
            var value = await _offerDiscountDal.GetDataAsync(od => od.OfferDiscountId == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateOfferDiscountDto updateDto)
        {
            await _offerDiscountDal.UpdateData(od => od.OfferDiscountId == updateDto.OfferDiscountId, updateDto);
        }
    }
}
