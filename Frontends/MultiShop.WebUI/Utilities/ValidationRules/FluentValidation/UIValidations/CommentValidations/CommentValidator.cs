using FluentValidation;
using MultiShop.Dtos.CommentDtos;
using MultiShop.WebUI.Utilities.Constants;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.UIValidations.CommentValidations
{
    public class CommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CommentValidator()
        {
            RuleFor(c => c.NameSurname).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(c => c.Email).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);
            RuleFor(c => c.CommentDetail).NotEmpty().WithMessage(ValidationConstants.NotEmptyMessage);

            RuleFor(c => c.Email).EmailAddress().WithMessage(ValidationConstants.InValidEmailMessage);
        }
    }
}
