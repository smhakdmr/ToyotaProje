using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.LicencePlate).NotEmpty().WithMessage("Plaka alanı boş bırakılamaz.");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Marka alanı boş bırakılamaz.");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model alanı boş bırakılamaz.");
            RuleFor(x => x.Km).NotEmpty().WithMessage("KM Bilgisi alanı boş bırakılamaz.");
            RuleFor(x => x.ArrivalDate).NotEmpty().WithMessage("Servise Geliş Tarihi alanı boş bırakılamaz.");
        }
    }
}
