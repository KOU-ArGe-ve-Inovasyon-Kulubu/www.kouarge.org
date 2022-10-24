using FluentValidation;
using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Validations
{
    public class AppUserRegisterDtoValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen adınızı giriniz.")
                .MinimumLength(2).WithMessage("Lütfen adınızı giriniz.");

            RuleFor(x => x.Surname).NotNull().WithMessage("Lütfen soyadınızı giriniz.")
                .MinimumLength(2).WithMessage("Lütfen adınızı giriniz.");

            int i = 0;
            RuleFor(x => x.StudentNo).NotNull().WithMessage("Lütfen okul numaranızı giriniz.")
                .Length(9, 9).WithMessage("Lütfen okul numaranızı giriniz.")
                .Must(x => int.TryParse(x, out i)).WithMessage("Lütfen okul numaranızı giriniz.")
                .Matches(@"^([1-2]\d{2,}|[0-9]\d)$").WithMessage("Lütfen okul numaranızı giriniz.");
            //TODO: tekrar düzenle

            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Lütfen telefon numaranızı giriniz.")
                .Length(10, 10).WithMessage("Lütfen geçerli bir telefon numarası giriniz.")
                .Matches(@"^(5(\d{9}))$").WithMessage("Lütfen geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.FacultyId).NotNull().WithMessage("Lütfen fakültenizi seçiniz.");

            RuleFor(x => x.KVKK).Equal(true).WithMessage("Lütfen fakültenizi seçiniz.");

            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Lütfen bölümünüzü seçiniz.")
                .NotNull().WithMessage("Lütfen bölümünüzü seçiniz.");

            RuleFor(x => x.Year).InclusiveBetween(0, 7).WithMessage("Lütfen sınıfınızı seçiniz.")
               .NotNull().WithMessage("Lütfen sınıfınızı seçiniz.");

            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen mail adresinizi giriniz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");


            RuleFor(x => x.Password).NotNull().WithMessage("Lütfen şifrenizi giriniz.")
                .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.")
                .Matches("^(?=.*?[A-Z ÜÖİŞ])(?=.*?[a-z şöüı])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{1,}$")
                .WithMessage("Şifrenizde en az bir adet büyük karakter, bir adet sayi ve bir adet özel karakter bulunmalıdır.");


            //.Matches("[a-z]").WithMessage("Şifrenizde en 1 karakter küçük olmalı.")
            //.Matches("[0-9]").WithMessage("Şifrenizde en 1 sayi olmalı.")
            //.Matches("[^a-zA-Z0-9]").WithMessage("Şifrenizde en 1 özel karakter olmalı.");

        }
    }
}
