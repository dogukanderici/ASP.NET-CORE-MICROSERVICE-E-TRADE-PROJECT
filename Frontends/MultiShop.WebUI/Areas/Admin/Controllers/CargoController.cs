using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : BaseController
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        [Route("CargoCompanyList")]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.TGetAllAsync();

            return View(values);
        }

        [HttpGet]
        [Route("CreateCompany")]
        public async Task<IActionResult> CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.TAddAsync(createCargoCompanyDto);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var value = await _cargoCompanyService.TGetByFilterAsync(id);

            if (value != null)
            {
                return View(value);
            }

            return View(new UpdateCargoCompanyDto());
        }

        [HttpPost]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.TUpdateAsync(updateCargoCompanyDto);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }


        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.TDeleteAsync(id);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }
    }
}
