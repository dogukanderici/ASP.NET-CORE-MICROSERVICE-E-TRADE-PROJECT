using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CargoDtos.CargoDetailDtos;
using MultiShop.WebUI.Services.CargoServices.CargoDetailServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CargoDetail")]
    public class CargoDetailController : BaseController
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Guid barcode)
        {
            var values = await _cargoDetailService.TGetAllAsync(barcode == null ? Guid.Parse("00000000-0000-0000-0000-000000000000") : barcode);

            return Json(values);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateCargoDetail()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            await _cargoDetailService.TAddAsync(createCargoDetailDto);

            return RedirectToAction("Index", "CargoDetail", new { barcode = createCargoDetailDto.Barcode });
        }

        [HttpGet]
        [Route("Update/{barcode}")]
        public async Task<IActionResult> UpdateCargoDetail(Guid barcode)
        {
            var value = await _cargoDetailService.TGetAllAsync(barcode);

            return View(value);
        }

        [HttpPost]
        [Route("Update/{barcode}")]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _cargoDetailService.TUpdateAsync(updateCargoDetailDto);

            return RedirectToAction("Index", "CargoDetail", new { barcode = updateCargoDetailDto.Barcode });
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _cargoDetailService.TDeleteAsync(id);

            return RedirectToAction("Index", "CargoDetail");
        }
    }
}
