using FluentValidation;
using MultiShop.Dtos.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.ProductImageValidation
{
    public class CreateProductImageValidator : AbstractValidator<CreateProductImageDto>
    {
        public CreateProductImageValidator()
        {
            RuleFor(p => p.ImageUrl1).NotEmpty().WithMessage("Ürün Detay Görsel-1 Alanı Boş Bırakılamaz!");
            RuleFor(p => p.ImageUrl2).NotEmpty().WithMessage("Ürün Detay Görsel-2 Alanı Boş Bırakılamaz!");
            RuleFor(p => p.ImageUrl3).NotEmpty().WithMessage("Ürün Detay Görsel-3 Alanı Boş Bırakılamaz!");
            RuleFor(p => p.ImageUrl4).NotEmpty().WithMessage("Ürün Detay Görsel-4 Alanı Boş Bırakılamaz!");
        }
    }
}
