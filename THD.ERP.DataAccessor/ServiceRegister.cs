using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using THD.ERP.DataAccessor.Data;
using THD.ERP.DataAccessor.Entities;

namespace THD.ERP.DataAccessor;

public static class ServiceRegister
{
    public static void AddDataAccessorLayer(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<HRMDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("HRMDb"), b =>
                b.MigrationsAssembly("THD.ERP")));
        
        services.AddIdentity<Employee, ApplicationRole>()
            .AddEntityFrameworkStores<HRMDbContext>()
            .AddDefaultTokenProviders();
        
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.User.RequireUniqueEmail = true;
        });
    }
}