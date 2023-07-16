using BloodDonationApp.Data.Contexts;
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

    }
}
