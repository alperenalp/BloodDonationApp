using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Services
{
    public interface IHospitalService
    {
        Task CreateHospitalAsync(CreateNewHospitalRequest request);
        Task<IEnumerable<HospitalDisplayResponse>> GetHospitalListAsync();
    }
}
