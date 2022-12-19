using FluentValidation;
using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Validations
{
    public class GeneralAssemblyApplyPostDtoValidator : AbstractValidator<GeneralAssemblyApplyPostDto>
    {
        public GeneralAssemblyApplyPostDtoValidator()
        {
            int i = 0;
            RuleFor(x => x.StudentNumber).NotNull().WithMessage("Lütfen okul numaranızı giriniz.")
                .Length(9, 9).WithMessage("Lütfen okul numaranızı giriniz.")
                .Must(x => int.TryParse(x, out i)).WithMessage("Lütfen okul numaranızı giriniz.")
                .Matches(@"^([1-2]\d{2,}|[0-9]\d)$").WithMessage("Lütfen okul numaranızı giriniz.");

            RuleFor(x => x.TeamId).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.IsActive).Must(x => x == false || x == true).WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.AppUserId).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.TitleId).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Introducing).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Why).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.SituationDescription).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.AppStatus).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.ApplyTime).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
        }
    }
}
