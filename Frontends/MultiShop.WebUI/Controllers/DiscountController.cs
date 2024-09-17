﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
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
            var values = await _discountService.GetDiscountCode(code);

            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice / 100 * 10);
            var discountAmount = totalPriceWithTax / 100 * (values.Rate);
            var totalNewPriceWithDiscount = totalPriceWithTax - discountAmount;

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values.Rate, discountAmount = discountAmount });
        }
    }
}
