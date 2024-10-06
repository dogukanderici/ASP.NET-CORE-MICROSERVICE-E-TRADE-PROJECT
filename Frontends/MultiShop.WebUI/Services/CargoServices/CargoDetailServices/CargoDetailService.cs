using MultiShop.Dtos.CargoDtos.CargoDetailDtos;
using System.Linq.Expressions;

namespace MultiShop.WebUI.Services.CargoServices.CargoDetailServices
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly HttpClient _httpClient;

        public CargoDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task TAddAsync(CreateCargoDetailDto createDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoDetailDto>("cargodetails", createDto);
        }

        public async Task TDeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("cargodetails?id=" + id);
        }

        public async Task<List<ResultCargoDetailDto>> TGetAllAsync(Guid? barcode)
        {
            var response = await _httpClient.GetAsync("cargodetails?barcode=" + barcode);
            var values = await response.Content.ReadFromJsonAsync<List<ResultCargoDetailDto>>();

            return values;
        }

        public Task<UpdateCargoDetailDto> TGetByFilterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(UpdateCargoDetailDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
