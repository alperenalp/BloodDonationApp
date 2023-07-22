using BloodDonationApp.Business.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddScoped<IHospitalBloodService, HospitalBloodService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IBloodService, BloodService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
