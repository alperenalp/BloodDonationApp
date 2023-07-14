using BloodDonationApp.Business.Services;
using BloodDonationApp.Business.Services.Mappings;
using BloodDonationApp.Data.Contexts;
using BloodDonationApp.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IHospitalRepository, EFHospitalRepository>();
builder.Services.AddScoped<IBloodService, BloodService>();
builder.Services.AddScoped<IBloodRepository, EFBloodRepository>();
builder.Services.AddScoped<IHospitalBloodService, HospitalBloodService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<BloodDonationAppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/Users/Login";
                    opt.AccessDeniedPath = "/Users/AccessDenied";
                    opt.ReturnUrlParameter = "returnUrl";
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
