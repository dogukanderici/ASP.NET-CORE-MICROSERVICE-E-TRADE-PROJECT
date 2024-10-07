using FluentValidation;
using MultiShop.Dtos.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.ProductDetailValidation
{
    public class UpdateProductDetailValidator : AbstractValidator<UpdateProductDetailDto>
    {
        public UpdateProductDetailValidator()
        {
            RuleFor(p => p.ProductInfo).NotEmpty().WithMessage("Ürün Bilgi Alanı Boş Bırakılamaz!");
            RuleFor(p => p.ProductDescription).NotEmpty().WithMessage("Ürün Açıklaması Alanı Boş Bırakılamaz!");
        }
    }
}
