using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Entities
{
    public class Details
    {
        public string BodyType { get; set; } = default!;
        public string Color { get; set; } = default!;
        public string NumberOfDoors { get; set; } = default!;
        public string NumberofSeats { get; set; } = default!;
        public string FuelType { get; set; } = default!;
        public string Transmission { get; set; } = default!;
        public string Power { get; set; } = default!;
        public string Status{ get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public string? Vin { get; set; }
        
    }
}
