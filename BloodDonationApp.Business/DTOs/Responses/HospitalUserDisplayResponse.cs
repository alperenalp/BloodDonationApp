using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Responses
{
    public class HospitalUserDisplayResponse
    {
        public int Id { get; set; }
        [Display(Name = "İsim")]
        public string? Name { get; set; }
        [Display(Name = "Soyisim")]
        public string? LastName { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = null!;
        [Display(Name = "Şifre")]
        public string Password { get; set; } = null!;
        [Display(Name = "Hastane")]
        public int HospitalId { get; set; }
    }
}
