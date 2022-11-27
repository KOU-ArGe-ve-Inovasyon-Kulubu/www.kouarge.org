using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class SocialMediaTypeDtoValidator : AbstractValidator<SocialMediaTypeDto>
    {
        public SocialMediaTypeDtoValidator()
        {
            RuleFor(x => x.IsActive).Must(x => x == false || x == true).WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Icon).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
        }
    }
}
