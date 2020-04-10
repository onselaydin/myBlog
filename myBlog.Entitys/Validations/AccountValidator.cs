using myBlog.Models;
using FluentValidation;

namespace myBlog.Validations
{
    public class AccountValidator:AbstractValidator<Account>
    {
        public AccountValidator(){
            RuleSet("all",()=>{
                 RuleFor(p=>p.Name).NotEmpty().WithMessage("İsim alanı Boş Geçilemez");
                RuleFor(p=>p.Sure_Name).NotEmpty().WithMessage("Soyad Boş Geçilemez");
                RuleFor(p=>p.PasswordHash).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            });
           
        }
    }
}