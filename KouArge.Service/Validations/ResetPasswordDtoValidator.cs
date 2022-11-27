using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen mail adresinizi giriniz.").WithErrorCode("Email")
           .EmailAddress().WithErrorCode("Email").WithMessage("Lütfen geçerli bir mail adresi giriniz.");
        }
    }
}
