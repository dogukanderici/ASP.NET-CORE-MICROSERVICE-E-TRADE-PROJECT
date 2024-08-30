using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.VendorDtos;

namespace MultiShop.Catalog.Services.VendorServices
{
    public class VendorService : IVendorService
    {
        private readonly IVendorDal _vendorDal;

        public VendorService(IVendorDal vendorDal)
        {
            _vendorDal = vendorDal;
        }

        public async Task CreateDataAsync(CreateVendorDto createDto)
        {
            await _vendorDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _vendorDal.DeleteData(v => v.VendorId == id);
        }

        public async Task<List<ResultVendorDto>> GetAllDataAsync()
        {
            var values = await _vendorDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdVendorDto> GetDataAsync(string id)
        {
            var value = await _vendorDal.GetDataAsync(v => v.VendorId == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateVendorDto updateDto)
        {
            await _vendorDal.UpdateData(v => v.VendorId == updateDto.VendorId, updateDto);
        }
    }
}
