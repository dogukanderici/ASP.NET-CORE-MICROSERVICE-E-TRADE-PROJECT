using FluentValidation;
using MultiShop.Dtos.CommentDtos;

namespace MultiShop.WebUI.Utilities.ValidationRules.FluentValidation.AdminAreaValidation.CommentValidation
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentValidator()
        {
            RuleFor(c => c.NameSurname).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(c => c.Rating).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(c => c.CreatedDate).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(c => c.CommentDetail).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
        }
    }
}
