using FluentValidation;
using MultiShop.Dtos.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.SpecailOfferValidation
{
    public class UpdateSpecialOfferValidator : AbstractValidator<UpdateSpecialOfferDto>
    {
        public UpdateSpecialOfferValidator()
        {
            RuleFor(s => s.Title).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz!");
            RuleFor(s => s.SubTitle).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz!");
        }
    }
}
