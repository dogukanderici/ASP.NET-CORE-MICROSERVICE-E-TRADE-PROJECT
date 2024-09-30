using FluentValidation;
using MultiShop.Dtos.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.OfferDiscountValidation
{
    public class UpdateOfferDiscountValidator : AbstractValidator<UpdateOfferDiscountDto>
    {
        public UpdateOfferDiscountValidator()
        {
            RuleFor(od => od.OfferDiscountTitle).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz!");
            RuleFor(od => od.OfferDiscountSubTitle).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz!");
            RuleFor(od => od.OfferDiscountSubImage).Must(ValidImageFileType).When(od => od.OfferDiscountSubImage != null).WithMessage("Yalnızca .png, .jpg ve .jpeg Tipindeki Dosyaları Yükleyebilirsiniz!");
        }

        private bool ValidImageFileType(IFormFile imageFile)
        {
            var allowedExtentions = new List<string> { ".png", ".jpg", ".jpeg" };
            var imageFileExtention = Path.GetExtension(imageFile.FileName).ToLower();

            return allowedExtentions.Contains(imageFileExtention);
        }
    }
}
