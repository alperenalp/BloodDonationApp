using System.ComponentModel.DataAnnotations;

namespace BloodDonationApp.WebApp.Models.User
{
    public class HospitalUserVM
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
        public string HospitalName { get; set; }
    }
}
