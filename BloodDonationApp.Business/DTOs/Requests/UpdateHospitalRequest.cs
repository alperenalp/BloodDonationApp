using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Requests
{
    public class UpdateHospitalRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hastane adını giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        [Display(Name = "Hastane Adı")]
        public string Name { get; set; } = null!;

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        [MaxLength(15, ErrorMessage = "Lütfen 15 karakterden fazla giriş yapmayınız.")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Hastane Seçiniz")]
        public int UserId { get; set; }


        

        
    }
}
