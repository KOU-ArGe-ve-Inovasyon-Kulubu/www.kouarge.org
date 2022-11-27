using FluentValidation;
using KouArge.Core.DTOs.UpdateDto;

namespace KouArge.Service.Validations.Update
{
    public class RedirectUpdateDtoValidator : AbstractValidator<RedirectUpdateDto>
    {
        public RedirectUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen {PropertyName} giriniz.").MinimumLength(2).WithMessage("{PropertyName} en az 2 karakter olmalıdır.");
            RuleFor(x => x.Count).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} 0 dan büyük olmalıdır.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("{PropertyName} alanı gerekldir.").NotEmpty().WithMessage("{PropertyName} alanı gerekldir.");
            //RuleFor(x => x.IsActive).InclusiveBetween(0, 1).WithMessage("{PropertyName} 0(Pasive) veya 1(Active) olmalıdır.");
            RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName} geçerli bir adres olmalı. eg: https://www.kouarge.org")
                .Must(LinkMustBeAUri)
           .WithMessage("{PropertyName} geçerli bir adres olmalı. eg: https://www.kouarge.org");
        }

        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }

    }
}
