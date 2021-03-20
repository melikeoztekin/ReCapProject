using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(i => i.CarId).NotEmpty();
            RuleFor(i => i.Date).NotEmpty();
            //RuleFor(i => i.ImagePath).NotEmpty();
        }

    }
}
