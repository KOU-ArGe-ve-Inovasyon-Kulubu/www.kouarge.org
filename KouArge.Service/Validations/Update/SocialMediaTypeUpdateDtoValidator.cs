using FluentValidation;
using KouArge.Core.DTOs.UpdateDto;

namespace KouArge.Service.Validations.Update
{
    public class SocialMediaTypeUpdateDtoValidator : AbstractValidator<SocialMediaTypeUpdateDto>
    {
        public SocialMediaTypeUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.IsActive).Must(x => x == false || x == true).WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Icon).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
        }


    }
}
