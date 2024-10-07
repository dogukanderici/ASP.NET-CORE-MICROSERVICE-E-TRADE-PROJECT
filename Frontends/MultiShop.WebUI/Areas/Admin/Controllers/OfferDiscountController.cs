using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Utilities.FileOperations;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.OfferDiscountValidation;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : BaseController
    {
        private readonly IOfferDiscountService _offerDiscountService;
        private readonly IFileOperationHelper _fileOperationHelper;

        public OfferDiscountController(IFileOperationHelper fileOperationHelper, IOfferDiscountService offerDiscountService)
        {
            _fileOperationHelper = fileOperationHelper;
            _offerDiscountService = offerDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Özel İndirim İşlemleri", "Ana Sayfa", "Özel İndirimler", "Özel İndirim Listesi");

            var requestMessage = await _offerDiscountService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateOfferDiscount()
        {
            SetViewBagContent("Özel İndirim İşlemleri", "Ana Sayfa", "Özel İndirimler", "Yeni Özel İndirim Ekleme");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var cerateOfferDiscountValidator = new CreateOfferDiscountValidator();
            var validator = cerateOfferDiscountValidator.Validate(createOfferDiscountDto);

            if (validator.IsValid)
            {

                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = createOfferDiscountDto.OfferDiscountSubImage,
                    FilePath = "/wwwroot/userfiles/"
                });

                createOfferDiscountDto.OfferDiscountSubImageUrl = imageUrl;

                var requestMessage = await _offerDiscountService.CreateDataAsync(createOfferDiscountDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
                }
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var requestMessage = await _offerDiscountService.DeleteDataAsync(id);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }

            return RedirectToAction("NotFound404", "Error");
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            SetViewBagContent("Özel İndirim İşlemleri", "Ana Sayfa", "Özel İndirimler", "Özel İndirim Düzenleme");

            var requestMessage = await _offerDiscountService.GetDataAsync(id);

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var updateOfferDiscountValidator = new UpdateOfferDiscountValidator();
            var validator = updateOfferDiscountValidator.Validate(updateOfferDiscountDto);

            if (validator.IsValid)
            {

                if (updateOfferDiscountDto.OfferDiscountSubImage != null)
                {
                    var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                    {
                        LoadedFile = updateOfferDiscountDto.OfferDiscountSubImage,
                        FilePath = "/wwwroot/userfiles/"
                    });

                    updateOfferDiscountDto.OfferDiscountSubImageUrl = imageUrl;
                }

                var requestMessage = await _offerDiscountService.UpdateDataAsync(updateOfferDiscountDto);

                if (requestMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
                }
            }

            return await UpdateOfferDiscount(updateOfferDiscountDto.OfferDiscountId);
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
