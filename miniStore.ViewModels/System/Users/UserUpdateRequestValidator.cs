using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniStore.ViewModels.System.Users
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
      
            public UserUpdateRequestValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
                    .MaximumLength(200).WithMessage("First name can not over 200 characters");

                RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                    .MaximumLength(200).WithMessage("Last name can not over 200 characters");

                RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");

                RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                    .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                    .WithMessage("Email format not match");

                RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");

            }
    }
}
