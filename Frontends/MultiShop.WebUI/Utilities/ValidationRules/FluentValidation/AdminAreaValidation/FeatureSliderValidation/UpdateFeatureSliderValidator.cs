using FluentValidation;
using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.FeatureSliderValidation
{
    public class UpdateFeatureSliderValidator : AbstractValidator<UpdateFeatureSliderDto>
    {
        public UpdateFeatureSliderValidator()
        {
            RuleFor(fs => fs.Title).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz!");
            RuleFor(fs => fs.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz!");
        }
    }
}
