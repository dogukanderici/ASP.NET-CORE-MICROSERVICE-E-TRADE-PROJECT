using FluentValidation;
using MultiShop.Dtos.CatalogDtos.VendorDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.VendorValidation
{
    public class UpdateVendorValidation : AbstractValidator<UpdateVendorDto>
    {
        public UpdateVendorValidation()
        {
            RuleFor(v => v.VendorName).NotEmpty().WithMessage("Marka Adı Boş Bırakılamaz!");
            RuleFor(v => v.VendorImage).Must(ValidImageFileType).When(v => v.VendorImage != null).WithMessage("Yalnızca .png, jpg ve .jpeg Tipinde Dosya Yüklenebilir!");
        }
        private bool ValidImageFileType(IFormFile imageFile)
        {
            var allowedExtentions = new List<string> { ".png", ".jpg", ".jpeg" };
            var fileExtention = Path.GetExtension(imageFile.FileName).ToLower();

            return allowedExtentions.Contains(fileExtention);
        }
    }
}
