using FluentValidation;
using KouArge.Core.DTOs;

namespace KouArge.Service.Validations
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} alanı gerekldir.").NotEmpty().WithMessage("{PropertyName} alanı gerekldir.");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} alanı gerekldir.").NotEmpty().WithMessage("{PropertyName} alanı gerekldir.");
            RuleFor(x => x.FacultyId).NotEmpty().WithMessage("{PropertyName} alanı gerekldir.")
                .NotNull().WithMessage("{PropertyName} alanı gerekldir.")
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 0 dan büyük olmalıdır.");
        }
    }
}
