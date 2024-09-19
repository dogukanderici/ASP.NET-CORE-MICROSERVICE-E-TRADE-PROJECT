using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Siparişler";
            ViewBag.Directory3 = "Sipariş İşlemleri";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Siparişler";
            ViewBag.Directory3 = "Sipariş İşlemleri";

            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;

            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
