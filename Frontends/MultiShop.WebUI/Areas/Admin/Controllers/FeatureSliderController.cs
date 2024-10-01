using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Utilities.FileOperations;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.FeatureSliderValidation;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : BaseController
    {
        private readonly IFeatureSliderService _featureSliderService;
        private readonly IFileOperationHelper _fileOperationHelper;

        public FeatureSliderController(IFileOperationHelper fileOperationHelper, IFeatureSliderService featureSliderService)
        {
            _fileOperationHelper = fileOperationHelper;
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Öne Çıkan İşlemleri", "Ana Sayfa", "Öne Çıkanlar", "Öne Çıkan Listesi");

            var model = new FeatureSliderListViewModel();

            var requestMessage = await _featureSliderService.GetAllDataAsync();

            if (requestMessage != null)
            {
                model.ResultFeatureSliderDto = requestMessage;
            }

            return RedirectToAction("NotFound404", "Error");
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateFeatureSlider()
        {
            SetViewBagContent("Öne Çıkan İşlemleri", "Ana Sayfa", "Öne Çıkanlar", "Yeni Öne Çıkan Girişi");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var createFeatureSliderValidator = new CreateFeatureSliderValidator();
            var validator = createFeatureSliderValidator.Validate(createFeatureSliderDto);

            if (validator.IsValid)
            {
                if (createFeatureSliderDto.Image != null)
                {

                    var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                    {
                        LoadedFile = createFeatureSliderDto.Image,
                        FilePath = "/wwwroot/userfiles/"
                    });

                    createFeatureSliderDto.ImageUrl = imageUrl;
                }

                var requestMessage = await _featureSliderService.CreateDataAsync(createFeatureSliderDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
                }
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            SetViewBagContent("Öne Çıkan İşlemleri", "Ana Sayfa", "Öne Çıkanlar", "Öne Çıkan Düzenleme");

            var requestMessage = await _featureSliderService.GetDataAsync(id);

            if (requestMessage != null)
            {

                return View(requestMessage);
            }

            return RedirectToAction("NotFound404", "Error");
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var updateFeatureSliderValidator = new UpdateFeatureSliderValidator();
            var validator = updateFeatureSliderValidator.Validate(updateFeatureSliderDto);

            if (validator.IsValid)
            {

                if (updateFeatureSliderDto.Image != null)
                {

                    var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                    {
                        LoadedFile = updateFeatureSliderDto.Image,
                        FilePath = "/wwwroot/userfiles/"
                    });

                    updateFeatureSliderDto.ImageUrl = imageUrl;
                }

                var requestMessage = await _featureSliderService.UpdateDataAsync(updateFeatureSliderDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
                }
            }

            return await UpdateFeatureSlider(updateFeatureSliderDto.FeatureSliderId);
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {

            var requestMessage = await _featureSliderService.DeleteDataAsync(id);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }

            return RedirectToAction("NotFound404", "Error");
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
