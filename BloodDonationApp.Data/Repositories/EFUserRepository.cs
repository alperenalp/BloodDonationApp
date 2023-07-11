using BloodDonationApp.Contexts;
using BloodDonationApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Data.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly BloodDonationAppDbContext _context;

        public EFUserRepository(BloodDonationAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(x => x.Id == id);  
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
