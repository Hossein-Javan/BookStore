using Common.Application.Validation;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandValidation:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation() 
        {

            RuleFor(r => r.Title).NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(r => r.Slug).NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
