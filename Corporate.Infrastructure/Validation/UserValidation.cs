using Corporate.Domain.Entities;
using FluentValidation;

namespace Corporate.Infrastructure.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(r => r.Email).EmailAddress().NotNull().WithMessage($"ایمیل بایدمقدار دهی شود");
            RuleFor(r => r.SerialNumber).MaximumLength(450);
            RuleFor(r => r.Username).NotNull().WithMessage("نام کاربری را وارد نمایید")
                .NotEmpty().WithMessage("نلم کاربری باید شامل حروف و اعداد و کاراکترهای مشخص شده باشد").MinimumLength(5).MinimumLength(4).MaximumLength(450);
            RuleFor(r => r.Password).NotNull().WithMessage("پسوورد را وارد نمایید")
                .NotEmpty().WithMessage("پسوورد باید شامل حروف و اعداد و کاراکترهای مشخص شده باشد").MinimumLength(5).MaximumLength(450);
        }
    }
}
