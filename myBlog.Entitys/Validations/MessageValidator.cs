using myBlog.Models;
using FluentValidation;

namespace myBlog.Validations
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator(){
            RuleFor(p=>p.Msg).NotEmpty().WithMessage("Mesaj Boş Geçilemez");
        }   
    }
}