using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Requests
{
    public class CreateNewHospitalRequest
    {
        [Required(ErrorMessage = "Lütfen isminizi giriniz.")]
        [Display(Name = "İsim")]
        public string Name { get; set; } = null!;
        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; } = null!;
    }
}
