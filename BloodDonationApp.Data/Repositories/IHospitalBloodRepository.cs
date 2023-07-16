using BloodDonationApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Data.Repositories
{
    public interface IHospitalBloodRepository
    {
        Task<HospitalBlood?> GetHospitalBloodAsync(int hospitalId, int bloodId);
        Task<bool> isExists(int bloodId, int hospitalId);
        Task UpdateHospitalBloodAsync(HospitalBlood hospitalBlood);
    }
}
