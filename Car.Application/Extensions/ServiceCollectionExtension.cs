using Car.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Car.Application.Car.Commands.CreateCar;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Car.Application.Car.Commands.EditCar;
using Car.Application.ApplicationUser;


namespace Car.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            services.AddScoped<IUserContext, UserContext>();
            // services.AddAutoMapper(typeof(CarMappingProfile));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var usercontext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new CarMappingProfile(usercontext));
                cfg.AddProfile(new FeatureMappingProfile());

            }).CreateMapper()
            );
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCarCommand).Assembly));
            services.AddValidatorsFromAssemblyContaining<EditCarCommand>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            
        }
    }
}
