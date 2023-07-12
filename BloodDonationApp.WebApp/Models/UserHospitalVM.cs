using System.ComponentModel.DataAnnotations;

namespace BloodDonationApp.WebApp.Models
{
    public class UserHospitalVM
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hastane adını giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Hastane Adı")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [MaxLength(15, ErrorMessage = "Lütfen 15 karakterden fazla giriş yapmayınız.")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
    }
}
