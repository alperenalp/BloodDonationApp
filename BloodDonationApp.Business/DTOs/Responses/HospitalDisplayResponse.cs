using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Responses
{
    public class HospitalDisplayResponse
    {
        public int Id { get; set; }

        [Display(Name="Hastane Adı")]
        public string Name { get; set; } = null!;

        [Display(Name="Adres")]
        public string? Address { get; set; }

        [Display(Name="Telefon")]
        public string? Phone { get; set; }
    }
}
