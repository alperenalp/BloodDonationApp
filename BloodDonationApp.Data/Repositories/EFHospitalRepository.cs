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
    public class EFHospitalRepository : IHospitalRepository
    {
        private readonly BloodDonationAppDbContext _context;

        public EFHospitalRepository(BloodDonationAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return hospital.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Hospital>> GetAllAsync()
        {
            return await _context.Hospitals.AsNoTracking().ToListAsync();
        }

        public Task<Hospital?> GetByIdAsync(int id)
        {
            return _context.Hospitals.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _context.Hospitals.AnyAsync(x=> x.Id == id);   
        }

        public async Task UpdateAsync(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            await _context.SaveChangesAsync();
        }
    }
}
