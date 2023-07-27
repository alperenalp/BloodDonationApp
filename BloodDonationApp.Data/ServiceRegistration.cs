using BloodDonationApp.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IHospitalRepository, EFHospitalRepository>();
            services.AddScoped<IBloodRepository, EFBloodRepository>();
            services.AddScoped<IHospitalBloodRepository, EFHospitalBloodRepository>();
        }
    }
}
