using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Abstract;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signUpDto)
        {

            await _identityService.SignIn(signUpDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
