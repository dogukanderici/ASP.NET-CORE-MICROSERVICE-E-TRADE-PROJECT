using Microsoft.AspNetCore.Http.HttpResults;
using MultiShop.Dtos.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task TAddAsync(CreateCargoCompanyDto createDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompanies", createDto);
        }

        public async Task TDeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocompanies?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> TGetAllAsync()
        {
            var response = await _httpClient.GetAsync("cargocompanies");
            var values = await response.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();

            return values;
        }

        public async Task<UpdateCargoCompanyDto> TGetByFilterAsync(int id)
        {
            var response = await _httpClient.GetAsync("cargocompanies/" + id);
            var values = await response.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();

            return values;
        }

        public async Task TUpdateAsync(UpdateCargoCompanyDto updateDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompanies", updateDto);
        }
    }
}
