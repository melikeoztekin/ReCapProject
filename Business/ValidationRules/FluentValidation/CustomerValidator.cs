using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(m => m.CompanyName).NotEmpty();
            RuleFor(m => m.CompanyName).MinimumLength(2);
        }
    }
}
