using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.CargoServices.CargoOperationsServices;
using MultiShop.WebUI.Services.OrderServices.OrderOrderDetailService;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/MyOrder")]
    public class MyOrderController : BaseController
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICargoOperationService _cargoOperationService;
        private IUserService _userService;

        public MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService, IOrderDetailService orderDetailService, ICargoOperationService cargoOperationService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
            _orderDetailService = orderDetailService;
            _cargoOperationService = cargoOperationService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderOrderingService.GetOrderingByUserId(user.Id);

            return View(values);
        }

        [HttpGet]
        [Route("GetOrderDetail/{id}")]
        public async Task<IActionResult> GetOrderDetail(Guid id)
        {
            var values = await _orderDetailService.GetOrderDetail(id);

            return View(values);
        }

        [HttpGet]
        [Route("GetCargoOperation/{barcode}")]
        public async Task<IActionResult> GetCargoOperation(Guid barcode)
        {
            var values = await _cargoOperationService.TGetAllAsync(barcode);

            return View(values);
        }
    }
}
