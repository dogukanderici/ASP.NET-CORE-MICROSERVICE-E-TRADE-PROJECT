using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dtos.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Entities.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll(null);

            return Ok(values.Select(x => _mapper.Map<GetCargoCustomerDto>(x)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerGetById(int id)
        {
            var value = _cargoCustomerService.TGetByFilter(id);

            var valueToDto = _mapper.Map<GetCargoCustomerDto>(value);

            return Ok(valueToDto);
        }

        [HttpGet("GetByIdCargoCustomer")]
        public IActionResult GetByIdCargoCustomer(string id)
        {
            var value = _cargoCustomerService.TGetByIdCargoCustomer(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var valueFromDto = _mapper.Map<CargoCustomer>(createCargoCustomerDto);

            _cargoCustomerService.TAdd(valueFromDto);

            return Ok("Kargo Müşterisi Başarıyla Eklendi.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);

            return Ok("Kargo Müşterisi Başarıyla Kaldırıldı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var valueFromDto = _mapper.Map<CargoCustomer>(updateCargoCustomerDto);

            _cargoCustomerService.TUpdate(valueFromDto);

            return Ok("Kargo Müşterisi Bilgisi Başarıyla Güncellendi.");
        }
    }
}
