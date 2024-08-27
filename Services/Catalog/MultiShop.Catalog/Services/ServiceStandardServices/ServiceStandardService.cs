using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ServiceStandardDtos;

namespace MultiShop.Catalog.Services.ServiceStandardServices
{
    public class ServiceStandardService : IServiceStandardService
    {
        private readonly IServiceStandardDal _serviceStandardDal;

        public ServiceStandardService(IServiceStandardDal serviceStandardDal)
        {
            _serviceStandardDal = serviceStandardDal;
        }

        public async Task CreateDataAsync(CreateServiceStandardDto createDto)
        {
            await _serviceStandardDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _serviceStandardDal.DeleteData(ss => ss.ServiceStandardId == id);
        }

        public async Task<List<ResultServiceStandardDto>> GetAllDataAsync()
        {
            var values = await _serviceStandardDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdServiceStandardDto> GetDataAsync(string id)
        {
            var value = await _serviceStandardDal.GetDataAsync(ss => ss.ServiceStandardId == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateServiceStandardDto updateDto)
        {
            await _serviceStandardDal.UpdateData(ss => ss.ServiceStandardId == updateDto.ServiceStandardId, updateDto);
        }
    }
}
