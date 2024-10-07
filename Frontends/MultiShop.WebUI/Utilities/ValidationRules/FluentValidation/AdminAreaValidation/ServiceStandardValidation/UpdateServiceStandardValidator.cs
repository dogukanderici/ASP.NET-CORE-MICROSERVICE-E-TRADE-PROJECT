using FluentValidation;
using MultiShop.Dtos.CatalogDtos.ServiceStandardDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.ServiceStandardValidation
{
    public class UpdateServiceStandardValidator : AbstractValidator<UpdateServiceStandardDto>
    {
        public UpdateServiceStandardValidator()
        {
            RuleFor(ss => ss.ServiceStandardName).NotEmpty().WithMessage("Servis Standardı Adı Alanı Boş Bırakılamaz!");
            RuleFor(ss => ss.ServiceStandardIcon).NotEmpty().WithMessage("Servis Standardı İkonu Alanı Boş Bırakılamaz!");
        }
    }
}
