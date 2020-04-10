using myBlog.Models;
using FluentValidation;

namespace myBlog.Validations
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
        }
    }
}