using Car.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car
{
    public class CarDto
    {
        public string Price { get; set; } = default!;
        public string Make { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string Year { get; set; } = default!;
        public string Mileage { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string BodyType { get; set; } = default!;
        public string Color { get; set; } = default!;
        public string NumberOfDoors { get; set; } = default!;
        public string NumberofSeats { get; set; } = default!;
        public string FuelType { get; set; } = default!;
        public string Transmission { get; set; } = default!;
        public string Power { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public string? Vin { get; set; }
        public IFormFile? Photo { get; set; }
        public string? Image {  get; set; } 
        public string? EncodedName { get; set; }
        public string Description { get; set; } = default!;
        public bool IsEditable { get; set; } = default!;

    }
}
