using MultiShop.Catalog.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactService(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task CreateDataAsync(CreateContactDto createDto)
        {
            await _contactDal.CreateData(createDto);
        }

        public async Task DeleteDataAsync(string id)
        {
            await _contactDal.DeleteData(c => c.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllDataAsync()
        {
            var values = await _contactDal.GetAllDataAsync();

            return values;
        }

        public async Task<GetByIdContactDto> GetDataAsync(string id)
        {
            var value = await _contactDal.GetDataAsync(c => c.ContactId == id);

            return value;
        }

        public async Task UpdateDataAsync(UpdateContactDto updateDto)
        {
            await _contactDal.UpdateData(c => c.ContactId == updateDto.ContactId, updateDto);
        }
    }
}
