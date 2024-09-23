using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.VendorDtos;
using MultiShop.WebUI.Services.CatalogServices.VendorServices;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Vendor")]
    public class VendorController : BaseController
    {
        private readonly IVendorService _vendorService;
        private readonly IFileOperationHelper _fileOperationHelper;

        public VendorController(IFileOperationHelper fileOperationHelper, IVendorService vendorService)
        {
            _fileOperationHelper = fileOperationHelper;
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Marka İşlemleri", "Ana Sayfa", "Markalar", "Marka Listesi");

            var requestMessage = await _vendorService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateVendor()
        {
            SetViewBagContent("Marka İşlemleri", "Ana Sayfa", "Markalar", "Marka Listesi");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {

            var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
            {
                LoadedFile = createVendorDto.VendorImage,
                FilePath = "/wwwroot/userfiles/"
            });

            createVendorDto.VendorImageUrl = imageUrl;

            var requestMessage = await _vendorService.CreateDataAsync(createVendorDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteVendor(string id)
        {

            var requestMessage = await _vendorService.DeleteDataAsync(id);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateVendor(string id)
        {
            SetViewBagContent("Marka İşlemleri", "Ana Sayfa", "Markalar", "Marka Düzenleme");

            var requestMessage = await _vendorService.GetDataAsync(id);

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {

            if (updateVendorDto.VendorImage != null)
            {
                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = updateVendorDto.VendorImage,
                    FilePath = "/wwwroot/userfiles/"
                });

                updateVendorDto.VendorImageUrl = imageUrl;
            }

            var requestMessage = await _vendorService.UpdateDataAsync(updateVendorDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
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
