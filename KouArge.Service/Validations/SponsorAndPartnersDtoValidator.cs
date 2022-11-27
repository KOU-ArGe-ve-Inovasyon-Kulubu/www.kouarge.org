using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class SponsorAndPartnersDtoValidator : AbstractValidator<SponsorAndPartnersDto>
    {
        public SponsorAndPartnersDtoValidator()
        {
            RuleFor(x => x.IsActive).Must(x => x == false || x == true).WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.ImgUrl).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Title).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.StartDate).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName} geçerli bir adres olmalı. eg: http://www.kouarge.org")
                        .Must(LinkMustBeAUri).WithMessage("{PropertyName} geçerli bir adres olmalı. eg: http://www.kouarge.org");
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
