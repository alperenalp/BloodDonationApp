using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Requests
{
    public class CreateNewUserRequest
    {
        [Required(ErrorMessage = "Lütfen isminizi giriniz.")]
        [Display(Name = "İsim")]
        public string? Name { get; set; } = null!;
        [Required(ErrorMessage = "Lütfen soyisminizi giriniz.")]
        [Display(Name = "Soyisim")]
        public string? LastName { get; set; } = null!;
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Kan Grubu")]
        [Required(ErrorMessage = "Lütfen Kan grubunuzu seçiniz.")]
        public int? BloodId { get; set; }

        public string Type { get; set; }
    }
}
