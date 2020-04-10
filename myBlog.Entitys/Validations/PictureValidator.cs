using myBlog.Models;
using FluentValidation;

namespace myBlog.Validations
{
    public class PictureValidator:AbstractValidator<Picture>
    {
        public PictureValidator(){
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Resim adı boş Geçilemez");
            RuleFor(p=>p.SmallPicture).NotEmpty().WithMessage("Küçük resim boş Geçilemez");
        }
    }
}