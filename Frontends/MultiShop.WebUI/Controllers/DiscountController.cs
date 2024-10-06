using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    [Authorize]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCode()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCode(string code)
        {
            // Kullanıcı sepetine uygulanacak olan indirim kuponu getirilir.
            var values = await _discountService.GetDiscountCode(code);

            // İndirim kuponu uygulanır.
            var basketValues = await _basketService.GetBasket();
            // Her üründen sabit %10 KDV alınır.
            //var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice / 100 * 10);
            //var discountAmount = totalPriceWithTax / 100 * (values.Rate);
            //var totalNewPriceWithDiscount = totalPriceWithTax - discountAmount;

            var totalPriceWithTax = basketValues.TotalPrice;
            var discountAmount = totalPriceWithTax / 100 * (values.Rate);
            var totalNewPriceWithDiscount = totalPriceWithTax - discountAmount;

            // İndirim sonrası sepet güncellenir.

            basketValues.DiscountCode = (code == null ? "0%" : code);
            basketValues.DiscountRate = values.Rate;
            basketValues.IsAppliedDiscount = true;

            // Sepet kaydedilir.
            await _basketService.SaveBasket(basketValues);

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values.Rate, discountAmount = discountAmount });
        }
    }
}
