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
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen adınızı giriniz").MinimumLength(2);
            RuleFor(x => x.Surname).NotNull().WithMessage("Lütfen soyadınızı giriniz").MinimumLength(2);

            int i = 0;
            RuleFor(x => x.StudentNo).Length(9, 9).WithMessage("Lütfen okul numaranızı giriniz.").Must(x => int.TryParse(x, out i)).WithMessage("Lütfen okul numaranızı giriniz.");

            RuleFor(x => x.DepartmentId).InclusiveBetween(1, int.MaxValue).WithMessage("Lütfen bölümünüzü seçinizi").NotNull().WithMessage("Lütfen bölümünüzü seçinizi");

            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen geçerli bir email adresi giriniz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");


            RuleFor(x => x.Password).NotNull().WithMessage("Lütfe şifrenizi giriniz.").MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.")
            .Matches("[A-Z]").WithMessage("Şifrenizde en 1 karakter büyük olmalı.")
            .Matches("[a-z]").WithMessage("Şifrenizde en 1 karakter küçük olmalı.")
            .Matches("[0-9]").WithMessage("Şifrenizde en 1 sayi olmalı.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Şifrenizde en 1 özel karakter olmalı.");

        }
    }
}
