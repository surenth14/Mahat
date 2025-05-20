using FluentValidation;

namespace Marketplacenew.Models.Validators
{
    public class usersModelValidator : AbstractValidator<usersModel>
    {
        public usersModelValidator()
        {
            When(model => model.craftmyapp_actionmethodname == "Register_Profile", () =>
            {
                RuleFor(m => m.firstname)
                    .NotEmpty().WithMessage("First Name is required")
                    .MaximumLength(50).WithMessage("The allowed length of First Name is 50 characters or fewer");
                RuleFor(m => m.username)
                    .NotEmpty().WithMessage("UserName is required")
                    .MinimumLength(1).WithMessage("The minimum length of UserName is 1 characters ")
                    .MaximumLength(150).WithMessage("The allowed length of UserName is 150 characters or fewer");
                RuleFor(m => m.userpassword)
                    .NotEmpty().WithMessage("User Password is required")
                    .MaximumLength(128).WithMessage("The allowed length of User Password is 128 characters or fewer");
                RuleFor(m => m.emailid)
                    .NotEmpty().WithMessage("Email ID is required")
                    .MaximumLength(128).WithMessage("The allowed length of Email ID is 128 characters or fewer")
                    .EmailAddress();
                RuleFor(m => m.mobilenumber)
                    .NotEmpty().WithMessage("Mobile Number is required")
                    .MaximumLength(20).WithMessage("The allowed length of Mobile Number is 20 characters or fewer ");
                RuleFor(m => m.userrole)
                    .NotEmpty().WithMessage("User Role is required");
            });

            When(model => model.craftmyapp_actionmethodname == "Update_Profile", () =>
            {
                RuleFor(m => m.firstname)
                    .NotEmpty().WithMessage("First Name is required")
                    .MaximumLength(50).WithMessage("The allowed length of First Name is 50 characters or fewer");
                RuleFor(m => m.username)
                    .NotEmpty().WithMessage("UserName is required")
                    .MinimumLength(1).WithMessage("The minimum length of UserName is 1 characters ")
                    .MaximumLength(150).WithMessage("The allowed length of UserName is 150 characters or fewer");
                RuleFor(m => m.emailid)
                    .NotEmpty().WithMessage("Email ID is required")
                    .MaximumLength(128).WithMessage("The allowed length of Email ID is 128 characters or fewer")
                    .EmailAddress();
                RuleFor(m => m.mobilenumber)
                    .NotEmpty().WithMessage("Mobile Number is required")
                    .MaximumLength(20).WithMessage("The allowed length of Mobile Number is 20 characters or fewer ");
                RuleFor(m => m.userrole)
                    .NotEmpty().WithMessage("User Role is required");
            });

            RuleForEach(x => x.alloweddevices).SetValidator(new users_alloweddevicesModelValidator());
        }
    }

    public class users_alloweddevicesModelValidator : AbstractValidator<users_alloweddevicesModel>
    {
        public users_alloweddevicesModelValidator()
        {
            When(model => model.craftmyapp_actionmethodname == "Register_Profile", () => { });
            When(model => model.craftmyapp_actionmethodname == "Update_Profile", () => { });
        }
    }
}
