using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).NotEmpty().WithMessage("Bu alan boş geçilemez ve 250 karakterden fazla yazılamaz!");
            RuleFor(p => p.Description).MaximumLength(250);
            RuleFor(p => p.ColorId).GreaterThanOrEqualTo(1);
            RuleFor(p => p.BrandId).GreaterThanOrEqualTo(1);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(1);
            RuleFor(p => p.ModelYear).NotEmpty();
        }
    }
}
