using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            var basketItems = values.BasketItems;

            var totalPriceWithTax = values.TotalPrice;

            ViewBag.TotalPriceWithTax = totalPriceWithTax;
            ViewBag.DiscountAmount = totalPriceWithTax / 100 * (values.DiscountRate);

            return View(basketItems);
        }
    }
}
