using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ServiceStandardDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ServiceStandard")]
    public class ServiceStandardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceStandardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var respopnseMessage = await client.GetAsync("https://localhost:7291/api/servicestandards");

            var model = new ServiceStandardListViewModel();

            if (respopnseMessage.IsSuccessStatusCode)
            {
                var values = await respopnseMessage.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<List<ResultServiceStandardDto>>(values);

                model.ResultServiceStandardDto = jsonData;

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateServiceStandard()
        {
            ViewBag.v0 = "Servis Standartları İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Servis Standartları";
            ViewBag.v3 = "Servis Standartları Listesi";

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateServiceStandardAsync(CreateServiceStandardDto createServiceStandardDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createServiceStandardDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7291/api/servicestandards", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ServiceStandard", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateServiceStandard(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7291/api/servicestandards/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var value = await responseMessage.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<UpdateServiceStandardDto>(value);

                return View(jsonData);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateServiceStandard(UpdateServiceStandardDto updateServiceStandardDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateServiceStandardDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7291/api/servicestandards", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ServiceStandard", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteServiceStandard(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7291/api/servicestandards?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ServiceStandard", new { area = "Admin" });
            }

            return View();
        }
    }
}
