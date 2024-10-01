using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AboutValidation;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? statusCode)
        {
            SetViewBagContent("Hakkımızda İşlemleri", "Ana Sayfa", "Hakkımızda Bilgileri", "Hakkımızda Bilgi Listesi");

            if (statusCode != null)
            {
                HttpStatusCode statusCodeStr = (HttpStatusCode)statusCode;
                //SetViewBagStatusInfo(statusCode, statusCodeStr.ToString());
                SetViewBagStatusInfo(statusCode, "Aradığınız Veri Bulunamadı!");
            }

            var requestMessage = await _aboutService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return RedirectToAction("NotFound404", "Error");
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateAbout()
        {
            SetViewBagContent("Hakkımızda İşlemleri", "Ana Sayfa", "Hakkımızda Bilgileri", "Hakkımızda Bilgi Ekleme");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var createAboutValidator = new CreateAboutValidator();
            var validator = createAboutValidator.Validate(createAboutDto);

            if (validator.IsValid)
            {
                var requestMessage = await _aboutService.CreateDataAsync(createAboutDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "About", new { area = "Admin" });
                }
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            var requestMessage = await _aboutService.DeleteDataAsync(id);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }

            return RedirectToAction("NotFound404", "Error");
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            SetViewBagContent("Hakkımızda İşlemleri", "Ana Sayfa", "Hakkımızda Bilgileri", "Hakkımızda Bilgi Güncelleme");

            var requestMessage = await _aboutService.GetDataAsync(id);

            if (requestMessage != null)
            {

                return View(requestMessage);
            }

            return RedirectToAction("Index", "About", new { area = "Admin", statusCode = 404 });
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var updateAboutValidator = new UpdateAboutValidator();
            var validator = updateAboutValidator.Validate(updateAboutDto);

            if (validator.IsValid)
            {
                var requestMessage = await _aboutService.UpdateDataAsync(updateAboutDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "About", new { area = "Admin" });
                }
            }

            return await UpdateAbout(updateAboutDto.AboutId);
        }
        void SetViewBagContent(string mainTitle, string homePageTitle, string title, string subTitle)
        {
            ViewBag.v0 = mainTitle;
            ViewBag.v1 = homePageTitle;
            ViewBag.v2 = title;
            ViewBag.v3 = subTitle;
        }

        void SetViewBagStatusInfo(int? statusCode, string statsuMessage)
        {
            ViewBag.StatusCode = statusCode;
            ViewBag.StatusMessage = statsuMessage;
        }
    }
}
