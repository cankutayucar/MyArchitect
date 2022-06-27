using FluentValidation;
using MyArchitect.RequestResponseModels.Category.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArchitect.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("categori adı girilmesi zorunludur.")
                .MaximumLength(30).WithMessage("maximum 30 karakter olmalıdır");
        }
    }
}
