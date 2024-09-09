using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Services.CatalogServices.SpecailOfferServies;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;
        private readonly IFileOperationHelper _fileOperationHelper;

        public SpecialOfferController(IFileOperationHelper fileOperationHelper, ISpecialOfferService specialOfferService)
        {
            _fileOperationHelper = fileOperationHelper;
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Özel Teklif İşlemleri", "Ana Sayfa", "Özel Teklifler", "Özel Teklif Listesi");

            var model = new SpecialOfferListVierwModel();

            var requestMessage = await _specialOfferService.GetAllDataAsync();

            if (requestMessage != null)
            {

                model.ResultSpecialOfferDto = requestMessage;
            }

            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateSpecialOffer()
        {
            SetViewBagContent("Özel Teklif İşlemleri", "Ana Sayfa", "Özel Teklifler", "Yeni Özel Teklif Ekleme");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
            {
                LoadedFile = createSpecialOfferDto.Image,
                FilePath = "/wwwroot/userfiles/"
            });

            createSpecialOfferDto.ImageUrl = imageUrl;

            var requestMessage = await _specialOfferService.CreateDataAsync(createSpecialOfferDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            var requestMessage = await _specialOfferService.GetDataAsync(id);

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {

            if (updateSpecialOfferDto.Image != null)
            {
                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = updateSpecialOfferDto.Image,
                    FilePath = "/wwwroot/userfiles/"
                });

                updateSpecialOfferDto.ImageUrl = imageUrl;
            }

            var requestMessage = await _specialOfferService.UpdateDataAsync(updateSpecialOfferDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { arera = "Admin" });
            }

            return View();
        }

        [Route("Delete")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var requestMessage = await _specialOfferService.DeleteDataAsync(id);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
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
