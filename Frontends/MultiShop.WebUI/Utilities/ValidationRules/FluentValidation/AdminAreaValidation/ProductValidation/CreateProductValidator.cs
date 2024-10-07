using FluentValidation;
using MultiShop.Dtos.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.ProductValidation
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün Adı Alanı Boş Bırakılamaz!");
            RuleFor(p => p.CategoryID).NotEmpty().WithMessage("Ürün Kategorisi Alanı Boş Bırakılamaz!");
            RuleFor(p => p.ProductPrice).NotEmpty().WithMessage("Ürün Fiyatı ALanı Boş Bırakılamaz!");
            RuleFor(p => p.ProductPrice).GreaterThanOrEqualTo(1).WithMessage("Ürün Fiyatı 0'dan Büyük Girilmelidir!");
            RuleFor(p => p.ProductImage).NotEmpty().WithMessage("Ürün Ana Görsel Alanı Boş Bırakılamaz!");
            RuleFor(p => p.ProductDescription).NotEmpty().WithMessage("Ürün Açıklaması Alanı Boş Bırakılamaz!");
            RuleFor(p => p.ProductDescription).MinimumLength(10).WithMessage("Üürn Açıklaması En Az 10 Karakter Olmalıdır!");

        }
    }
}
