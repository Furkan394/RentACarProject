﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator: AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(cl=>cl.ColorName).NotEmpty();
            RuleFor(cl=>cl.ColorName).MinimumLength(2);
        }
    }
}
