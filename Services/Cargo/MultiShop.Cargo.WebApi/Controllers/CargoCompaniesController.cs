using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dtos.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Entities.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll(null);

            return Ok(values.Select(x => _mapper.Map<GetCargoCompanyDto>(x)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetByFilter(id);

            var valueToDto = _mapper.Map<GetCargoCompanyDto>(value);

            return Ok(valueToDto);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var valueFromDto = _mapper.Map<CargoCompany>(createCargoCompanyDto);

            _cargoCompanyService.TAdd(valueFromDto);

            return Ok("Kargo Şirketi Başarıyla Eklendi.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);

            return Ok("Kargo Şirketi Başarıyla Kaldırıldı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoComapny(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var valueFromDto = _mapper.Map<CargoCompany>(updateCargoCompanyDto);

            _cargoCompanyService.TUpdate(valueFromDto);

            return Ok("Kargo Şirketi Başarıyla Güncellendi.");
        }
    }
}
