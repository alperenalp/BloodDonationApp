using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Requests
{
    public class ValidateUserLoginRequest
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "En az 3 karakter giriniz. ")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
