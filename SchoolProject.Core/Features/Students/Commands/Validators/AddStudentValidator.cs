using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {

        #region Fields
        private readonly IStudentServices _studentServices;
        private readonly IDepartmentServices _departmentServices;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion


        #region Constructors
        public AddStudentValidator(IStudentServices studentServices,
                                   IStringLocalizer<SharedResources> localizer,
                                   IDepartmentServices departmentServices)
        {
            _studentServices = studentServices;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _departmentServices = departmentServices;
        }
        #endregion


        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            RuleFor(x => x.AddressAr)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
               .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);
            RuleFor(x => x.AddressEn)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
               .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameArExists(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
                .MustAsync(async (Key, CancellationToken) => !await _studentServices.IsNameEnExists(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => await _departmentServices.IsDepartmentIdExists(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}
