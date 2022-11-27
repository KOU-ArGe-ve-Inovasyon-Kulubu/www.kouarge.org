using FluentValidation;
using KouArge.Core.DTOs.UpdateDto;

namespace KouArge.Service.Validations.Update
{
    public class GeneralAssemblyApplyUpdateDtoValidator : AbstractValidator<GeneralAssemblyApplyUpdateDto>
    {
        public GeneralAssemblyApplyUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} alanı boş geçilemez.").NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez.");
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
