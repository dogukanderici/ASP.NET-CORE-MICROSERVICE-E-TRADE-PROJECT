using AutoMapper;
using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderService
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IFeatureSliderDal _featureSliderDal;
        private readonly IMapper _mapper;

        public FeatureSliderService(IFeatureSliderDal featureSliderDal, IMapper mapper)
        {
            _featureSliderDal = featureSliderDal;
            _mapper = mapper;
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllDataAsync()
        {
            var values = await _featureSliderDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdFeatureSliderDto> GetDataAsync(string id)
        {
            var value = await _featureSliderDal.GetDataAsync(fs => fs.FeatureSliderId == id);

            return value;
        }

        public async Task ChangeFeatureSliderStatusAsync(string id, bool status)
        {
            var value = await _featureSliderDal.GetDataAsync(fs => fs.FeatureSliderId == id);

            if (value != null)
            {
                value.IsActive = status;

                var updatedValueToDto = _mapper.Map<UpdateFeatureSliderDto>(value);

                await _featureSliderDal.UpdateData(fs => fs.FeatureSliderId == id, updatedValueToDto);
            }
        }

        public async Task CreateDataAsync(CreateFeatureSliderDto createDto)
        {
            await _featureSliderDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _featureSliderDal.DeleteData(fs => fs.FeatureSliderId == id);
        }

        public async Task UpdateDataAsync(UpdateFeatureSliderDto updateDto)
        {
            await _featureSliderDal.UpdateData(fs => fs.FeatureSliderId == updateDto.FeatureSliderId, updateDto);
        }
    }
}
