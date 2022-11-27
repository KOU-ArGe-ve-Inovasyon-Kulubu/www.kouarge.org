using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class SocialMediaPostDtoValidator : AbstractValidator<SocialMediaPostDto>
    {
        public SocialMediaPostDtoValidator()
        {

            RuleFor(x => x.IsActive).Must(x => x == false || x == true).WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.TeamMemberId).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName} alanı geçerli bir adres olmalı. eg: https://www.kouarge.org")
                .Must(LinkMustBeAUri).WithMessage("{PropertyName} alanı geçerli bir adres olmalı. eg: https://www.kouarge.org"); ;
            RuleFor(x => x.SocaialMediaTypeId).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Token).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");

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
