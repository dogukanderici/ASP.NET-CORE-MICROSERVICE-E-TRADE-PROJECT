using Microsoft.AspNetCore.Identity;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.IdentityServer.Models;
using MultiShop.WebUI.Areas.User.Models;

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

        public async Task<bool> ChangePassword(string password)
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/users/changepassword/" + password);
            var values = await response.Content.ReadFromJsonAsync<bool>();

            return values;
        }

        public async Task<bool> ChangePersonalInfo(ChangePersonalInfoViewModel changePersonalInfoViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<ChangePersonalInfoViewModel>("http://localhost:5001/api/users/changepersonalinfo", changePersonalInfoViewModel);
            var values = await response.Content.ReadFromJsonAsync<bool>();

            return values;
        }
    }
}
