using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).Must(ContainAt).WithMessage("E-mail adresi '@' içermeli.");
            RuleFor(u => u.Password).MinimumLength(6);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).NotNull();
        }

        private bool ContainAt(string arg)
        {
            return arg.Contains("@") && arg.Contains(".");
        }
    }
}
