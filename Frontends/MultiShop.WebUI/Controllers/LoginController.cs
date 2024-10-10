using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UIValidations.LoginRegisterValidations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var deneme = ViewBag.InvalidUserPassword;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signUpDto)
        {
            var signInValidator = new LoginValidator();
            var validator = signInValidator.Validate(signUpDto);

            if (validator.IsValid)
            {
                var result = await _identityService.SignIn(signUpDto);

                if (!result)
                {
                    ViewBag.InvalidUserPassword = "Kullanıcı Adı veya Şifre Hatalı!";
                    return View();
                }

                return RedirectToAction("Index", "Default");
            }
            else
            {
                return View();
            }
        }
    }
}
