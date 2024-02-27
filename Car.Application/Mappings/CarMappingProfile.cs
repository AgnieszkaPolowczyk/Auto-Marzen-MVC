using AutoMapper;
using Car.Application.Car;
using Car.Application.Car.Commands.CreateCar;
using Car.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Car.Application.Car.Commands.EditCar;
using Car.Application.ApplicationUser;

namespace Car.Application.Mappings
{
    public class CarMappingProfile : Profile
    {

        
        public CarMappingProfile(IUserContext userContext) {
         

            var user = userContext.GetCurrentUser();

            CreateMap<CreateCarCommand, Domain.Entities.Car>()
                .ForMember(c => c.Details, opt => opt.MapFrom(src => new Details()
                {
                    BodyType = src.BodyType,
                    Color = src.Color,
                    NumberOfDoors = src.NumberOfDoors,
                    NumberofSeats = src.NumberofSeats,
                    FuelType = src.FuelType,
                    Transmission = src.Transmission,
                    Power = src.Power,
                    Status = src.Status,
                    ContactNumber = src.ContactNumber,
                    Vin = src.Vin,
                }));
                

            CreateMap<Domain.Entities.Car, CarDto>()
                .ForMember(c => c.IsEditable, opt=>opt.MapFrom( src => src.CreatedById == user!.Id && user != null))
                .ForMember(c => c.BodyType, opt => opt.MapFrom(src => src.Details.BodyType))
                .ForMember(c => c.Color, opt => opt.MapFrom(src => src.Details.Color))
                .ForMember(c => c.NumberOfDoors, opt => opt.MapFrom(src => src.Details.NumberOfDoors))
                .ForMember(c => c.NumberofSeats, opt => opt.MapFrom(src => src.Details.NumberofSeats))
                .ForMember(c => c.FuelType, opt => opt.MapFrom(src => src.Details.FuelType))
                .ForMember(c => c.Transmission, opt => opt.MapFrom(src => src.Details.Transmission))
                .ForMember(c => c.Power, opt => opt.MapFrom(src => src.Details.Power))
                .ForMember(c => c.Status, opt => opt.MapFrom(src => src.Details.Status))
                .ForMember(c => c.ContactNumber, opt => opt.MapFrom(src => src.Details.ContactNumber))
                .ForMember(c => c.Vin, opt => opt.MapFrom(src => src.Details.Vin));

            CreateMap<CarDto, EditCarCommand>();

        }
    }
}
