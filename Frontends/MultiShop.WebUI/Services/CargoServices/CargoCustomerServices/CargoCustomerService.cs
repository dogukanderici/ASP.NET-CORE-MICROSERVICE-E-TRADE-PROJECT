using MultiShop.Dtos.CargoDtos.CargoCustomerDtos;
using System.Net;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetByIdCargoCustomerDto> GetByIdCargoCustomerAsync(string id)
        {
            var response = await _httpClient.GetAsync("cargocustomers/getbyidcargocustomer?id=" + id);

            GetByIdCargoCustomerDto value = new GetByIdCargoCustomerDto();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                value = await response.Content.ReadFromJsonAsync<GetByIdCargoCustomerDto>();
            }

            return value;
        }
    }
}
