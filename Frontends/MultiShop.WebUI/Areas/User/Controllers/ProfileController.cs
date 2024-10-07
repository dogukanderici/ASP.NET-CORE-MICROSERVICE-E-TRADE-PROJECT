using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.OrderDtos.OrderAddressDtos;
using MultiShop.IdentityServer.Models;
using MultiShop.WebUI.Areas.User.Models;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.UserIdentityServices;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UserAreaValidation.ChangePasswordValidation;
using MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UserAreaValidation.ChangePersonalInfoValidation;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Profile")]
    public class ProfileController : BaseController
    {
        private readonly IOrderAddressService _orderAddressService;
        private IUserIdentityService _userIdentityService;
        private IUserService _userService;

        public ProfileController(IOrderAddressService orderAddressService, IUserService userService, IUserIdentityService userIdentityService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
            _userIdentityService = userIdentityService;
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

        [HttpGet]
        [Route("ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            var changePasswordValidator = new ChangePasswordValidator();
            var validator = changePasswordValidator.Validate(changePasswordViewModel);

            if (validator.IsValid)
            {
                var result = await _userIdentityService.ChangePassword(changePasswordViewModel.NewPassword);

                if (result)
                {
                    return RedirectToAction("Addresses", "Profile", new { area = "User" });
                }

                ViewBag.ChangePasswordError = "Şifre Değişikliğiniz Sırasında Beklenmedik Bir Hata Oluştu. Lütfen Tekrar Deneyiniz!";
            }

            return View();
        }

        [HttpGet]
        [Route("PersonalInfos")]
        public IActionResult ChangePersonalInfo()
        {
            return View();
        }

        [HttpPost]
        [Route("PersonalInfos")]
        public async Task<IActionResult> ChangePersonalInfo(ChangePersonalInfoViewModel changePersonalInfoViewModel)
        {
            var changePersonalInfoValidator = new ChangePersonalInfoValidator();
            var validator = changePersonalInfoValidator.Validate(changePersonalInfoViewModel);

            if (validator.IsValid)
            {
                var result = await _userIdentityService.ChangePersonalInfo(changePersonalInfoViewModel);

                if (result)
                {
                    return RedirectToAction("Addresses", "Profile", new { area = "User" });
                }

                ViewBag.ChangePersonalInfoError = "Kişisel Bilgileriniz Güncellenirken Beklenmedik Bir Hata Oluştu. Lütfen Tekrar Deneyiniz!";
            }

            return View();
        }
    }
}