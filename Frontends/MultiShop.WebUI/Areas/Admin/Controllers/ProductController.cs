using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Utilities.FileOperations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IFileOperationHelper _fileOperationHelper;

        public ProductController(IFileOperationHelper fileOperationHelper, IProductService productService, ICategoryService categoryService)
        {
            _fileOperationHelper = fileOperationHelper;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SetViewBagContent("Ürün İşlemleri", "Ana Sayfa", "Ürün İşlemleri", "Ürün Listesi");

            var model = new ProductListViewModel();

            var responseMessage = await _productService.GetAllDataAsync();
            model.ResultProductDtos = responseMessage;

            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> CreateProduct()
        {
            SetViewBagContent("Ürün İşlemleri", "Ana Sayfa", "Ürün İşlemleri", "Ürün Ekleme");

            List<SelectListItem> categoryValues = await GetCategoryForDropDown();

            ViewBag.CategoryList = categoryValues;

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
            {
                LoadedFile = createProductDto.ProductImage,
                FilePath = "/wwwroot/userfiles/"
            });

            createProductDto.ProductImageUrl = imageUrl;

            var requestMessage = await _productService.CreateDataAsync(createProductDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            SetViewBagContent("Ürün İşlemleri", "Ana Sayfa", "Ürün İşlemleri", "Ürün Düzenleme");

            var checkedResponse = await _productService.GetDataAsync(id);

            var model = new UpdateProductViewModel();

            if (checkedResponse != null)
            {

                model.UpdateProductDto = checkedResponse;

                List<SelectListItem> categoryValues = await GetCategoryForDropDown();

                ViewBag.CategoryList = categoryValues;
            }

            return View(model);
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            if (updateProductDto.ProductImage != null)
            {
                var imageUrl = await _fileOperationHelper.CopyFileToFoler(new FileProperty
                {
                    LoadedFile = updateProductDto.ProductImage,
                    FilePath = "/wwwroot/userfiles/"
                });

                updateProductDto.ProductImageUrl = imageUrl;
            }

            var requestMessage = await _productService.UpdateDataAsync(updateProductDto);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var requestMessage = await _productService.DeleteDataAsync(id);

            if (requestMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }

        public async Task<IActionResult> ProductListWithCategory()
        {
            SetViewBagContent("Ürün İşlemleri", "Ana Sayfa", "Ürün İşlemleri", "Ürün Listesi");

            //var client = _httpClientFactory.CreateClient();

            //var responseMessage = await client.GetAsync("https://localhost:7291/api/products/productlistwithcategory");

            var model = new ProductListWithCategoryViewModel();

            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();

            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);

            //    model.ProductsWithCategory = values;

            //    return View(model);
            //}

            return View(model);
        }

        private async Task<List<SelectListItem>> GetCategoryForDropDown()
        {
            var values = await _categoryService.GetAllDataAsync();            

            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();

            return categoryValues;
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
