using MultiShop.Dtos.CargoDtos.CargoOperationsDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoOperationsServices
{
    public class CargoOperationService : ICargoOperationService
    {
        private readonly HttpClient _httpClient;

        public CargoOperationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task TAddAsync(CreateCargoOperationDto createDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoOperationDto>("cargooperations", createDto);
        }

        public async Task TDeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("cargooperations?id=" + id);
        }

        public async Task<List<ResultcargoOperationDto>> TGetAllAsync(Guid? barcode)
        {
            var response = await _httpClient.GetAsync("cargooperations/cargooperationlist/" + barcode);
            var values = await response.Content.ReadFromJsonAsync<List<ResultcargoOperationDto>>();

            return values;
        }

        public async Task<UpdateCargoOperationDto> TGetByFilterAsync(int id)
        {
            var response = await _httpClient.GetAsync("cargooperations/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateCargoOperationDto>();

            return value;
        }

        public async Task TUpdateAsync(UpdateCargoOperationDto updateDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoOperationDto>("cargooperations", updateDto);
        }
    }
}
