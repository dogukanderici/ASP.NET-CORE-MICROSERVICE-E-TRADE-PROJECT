using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.ServiceStandardDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Services.CatalogServices.ServiceStandardServices;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.ServiceStandardValidation;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ServiceStandard")]
    public class ServiceStandardController : BaseController
    {
        private readonly IServiceStandardService _serviceStandardService;

        public ServiceStandardController(IServiceStandardService serviceStandardService)
        {
            _serviceStandardService = serviceStandardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Servis Standartları İşlemleri", "Ana Sayfa", "Servis Standartları", "Servis Standartları Listesi");

            var model = new ServiceStandardListViewModel();

            var requestMessage = await _serviceStandardService.GetAllDataAsync();

            if (requestMessage != null)
            {
                model.ResultServiceStandardDto = requestMessage;
            }

            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateServiceStandard()
        {
            SetViewBagContent("Servis Standartları İşlemleri", "Ana Sayfa", "Servis Standartları", "Servis Standartları Listesi");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateServiceStandardAsync(CreateServiceStandardDto createServiceStandardDto)
        {
            var createServiceStandardValidator = new CreateServiceStandardValidator();
            var validator = createServiceStandardValidator.Validate(createServiceStandardDto);

            if (validator.IsValid)
            {

                var requestMessage = await _serviceStandardService.CreateDataAsync(createServiceStandardDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "ServiceStandard", new { area = "Admin" });
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateServiceStandard(string id)
        {
            var requestMessage = await _serviceStandardService.GetDataAsync(id);

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateServiceStandard(UpdateServiceStandardDto updateServiceStandardDto)
        {
            var updateServiceStandardValidator = new UpdateServiceStandardValidator();
            var validator = updateServiceStandardValidator.Validate(updateServiceStandardDto);

            if (validator.IsValid)
            {

                var requestMessage = await _serviceStandardService.UpdateDataAsync(updateServiceStandardDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "ServiceStandard", new { area = "Admin" });
                }
            }

            return await UpdateServiceStandard(updateServiceStandardDto.ServiceStandardId);
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteServiceStandard(string id)
        {

            var requestMessage = await _serviceStandardService.DeleteDataAsync(id);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ServiceStandard", new { area = "Admin" });
            }

            return View();
        }
        void SetViewBagContent(string mainTitle, string homePageTitle, string title, string subTitle)
        {
            ViewBag.v0 = mainTitle;
            ViewBag.v1 = homePageTitle;
            ViewBag.v2 = title;
            ViewBag.v3 = subTitle;
        }
    }
}
