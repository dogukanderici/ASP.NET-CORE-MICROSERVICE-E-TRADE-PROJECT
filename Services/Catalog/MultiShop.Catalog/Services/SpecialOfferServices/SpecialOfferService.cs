using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly ISpecialOfferDal _specialOfferDal;

        public SpecialOfferService(ISpecialOfferDal specialOfferDal)
        {
            _specialOfferDal = specialOfferDal;
        }

        public async Task CreateDataAsync(CreateSpecialOfferDto createDto)
        {
            await _specialOfferDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _specialOfferDal.DeleteData(so => so.SpecailOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllDataAsync()
        {
            var values = await _specialOfferDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdSpecialOfferDto> GetDataAsync(string id)
        {
            var value = await _specialOfferDal.GetDataAsync(so => so.SpecailOfferId == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateSpecialOfferDto updateDto)
        {
            await _specialOfferDal.UpdateData(so => so.SpecailOfferId == updateDto.SpecailOfferId, updateDto);
        }
    }
}
