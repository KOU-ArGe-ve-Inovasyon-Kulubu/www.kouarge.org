using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidator()
        {
            RuleFor(x => x.OldPassword).NotNull().WithMessage("Lütfen şifrenizi giriniz.").WithErrorCode("OldPassword")
               .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.").WithErrorCode("OldPassword")
               .Matches("^(?=.*?[A-Z ÜÖİŞ])(?=.*?[a-z şöüı])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{1,}$")
               .WithMessage("Şifrenizde en az bir adet büyük karakter, bir adet sayi ve bir adet özel karakter bulunmalıdır.");

            RuleFor(x => x.NewPassword).NotNull().WithMessage("Lütfen şifrenizi giriniz.").WithErrorCode("NewPassword")
               .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.").WithErrorCode("NewPassword")
               .Matches("^(?=.*?[A-Z ÜÖİŞ])(?=.*?[a-z şöüı])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{1,}$")
               .WithMessage("Şifrenizde en az bir adet büyük karakter, bir adet sayi ve bir adet özel karakter bulunmalıdır.");

            RuleFor(x => x.Token).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");

        }
    }
}
