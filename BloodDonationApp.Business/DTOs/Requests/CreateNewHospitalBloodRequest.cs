using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Requests
{
    public class CreateNewHospitalBloodRequest
    {
        [Display(Name = "Kan Grubu")]
        public int? BloodId { get; set; }

        [Display(Name = "Kan İhtiyacı")]
        public int? Quantity { get; set; }
    }
}
