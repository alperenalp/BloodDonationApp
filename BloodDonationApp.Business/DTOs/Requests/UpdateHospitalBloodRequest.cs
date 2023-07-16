using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Requests
{
    public class UpdateHospitalBloodRequest
    {
        public int HospitalId { get; set; }
        public int BloodId { get; set; }
        public int Quantity { get; set; }
    }
}
