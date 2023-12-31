﻿using BloodDonationApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Data.Repositories
{
    public interface IHospitalRepository : IRepository<Hospital>
    {
        Task<Hospital> GetHospitalByIdWithBloodsAsync(int id);
        Task<IList<Hospital>> GetHospitalListForNeedsBloodByBloodIdAsync(int bloodId);
    }
}
