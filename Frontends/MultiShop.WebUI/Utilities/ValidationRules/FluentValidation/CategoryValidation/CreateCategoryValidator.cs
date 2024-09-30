using FluentValidation;
using MultiShop.Dtos.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.CategoryValidation
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz!");
            RuleFor(c => c.CategoryImage).NotEmpty().WithMessage("Kategori Görseli Eklenmesi Zorunludur!");
        }
    }
}
