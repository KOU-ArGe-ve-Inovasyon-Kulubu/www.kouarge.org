using FluentValidation;
using KouArge.Core.DTOs.UpdateDto;

namespace KouArge.Service.Validations.Update
{
    public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} alanı gerekldir.").NotEmpty().WithMessage("{PropertyName} alanı gerekldir.");
            RuleFor(x => x.IsActive).Must(x => x == false || x == true).WithMessage("{PropertyName} alanı boş geçilemez.");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} alanı gerekldir.").NotEmpty().WithMessage("{PropertyName} alanı gerekldir.");
            RuleFor(x => x.FacultyId).NotEmpty().WithMessage("{PropertyName} alanı gerekldir.")
                .NotNull().WithMessage("{PropertyName} alanı gerekldir.")
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 0 dan büyük olmalıdır.");
        }
    }
}
