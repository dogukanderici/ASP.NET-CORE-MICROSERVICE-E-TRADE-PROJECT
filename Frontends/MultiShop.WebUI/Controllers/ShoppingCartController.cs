using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal discountAmount)
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Sepetim";

            var values = await _basketService.GetBasket();

            if ((values.BasketItems == null) || (values.BasketItems.Count() < 1))
            {
                ViewBag.CheckBasketItems = false;
            }
            else
            {
                var totalPriceWithTax = values.TotalPrice;
                var totalPriceWithoutTax = values.TotalPrice - (values.TotalPrice / 100 * 10);

                ViewBag.CheckBasketItems = true;
                ViewBag.TotalPriceWithTax = totalPriceWithTax;
                ViewBag.TotalPrice = totalPriceWithoutTax;
                ViewBag.Tax = totalPriceWithoutTax / 100 * 10;
                ViewBag.Code = code;
                ViewBag.DiscountRate = discountRate;
                ViewBag.DiscountAmount = discountAmount;
            }

            return View();
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
                ProductImageUrl = values.ProductImageUrl
            };

            await _basketService.AddBasketItem(items);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBasketItem(string productId, int itemQuantity)
        {
            var values = await _basketService.GetBasket();

            foreach (var basketItem in values.BasketItems)
            {
                if (basketItem.ProductId == productId)
                {
                    basketItem.Quantity = itemQuantity;

                    await _basketService.SaveBasket(values);
                }
            }

            return Json(new { success = true });
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItem(productId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItemFromBasket(string productId, int itemQuantity)
        {
            var values = await _basketService.GetBasket();

            foreach (var basketItem in values.BasketItems)
            {
                if (basketItem.ProductId == productId)
                {
                    basketItem.Quantity = itemQuantity;

                    await _basketService.SaveBasket(values);
                }
            }

            return Json(new { success = true });
        }
    }
}