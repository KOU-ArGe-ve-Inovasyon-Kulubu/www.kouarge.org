using FluentValidation;
using KouArge.Core.DTOs.UpdateDto;

namespace KouArge.Service.Validations.Update
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");

            RuleFor(x => x.IsActive).Must(x => x == false || x == true).WithMessage("{PropertyName} alanı boş geçilemez.");

            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen adınızı giriniz.")
                 .MinimumLength(2).WithMessage("Lütfen adınızı giriniz.");

            RuleFor(x => x.Surname).NotNull().WithMessage("Lütfen soyadınızı giriniz.")
                .MinimumLength(2).WithMessage("Lütfen adınızı giriniz.");

            int i = 0;
            RuleFor(x => x.StudentNumber).NotNull().WithMessage("Lütfen okul numaranızı giriniz.")
                .Length(9, 9).WithMessage("Lütfen okul numaranızı giriniz.")
                .Must(x => int.TryParse(x, out i)).WithMessage("Lütfen okul numaranızı giriniz.")
                .Matches(@"^([1-2]\d{2,}|[0-9]\d)$").WithMessage("Lütfen okul numaranızı giriniz.");
            //TODO: tekrar düzenle

            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Lütfen telefon numaranızı giriniz.")
                .Length(10, 10).WithMessage("Lütfen geçerli bir telefon numarası giriniz.")
                .Matches(@"^(5(\d{9}))$").WithMessage("Lütfen geçerli bir telefon numarası giriniz.");


            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Lütfen bölümünüzü seçiniz.")
                .NotNull().WithMessage("Lütfen bölümünüzü seçiniz.");

            RuleFor(x => x.Year).InclusiveBetween(0, 7).WithMessage("Lütfen sınıfınızı seçiniz.")
               .NotNull().WithMessage("Lütfen sınıfınızı seçiniz.");

            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen mail adresinizi giriniz.").WithErrorCode("Email")
                .EmailAddress().WithErrorCode("Email").WithMessage("Lütfen geçerli bir mail adresi giriniz.");

            RuleFor(x => x.AccessToken).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");

            RuleFor(x => x.NotificationId).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");

        }
    }
}
