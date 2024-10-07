using Microsoft.AspNetCore.Identity;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.IdentityServer.Models;
using MultiShop.WebUI.Areas.User.Models;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
        Task<bool> ChangePassword(string password);
        Task<bool> ChangePersonalInfo(ChangePersonalInfoViewModel changePersonalInfoViewModel);
    }
}
