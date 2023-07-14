using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business.Services
{
    public interface IUserService
    {
        Task<int> CreateHospitalUserAsync(CreateNewHospitalUserRequest request);
        Task<int> CreateUserAsync(CreateNewUserRequest request);
        Task<IEnumerable<HospitalUserDisplayResponse>> GetHospitalUserListAsync();
        Task<UserDisplayResponse> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDisplayResponse>> GetUserListAsync();
        Task<UserValidateResponse> ValidateUserAsync(ValidateUserLoginRequest request);
    }
}
