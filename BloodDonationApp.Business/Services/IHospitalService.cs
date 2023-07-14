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
        Task DeleteHospitalAsync(int id);
        Task<HospitalDisplayResponse> GetHospitalByIdAsync(int id);
        Task<UpdateHospitalRequest> GetHospitalForUpdateAsync(int id);
        Task<IEnumerable<HospitalDisplayResponse>> GetHospitalListAsync();
        Task<string> GetHospitalNameByIdAsync(int id);
        Task<bool> IsHospitalExistsAsync(int id);
        Task UpdateHospitalAsync(UpdateHospitalRequest request);
    }
}
