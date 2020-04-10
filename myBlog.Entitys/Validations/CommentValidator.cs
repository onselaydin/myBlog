using myBlog.Models;
using FluentValidation;

namespace myBlog.Validations
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator(){
            
            RuleFor(p=>p.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(p=>p.Content).NotEmpty().WithMessage("İçerik Boş Geçilemez");
        }
    }
}