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
    public class EFBloodRepository : IBloodRepository
    {
        private readonly BloodDonationAppDbContext _context;

        public EFBloodRepository(BloodDonationAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Blood entity)
        {
            _context.Bloods.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Bloods.FindAsync(id);
            _context.Bloods.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Blood>> GetAllAsync()
        {
            return await _context.Bloods.AsNoTracking().ToListAsync();
        }

        public async Task<Blood?> GetByIdAsync(int id)
        {
            return await _context.Bloods.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _context.Bloods.AnyAsync(x=>x.Id == id);
        }

        public async Task UpdateAsync(Blood entity)
        {
            _context.Bloods.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
