using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidation : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidation()
        {

            RuleFor(r => r.Title).NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(r => r.Slug).NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
