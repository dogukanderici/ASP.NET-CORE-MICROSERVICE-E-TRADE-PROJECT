using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericServices;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService : IGenericService<Contact, ResultContactDto, CreateContactDto, UpdateContactDto, GetByIdContactDto>
    {
    }
}
