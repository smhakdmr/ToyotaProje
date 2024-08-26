using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş bırakılamaz.").EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.")
                  .MinimumLength(5).WithMessage("Şifreniz en az 5 karakterden oluşmalıdır.")
                  .MaximumLength(16).WithMessage("Şifreniz en fazla 10 karakterden oluşmalıdır.")
                  .Matches(@"[A-Z]+").WithMessage("Şifreniz en az bir büyük harf içermelidir.")
                  .Matches(@"[a-z]+").WithMessage("Şifreniz en az bir küçük harf içermelidir.")
                  .Matches(@"[0-9]+").WithMessage("Şifreniz en az bir sayı içermelidir.");
        }
    }
}
