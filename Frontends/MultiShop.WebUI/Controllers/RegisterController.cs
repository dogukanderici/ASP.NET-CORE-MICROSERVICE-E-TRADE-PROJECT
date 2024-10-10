using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UIValidations.LoginRegisterValidations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            var createRegisterValidator = new RegisterValidator();
            var validator = createRegisterValidator.Validate(createRegisterDto);

            if (validator.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createRegisterDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/registers", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    var reponseMessageContent = await responseMessage.Content.ReadAsStringAsync();
                    RegisterErrorViewModel reponseMessageContentJson = JsonConvert.DeserializeObject<RegisterErrorViewModel>(reponseMessageContent);

                    foreach (var errorItem in reponseMessageContentJson.message)
                    {
                        ModelState.AddModelError("", errorItem);
                    }

                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
