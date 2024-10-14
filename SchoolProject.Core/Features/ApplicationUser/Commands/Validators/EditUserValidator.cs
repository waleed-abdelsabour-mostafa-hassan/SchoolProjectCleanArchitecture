using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public EditUserValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            /*RuleFor(x => x.Password)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NoEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.ConfirmPassword)
               .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);
*/
        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
