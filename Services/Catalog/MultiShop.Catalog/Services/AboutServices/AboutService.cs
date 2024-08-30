using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutService(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task CreateDataAsync(CreateAboutDto createDto)
        {
            await _aboutDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _aboutDal.DeleteData(a => a.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllDataAsync()
        {
            var values = await _aboutDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdAboutDto> GetDataAsync(string id)
        {
            var value = await _aboutDal.GetDataAsync(a => a.AboutId == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateAboutDto updateDto)
        {
            await _aboutDal.UpdateData(a => a.AboutId == updateDto.AboutId, updateDto);
        }
    }
}
