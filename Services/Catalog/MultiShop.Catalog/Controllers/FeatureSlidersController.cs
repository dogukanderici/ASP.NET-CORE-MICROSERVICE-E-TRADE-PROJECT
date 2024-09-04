using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderService;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllDataAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeatureSlider(string id)
        {
            var value = await _featureSliderService.GetDataAsync(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSldierDto)
        {
            await _featureSliderService.CreateDataAsync(createFeatureSldierDto);

            return Ok("Öne Çıkan Başarıyla Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateDataAsync(updateFeatureSliderDto);

            return Ok("Öne Çıkan Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteDataAsync(id);

            return Ok("öne Çıkan Başarıyla Silindi.");
        }

        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> ChangeStatusFeatureSlider(string id, bool status)
        {
            await _featureSliderService.ChangeFeatureSliderStatusAsync(id, status);

            return Ok("Öne Çıkan Durumu " + (status ? "Aktif" : "Pasif") + " Olarak Güncellendi.");
        }
    }
}
