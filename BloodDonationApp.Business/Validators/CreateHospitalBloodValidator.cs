using BloodDonationApp.Business.DTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Validators
{
    public class CreateHospitalBloodValidator : AbstractValidator<CreateNewHospitalBloodRequest>
    {
        public CreateHospitalBloodValidator()
        {
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Kan miktarı boş geçilemez.");
            RuleFor(x => x.BloodId).NotEmpty().WithMessage("Kan grubu boş geçilemez. ");
        }
    }
}
