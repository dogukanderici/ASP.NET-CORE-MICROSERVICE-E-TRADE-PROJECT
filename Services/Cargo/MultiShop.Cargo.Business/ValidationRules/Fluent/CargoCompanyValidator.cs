using FluentValidation;
using MultiShop.Cargo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.ValidationRules.Fluent
{
    public class CargoCompanyValidator : AbstractValidator<CargoCompany>
    {
        public CargoCompanyValidator()
        {
            RuleFor(cc => cc.CargoCompanyName).NotEmpty().WithMessage("Kargo Şirketi Adı Boş Bırakılamaz!");
        }
    }
}
