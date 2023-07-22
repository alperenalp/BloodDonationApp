using BloodDonationApp.Business.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Features.Queries.GetAllHospital
{
    public class GetAllHospitalQueryResponse
    {
        public IEnumerable<HospitalDisplayResponse> Hospitals { get; set; }
    }
}
