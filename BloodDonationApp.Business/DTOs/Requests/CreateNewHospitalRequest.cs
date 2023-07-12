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
        public string Name { get; set; } = null!;
        
        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int UserId { get; set; }

    }
}
