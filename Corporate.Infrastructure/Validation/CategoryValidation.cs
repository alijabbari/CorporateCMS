using Corporate.Model.Dtoes;
using FluentValidation;
namespace Corporate.Infrastructure.Validation
{
    public class CategoryValidation : AbstractValidator<CategoryDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.MetaDescription).MaximumLength(350).WithMessage("توضیحات متا باید کمتر از ۳۵۰ کاراکتر باشد");
            RuleFor(x => x.Metakeword).MaximumLength(500).WithMessage("کلمات کلیدی نباید بیش از ۵۰۰ کاراکتر باشد");
            RuleFor(x => x.Name).NotEmpty().WithMessage("نام دسته را وارد نمایید").NotNull().Length(4, 250).WithMessage("حداقل طول نام دسته ۴ و حداکثر ۲۵۰ کاراکتر مجاز میباشد");
            RuleFor(x => x.ShortDescription).Length(0, 200).WithMessage("توضیحات کوتاه باید حداکثر ۲۰۰ کاراکتر باشد");
        }
    }
}
