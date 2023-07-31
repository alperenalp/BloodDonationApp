using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.DTOs.Responses
{
    public class BloodDisplayResponse
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;
    }
}
