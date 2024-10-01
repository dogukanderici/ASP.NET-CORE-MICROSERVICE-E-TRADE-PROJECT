using FluentValidation;
using MultiShop.Dtos.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AboutValidation
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(a => a.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz!");
            RuleFor(a => a.Address).NotEmpty().WithMessage("Adres Alanı Boş Bırakılamaz!");
            RuleFor(a => a.Telefon).NotEmpty().WithMessage("Telefon Bilgisi Boş Bırakılamaz!");
            RuleFor(a => a.Mail).NotEmpty().WithMessage("E-Posta Alanı Boş Bırakılamaz!");
            RuleFor(a => a.Mail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz!");
            RuleFor(a => a.Telefon).Matches(@"^\+90(\s?[0-9]{3}\s?[0-9]{3}\s?[0-9]{2}\s?[0-9]{2})$").WithMessage("Telefon Numarası +90 ile Başlamalı ve Rakamlardan Oluşmalıdır!");
        }
    }
}
