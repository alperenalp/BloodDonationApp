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
        Task<IEnumerable<HospitalDisplayResponse>> GetHospitalListForNeedsBloodByBloodIdAsync(int bloodId);
        Task<IEnumerable<HospitalBloodsDisplayResponse>> GetHospitalBloodListAsync(int hospitalId);
        Task<bool> IsExistsBloodInHospital(int bloodId, int hospitalId);
        Task<UpdateHospitalBloodRequest> GetHospitalBloodForUpdateAsync(int hospitalId, int bloodId);
        Task UpdateHospitalBloodAsync(UpdateHospitalBloodRequest request);
        Task DeleteHospitalBloodAsync(int bloodId, int hospitalId);
    }
}
