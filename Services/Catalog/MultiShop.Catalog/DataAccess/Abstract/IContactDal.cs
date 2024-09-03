using MultiShop.Catalog.Core.DataAccess.Abstract;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DataAccess.Abstract
{
    public interface IContactDal : IRepositoryBase<Contact, ResultContactDto, CreateContactDto, UpdateContactDto, GetByIdContactDto>
    {
    }
}
