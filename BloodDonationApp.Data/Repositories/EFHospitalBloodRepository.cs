using BloodDonationApp.Data.Contexts;
using BloodDonationApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Data.Repositories
{
    public class EFHospitalBloodRepository : IHospitalBloodRepository
    {
        private readonly BloodDonationAppDbContext _context;

        public EFHospitalBloodRepository(BloodDonationAppDbContext context)
        {
            _context = context;
        }

        public async Task<HospitalBlood?> GetHospitalBloodAsync(int hospitalId, int bloodId)
        {
            return await _context.HospitalBloods.SingleOrDefaultAsync(x => x.HospitalId == hospitalId && x.BloodId == bloodId);
        }

        public async Task<bool> isExists(int bloodId, int hospitalId)
        {
            return await _context.HospitalBloods.AnyAsync(x => x.HospitalId == hospitalId && x.BloodId == bloodId);
        }

        public async Task UpdateHospitalBloodAsync(HospitalBlood hospitalBlood)
        {
            _context.HospitalBloods.Update(hospitalBlood);
            await _context.SaveChangesAsync();
        }
    }
}
