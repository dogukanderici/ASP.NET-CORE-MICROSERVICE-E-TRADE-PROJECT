using MultiShop.Dtos.IdentityDtos;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAllUserListAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/users/alluserlist");
            var values = await response.Content.ReadFromJsonAsync<List<ResultUserDto>>();

            return values;
        }
    }
}
