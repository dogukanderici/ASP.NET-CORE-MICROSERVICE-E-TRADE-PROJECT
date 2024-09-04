using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ServiceStandardDtos;
using MultiShop.Catalog.Services.ServiceStandardServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStandardsController : ControllerBase
    {
        private readonly IServiceStandardService _serviceStandardService;

        public ServiceStandardsController(IServiceStandardService serviceStandardService)
        {
            _serviceStandardService = serviceStandardService;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceStandardList()
        {
            var values = await _serviceStandardService.GetAllDataAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicestandardById(string id)
        {
            var value = await _serviceStandardService.GetDataAsync(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceStandard(CreateServiceStandardDto createServiceStandardDto)
        {
            await _serviceStandardService.CreateDataAsync(createServiceStandardDto);

            return Ok("Servis Standardı Başarıyla Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateServiceStandard(UpdateServiceStandardDto updateServiceStandardDto)
        {
            await _serviceStandardService.UpdateDataAsync(updateServiceStandardDto);

            return Ok("Servis Standartları Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteServiceStandard(string id)
        {
            await _serviceStandardService.DeleteDataAsync(id);

            return Ok("Servis Standardı Başarıyla Silindi.");
        }

    }
}
