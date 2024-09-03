using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Utilities.Security.Jwt;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenHelper _tokenHelper;

        public LoginsController(SignInManager<ApplicationUser> signInManager, ITokenHelper tokenHelper, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);

            var user = await _userManager.FindByNameAsync(userLoginDto.Username);

            if (result.Succeeded)
            {
                //return Ok("Kullanıcı Girişi Başarılı");

                GetUserViewModel getUserViewModel = new GetUserViewModel();

                getUserViewModel.Username = userLoginDto.Username;
                getUserViewModel.Id = user.Id;

                var token = _tokenHelper.CreateAccessToken(getUserViewModel);

                return Ok(token);
            }

            return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
        }
    }
}
