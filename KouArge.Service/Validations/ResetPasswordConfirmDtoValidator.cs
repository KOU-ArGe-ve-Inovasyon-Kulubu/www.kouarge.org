using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class ResetPasswordConfirmDtoValidator : AbstractValidator<ResetPasswordConfirmDto>
    {
        public ResetPasswordConfirmDtoValidator()
        {
            RuleFor(x => x.AppUserId).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Token).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.NewPassword).NotNull().WithMessage("Lütfen şifrenizi giriniz.").WithErrorCode("NewPassword")
               .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.").WithErrorCode("NewPassword")
               .Matches("^(?=.*?[A-Z ÜÖİŞ])(?=.*?[a-z şöüı])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{1,}$")
               .WithMessage("Şifrenizde en az bir adet büyük karakter, bir adet sayi ve bir adet özel karakter bulunmalıdır.");

        }

    }
}
