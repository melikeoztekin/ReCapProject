using Core.Entities.Concrete;
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
        }

        private bool ContainAt(string arg)
        {
            return arg.Contains("@") && arg.Contains(".");
        }
    }
}
