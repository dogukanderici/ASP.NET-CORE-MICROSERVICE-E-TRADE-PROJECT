using FluentValidation;
using MultiShop.Dtos.IdentityDtos;
using MultiShop.WebUI.Utilities.Constants;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UIValidations.LoginRegisterValidations
{
    public class RegisterValidator : AbstractValidator<CreateRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Username).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(r => r.Email).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(r => r.Name).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(r => r.Surname).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(r => r.Password).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(r => r.ConfirmPassword).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);

            RuleFor(r => r.Email).EmailAddress().WithMessage(ValidationConstants.InValidEmailMessage);
            RuleFor(r => r.Password).Equal(r => r.ConfirmPassword).WithMessage(ValidationConstants.PasswordNotSame);
        }
    }
}
