using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Hakkımızda İşlemleri", "Ana Sayfa", "Hakkımızda Bilgileri", "Hakkımızda Bilgi Listesi");

            var requestMessage = await _aboutService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
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
            var requestMessage = await _aboutService.CreateDataAsync(createAboutDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
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

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var requestMessage = await _aboutService.GetDataAsync(id);

            if (requestMessage != null)
            {

                return View(requestMessage);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var requestMessage = await _aboutService.UpdateDataAsync(updateAboutDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
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
