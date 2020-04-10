using myBlog.Models;
using FluentValidation;

namespace myBlog.Validations
{
    public class ArticleTypeValidator:AbstractValidator<ArticleType>
    {
        public ArticleTypeValidator(){
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Makale Tipi Adı Boş Geçilemez");
            
        }
    }
}