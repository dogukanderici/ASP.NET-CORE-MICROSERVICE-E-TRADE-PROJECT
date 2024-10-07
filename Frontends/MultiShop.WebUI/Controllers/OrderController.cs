using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        private readonly IBasketService _basketService;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService, IBasketService basketService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Siparişler";
            ViewBag.Directory3 = "Sipariş İşlemleri";

            var user = await _userService.GetUserInfo();
            var value = await _orderAddressService.GetUserOrderAddressAsync(user.Id);

            var model = new OrderViewModel();

            model.UpdateOrderAddress = value;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel orderViewModel)
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Siparişler";
            ViewBag.Directory3 = "Sipariş İşlemleri";

            return RedirectToAction("Index", "Payment");
        }

        [HttpPost]
        public async Task<IActionResult> SetTempCargoCompany(string selectedCargoCompany)
        {
            var values = await _basketService.GetBasket();
            values.CargoCompany = selectedCargoCompany;

            await _basketService.SaveBasket(values);

            return Json(new { success = true, selectedCargoCompany });
        }
    }
}
