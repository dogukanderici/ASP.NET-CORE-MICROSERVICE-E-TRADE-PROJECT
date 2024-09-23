using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public PaymentController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Ödeme Ekranı";
            ViewBag.Directory3 = "Kredi/Banka Kartı";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment()
        {
            var user = await _userService.GetUserInfo();
            var value = await _orderAddressService.GetUserOrderAddressAsync(user.Id);

            return RedirectToAction("Index", "Default");
        }
    }
}
