using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(k => k.ColorName).NotEmpty();
            RuleFor(k => k.ColorName).MinimumLength(2);
        }

    }
}
