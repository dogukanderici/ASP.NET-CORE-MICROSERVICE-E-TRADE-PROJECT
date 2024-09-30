﻿using FluentValidation;
using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.FeatureSliderValidation
{
    public class CreateFeatureSliderValidator : AbstractValidator<CreateFeatureSliderDto>
    {
        public CreateFeatureSliderValidator()
        {
            RuleFor(fs => fs.Title).NotEmpty().WithMessage("Başlık Alanı Boş Bırakılamaz!");
            RuleFor(fs => fs.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz!");
            RuleFor(fs => fs.Image).NotEmpty().WithMessage("Görsel Alanı Boş Bırakılamaz!");
        }
    }
}
