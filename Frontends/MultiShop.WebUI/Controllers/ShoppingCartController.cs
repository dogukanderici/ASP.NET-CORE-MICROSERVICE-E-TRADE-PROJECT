using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Sepetim";

            var values = await _basketService.GetBasket();
            return View(values);
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetDataAsync(productId);
            var items = new BasketItemDto
            {
                ProductId = productId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl= values.ProductImageUrl
            };

            await _basketService.AddBasketItem(items);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItem(productId);

            return RedirectToAction("Index");
        }
    }
}
