using System.ComponentModel.DataAnnotations;

namespace BloodDonationApp.WebApp.Models.HospitalBlood
{
    public class EditHospitalBloodVM
    {
        public int HospitalId { get; set; }
        public int BloodId { get; set; }

        [Display(Name = "Kan Grubu")]
        public string? BloodType { get; set; }
        [Display(Name = "Kan İhtiyacı")]
        public int Quantity { get; set; }
    }
}
