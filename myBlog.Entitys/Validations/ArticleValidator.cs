using myBlog.Models;
using FluentValidation;

namespace myBlog.Validations
{
    public class ArticleValidator:AbstractValidator<Article>
    {
        public ArticleValidator(){
            RuleFor(p=>p.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(p=>p.Content).NotEmpty().WithMessage("İçerik Boş Geçilemez");
        }
    }
}