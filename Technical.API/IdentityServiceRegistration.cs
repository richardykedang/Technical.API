using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Technical.API.Data;
using Technical.API.Models;
using Technical.API.Repository.Auth;

namespace Technical.API
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MCFDatabaseConnectionString"));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthServices>();

            return services;
        }
         
    }
}
