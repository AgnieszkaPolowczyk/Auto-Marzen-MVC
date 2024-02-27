using Car.Application.ApplicationUser;
using Car.Domain.Interfaces;
using Car.Infrastructure.Persistence;
using Car.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Car")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<CarDbContext>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();

        }
    }
}
