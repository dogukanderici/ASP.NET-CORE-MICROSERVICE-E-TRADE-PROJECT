using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Utilities.FileOperations;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.CategoryValidation;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : BaseController
    {

        private IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;
        private readonly IFileOperationHelper _fileOperationHelper;

        public CategoryController(IHttpClientFactory httpClientFactory, IFileOperationHelper fileOperationHelper, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _fileOperationHelper = fileOperationHelper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Kategori İşlemleri", "Ana Sayfa", "Kategoriler", "Kategori Listesi");

            var model = new CategoryListViewModel();

            var values = await _categoryService.GetAllDataAsync();

            model.ResultCategoryDtos = values;

            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateCategory()
        {
            SetViewBagContent("Kategori İşlemleri", "Ana Sayfa", "Kategoriler", "Yeni Kategori Girişi");

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var createCategoryValidator = new CreateCategoryValidator();
            var validator = createCategoryValidator.Validate(createCategoryDto);

            if (validator.IsValid)
            {
                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = createCategoryDto.CategoryImage,
                    FilePath = "/wwwroot/userfiles/"
                });

                createCategoryDto.CategoryImageUrl = imageUrl;

                var requestResponse = await _categoryService.CreateDataAsync(createCategoryDto);

                if (requestResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Category", new { area = "Admin" });
                }
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var requestResponse = await _categoryService.DeleteDataAsync(id);

            if (requestResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            SetViewBagContent("Kategori İşlemleri", "Ana Sayfa", "Kategoriler", "Kategori Düzenleme");

            var value = await _categoryService.GetDataAsync(id);

            return View(value);
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var updateCategoryValidator = new UpdateCategoryValidator();
            var validator = updateCategoryValidator.Validate(updateCategoryDto);

            if (validator.IsValid)
            {
                if (updateCategoryDto.CategoryImage != null)
                {
                    var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                    {
                        LoadedFile = updateCategoryDto.CategoryImage,
                        FilePath = "/wwwroot/userfiles/"
                    });

                    updateCategoryDto.CategoryImageUrl = imageUrl;
                }

                var requestResponse = await _categoryService.UpdateDataAsync(updateCategoryDto);

                if (requestResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Category", new { area = "Admin" });
                }
            }

            var value = await _categoryService.GetDataAsync(updateCategoryDto.CategoryID);

            return View(value);
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
