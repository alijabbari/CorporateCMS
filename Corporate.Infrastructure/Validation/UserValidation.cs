using System;
using System.Collections.Generic;
using System.Text;
using Corporate.Domain.Entities;
using FluentValidation;

namespace Corporate.Infrastructure.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.SerialNumber).MaximumLength(450);
            RuleFor(r => r.Username).MaximumLength(450);
            RuleFor(r => r.Password).MaximumLength(450);
        }
    }
}
