using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dtos.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Dtos.Dtos.CargoDetailDtos;
using MultiShop.Cargo.Entities.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();

            return Ok(values.Select(x => _mapper.Map<GetCargoDetailDto>(x)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetByFilter(id);

            var valueToDto = _mapper.Map<GetCargoDetailDto>(value);

            return Ok(valueToDto);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var valueFromDto = _mapper.Map<CargoDetail>(createCargoDetailDto);

            _cargoDetailService.TAdd(valueFromDto);

            return Ok("Kargo Detayı Başarıyla Eklendi.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);

            return Ok("Kargo Detayı Başarıyla Kaldırıldı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var valueFromDto = _mapper.Map<CargoDetail>(updateCargoDetailDto);

            _cargoDetailService.TUpdate(valueFromDto);

            return Ok("Kargo Detayı Bilgisi Başarıyla Güncellendi.");
        }
    }
}
