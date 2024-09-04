using MultiShop.Dtos.IdentityDtos;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signUpDto);
    }
}
