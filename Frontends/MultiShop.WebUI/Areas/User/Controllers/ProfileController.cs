using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Profile")]
    public class ProfileController : BaseController
    {
        private readonly IOrderAddressService _orderAddressService;
        private IUserService _userService;

        public ProfileController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Addresses")]
        public async Task<IActionResult> GetMyAddresses()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderAddressService.GetUserOrderAddressAsync(user.Id);

            return View(values);
        }

        [HttpGet]
        [Route("AddOrderAddress")]
        public IActionResult CreateOrderAddress()
        {
            return View();
        }

        [HttpPost]
        [Route("AddOrderAddress")]
        public async Task<IActionResult> CreateOrderAddress(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;

            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Addresses", "Profile", new { area = "User" });
        }

        [HttpGet]
        [Route("EditAddress")]
        public async Task<IActionResult> UpdateAddress(string userId)
        {
            var values = await _orderAddressService.GetUserOrderAddressAsync(userId);

            return View(values);
        }

        [HttpPost]
        [Route("EditAddress")]
        public async Task<IActionResult> UpdateAddress(UpdateOrderAddressDto updateUserAddressDto)
        {
            await _orderAddressService.UpdateOrderAddressAsync(updateUserAddressDto);

            return RedirectToAction("Addresses", "Profile", new { area = "User" });
        }
    }
}
