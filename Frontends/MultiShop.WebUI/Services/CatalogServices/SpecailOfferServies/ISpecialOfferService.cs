using MultiShop.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.GenericServices;

namespace MultiShop.WebUI.Services.CatalogServices.SpecailOfferServies
{
    public interface ISpecialOfferService : IGenericService<ResultSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto>
    {
    }
}
