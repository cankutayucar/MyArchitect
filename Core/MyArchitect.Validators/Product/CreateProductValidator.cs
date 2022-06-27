using FluentValidation;
using MyArchitect.RequestResponseModels.Product.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArchitect.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("ürün adı girilmesi zorunludur")
                .MaximumLength(30).WithMessage("maximum 30 karakter olmalıdır");    
        }
    }
}
