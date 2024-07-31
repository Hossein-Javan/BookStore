using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandValidation : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidation()
        {

            RuleFor(r => r.Title).NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(r => r.Slug).NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
