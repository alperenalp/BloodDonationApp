using BloodDonationApp.Business.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Services
{
    public interface IBloodService
    {
        Task<IEnumerable<BloodDisplayResponse>> GetAllBloodsAsync();
        Task<BloodDisplayResponse> GetBloodByIdAsync(int id);
        Task<string> GetBloodTypeByIdAsync(int bloodId);
    }
}
