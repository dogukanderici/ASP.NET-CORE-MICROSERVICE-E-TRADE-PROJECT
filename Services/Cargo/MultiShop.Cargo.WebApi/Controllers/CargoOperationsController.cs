using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dtos.Dtos.CargoOperationDtos;
using MultiShop.Cargo.Entities.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("CargoOperationList/{barcode}")]
        public IActionResult CargoOperationList(Guid barcode)
        {
            var values = _cargoOperationService.TGetAll(barcode);

            return Ok(values.Select(x => _mapper.Map<GetCargoOperationDto>(x)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetByFilter(id);

            var valueToDto = _mapper.Map<GetCargoOperationDto>(value);

            return Ok(valueToDto);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var valueFromDto = _mapper.Map<CargoOperation>(createCargoOperationDto);

            _cargoOperationService.TAdd(valueFromDto);

            return Ok("Kargo Hareketi Başarıyla Eklendi.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);

            return Ok("Kargo Hareketi Başarıyla Kaldırıldı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var valueFromDto = _mapper.Map<CargoOperation>(updateCargoOperationDto);

            _cargoOperationService.TUpdate(valueFromDto);

            return Ok("Kargo Hareketi Bilgisi Başarıyla Güncellendi.");
        }
    }
}
