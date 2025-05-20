using FluentValidation;
using Marketplacenew.Models;

namespace Marketplacenew.Models.Validators
{
    public class tenantModelValidator : AbstractValidator<tenantModel>
    {
        public tenantModelValidator()
        {
            When(model => model.craftmyapp_actionmethodname == "Create_tenant", () =>
            {
                RuleFor(m => m.businessname)
                    .NotEmpty().WithMessage("Business  Name is required")
                    .MaximumLength(50).WithMessage("The allowed length of Business  Name is 50 characters or fewer");
                RuleFor(m => m.businesstype)
                    .NotEmpty().WithMessage("Business Type is required");
                RuleFor(m => m.natureofbusiness)
                    .NotEmpty().WithMessage("Nature of Business is required");
                RuleFor(m => m.businessemail)
                    .NotEmpty().WithMessage("Business  Email is required")
                    .MaximumLength(128).WithMessage("The allowed length of Business  Email is 128 characters or fewer")
                    .EmailAddress();
                RuleFor(m => m.businessphone)
                    .NotEmpty().WithMessage("Business  Phone is required")
                    .MaximumLength(20).WithMessage("The allowed length of Business  Phone is 20 characters or fewer ");
                RuleFor(m => m.numberofemployees)
                    .LessThanOrEqualTo(99999999).WithMessage("Number of  Employees should be LessThanOrEqualTo 99999999");
            });

            When(model => model.craftmyapp_actionmethodname == "Update_tenant", () =>
            {
                RuleFor(m => m.businessname)
                    .NotEmpty().WithMessage("Business  Name is required")
                    .MaximumLength(50).WithMessage("The allowed length of Business  Name is 50 characters or fewer");
                RuleFor(m => m.businesstype)
                    .NotEmpty().WithMessage("Business Type is required");
                RuleFor(m => m.natureofbusiness)
                    .NotEmpty().WithMessage("Nature of Business is required");
                RuleFor(m => m.businessemail)
                    .NotEmpty().WithMessage("Business  Email is required")
                    .MaximumLength(128).WithMessage("The allowed length of Business  Email is 128 characters or fewer")
                    .EmailAddress();
                RuleFor(m => m.businessphone)
                    .NotEmpty().WithMessage("Business  Phone is required")
                    .MaximumLength(20).WithMessage("The allowed length of Business  Phone is 20 characters or fewer ");
                RuleFor(m => m.numberofemployees)
                    .LessThanOrEqualTo(99999999).WithMessage("Number of  Employees should be LessThanOrEqualTo 99999999");
            });
        }
    }
}
