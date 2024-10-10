using FluentValidation;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.WebUI.Utilities.Constants;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UIValidations.LoginRegisterValidations
{
    public class LoginValidator : AbstractValidator<SignInDto>
    {
        public LoginValidator()
        {
            RuleFor(s => s.Username).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(s => s.Password).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
        }
    }
}
