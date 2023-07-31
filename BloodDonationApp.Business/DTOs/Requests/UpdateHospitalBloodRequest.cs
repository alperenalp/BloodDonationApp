using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Requests
{
    public class UpdateHospitalBloodRequest
    {
        [Display(Name = "Hastane")]
        public int HospitalId { get; set; }
        [Display(Name = "Kan Grubu")]
        public int BloodId { get; set; }
        [Display(Name = "Kan Ünitesi İhtiyacı")]
        [Range(1, int.MaxValue, ErrorMessage = "Değer 1 veya daha büyük bir sayı olmalıdır.")]
        public int Quantity { get; set; }
    }
}
