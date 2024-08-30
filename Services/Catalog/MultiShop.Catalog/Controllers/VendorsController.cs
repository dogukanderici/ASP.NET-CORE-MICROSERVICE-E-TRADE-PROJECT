using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.VendorDtos;
using MultiShop.Catalog.Services.VendorServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> VendorList()
        {
            var values = await _vendorService.GetAllDataAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdVendor(string id)
        {
            var value = await _vendorService.GetDataAsync(id);

            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            await _vendorService.CreateDataAsync(createVendorDto);

            return Ok("Marka Başarıyla Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            await _vendorService.UpdateDataAsync(updateVendorDto);

            return Ok("Marka Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVendor(string id)
        {
            await _vendorService.DeleteDataAsync(id);

            return Ok("Marka Başarıyla Silindi.");
        }
    }
}
