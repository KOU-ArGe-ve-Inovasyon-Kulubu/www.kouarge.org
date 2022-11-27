using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class RedirectDtoValidator : AbstractValidator<RedirectDto>
    {
        public RedirectDtoValidator()
        {
            //RuleFor(x => x.Id).NotNull().WithMessage("Lütfen {PropertyName} giriniz.").MinimumLength(5).WithMessage("{PropertyName} en az 5 karakter olmalıdır.");
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen {PropertyName} giriniz.").MinimumLength(2).WithMessage("{PropertyName} en az 2 karakter olmalıdır.");
            RuleFor(x => x.Count).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} 0 dan büyük olmalıdır.");
            RuleFor(x => x.IsActive).NotNull().WithMessage("{PropertyName} alanı gerekldir.").NotEmpty().WithMessage("{PropertyName} alanı gerekldir.");
            //RuleFor(x=>x.IsActive).InclusiveBetween(0,1).WithMessage("{PropertyName} 0(Pasive) veya 1(Active) olmalıdır.");
            RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName} geçerli bir adres olmalı. eg: https://www.kouarge.org")
           //.Matches(@"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[a-z]+(\[\?%&=]*)?")
           //.WithMessage("'{PropertyName}' geçerli bir adres olmalı. eg: http://www.kouarge.org");

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
