using MultiShop.Dtos.CatalogDtos.AboutDtos;
using MultiShop.Dtos.CatalogDtos.ContactDtos;
using MultiShop.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService : IGenericService<ResultContactDto, CreateContactDto, ResultContactDto>
    {
    }
}
