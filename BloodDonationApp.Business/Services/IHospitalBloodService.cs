using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Services
{
    public interface IHospitalBloodService
    {
        Task AddNeedForBloodAsync(CreateNewHospitalBloodRequest request, int hospitalId);
        Task<IEnumerable<HospitalBloodsDisplayResponse>> GetHospitalNeedBloodListAsync(int hospitalId);
    }
}
