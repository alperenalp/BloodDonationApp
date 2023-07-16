using System.ComponentModel.DataAnnotations;

namespace BloodDonationApp.WebApp.Models.Hospital
{
    public class ListHospitalBloodVM
    {
        [Display(Name = "Kan Grubu")]
        public string BloodType { get; set; }
        [Display(Name = "Kan İhtiyacı")]
        public int Quantity { get; set; }
    }
}
