using FluentValidation;
using MultiShop.WebUI.Areas.User.Models;
using MultiShop.WebUI.Utilities.Constants;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UserAreaValidation.ChangePersonalInfoValidation
{
    public class ChangePersonalInfoValidator : AbstractValidator<ChangePersonalInfoViewModel>
    {
        public ChangePersonalInfoValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(i => i.Surname).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(i => i.Email).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);

            RuleFor(i => i.Email).EmailAddress().WithMessage(ValidationConstants.InValidEmailMessage);
        }
    }
}
