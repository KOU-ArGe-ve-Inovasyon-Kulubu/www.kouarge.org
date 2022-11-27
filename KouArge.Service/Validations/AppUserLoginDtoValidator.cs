using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {

            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen geçerli bir email adresi giriniz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.Password).NotNull().WithMessage("Lütfen şifrenizi giriniz.").MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.")
          .Matches("[A-Z]").WithMessage("Lütfen şifrenizi giriniz.")
          .Matches("[a-z]").WithMessage("Lütfen şifrenizi giriniz.")
          .Matches("[0-9]").WithMessage("Lütfen şifrenizi giriniz.")
          .Matches("[^a-zA-Z0-9]").WithMessage("Lütfen şifrenizi giriniz.");
        }
    }
}
