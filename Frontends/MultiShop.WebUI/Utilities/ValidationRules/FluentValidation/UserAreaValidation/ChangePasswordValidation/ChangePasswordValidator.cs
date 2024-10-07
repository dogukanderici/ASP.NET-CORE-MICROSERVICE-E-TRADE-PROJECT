using FluentValidation;
using MultiShop.WebUI.Areas.User.Models;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UserAreaValidation.ChangePasswordValidation
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordViewModel>
    {
        public ChangePasswordValidator()
        {
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(p => p.NewPasswordConfirm).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(p => p.NewPasswordConfirm).Equal(p => p.NewPassword).WithMessage("Şifreleriniz Eşleşmemektedir.");
        }
    }
}
