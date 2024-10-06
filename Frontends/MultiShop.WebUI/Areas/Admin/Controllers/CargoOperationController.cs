using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.Dtos.CargoDtos.CargoOperationsDtos;
using MultiShop.WebUI.Services.CargoServices.CargoOperationsServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CargoOperation")]
    public class CargoOperationController : BaseController
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        [Route("Detail/{barcode}")]
        public async Task<IActionResult> Index(Guid barcode)
        {
            var values = await _cargoOperationService.TGetAllAsync(barcode);

            ViewBag.Barcode = barcode;

            return View(values);
        }

        [HttpGet]
        [Route("CompleteCargo/{barcode}")]
        public async Task<IActionResult> CompleteCargo(Guid barcode)
        {
            await _cargoOperationService.TAddAsync(new CreateCargoOperationDto
            {
                Barcode = barcode,
                Description = "Teslim Edildi",
                IsDelivered = true,
                OperationDate = DateTime.Now
            });

            return RedirectToAction("Index", "CargoDetail", new { area = "Admin" });
        }

        [HttpGet]
        [Route("AddCargoOperation/{barcode}")]
        public IActionResult AddCargoOperation(Guid barcode)
        {
            List<string> operationType = new List<string> { "Sipariş Hazırlanıyor", "Kargoya Verildi", "Teslimat Şubesine Ulaştı", "Dağıtıma Çıktı" };
            List<SelectListItem> cargoOpTypes = (from x in operationType
                                                 select new SelectListItem
                                                 {
                                                     Text = x,
                                                     Value = x
                                                 }).ToList();
            ViewBag.OperationType = cargoOpTypes;

            return View();
        }

        [HttpPost]
        [Route("AddCargoOperation/{barcode}")]
        public async Task<IActionResult> AddCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            await _cargoOperationService.TAddAsync(createCargoOperationDto);

            return RedirectToAction("Index", "CargoOperation", new { area = "Admin", barcode = createCargoOperationDto.Barcode });
        }
    }
}
