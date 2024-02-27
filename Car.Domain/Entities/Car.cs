using Car.Application.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Price { get; set; } = default!;
        public string Make { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string Year { get; set; } = default!;
        public string Mileage { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public Details Details { get; set; } = default!;
        public string EncodedName { get; private set; } = default!;
        public string Image {  get; set; } = default!;
        public string Description { get; set; } = default!;

        public List<Domain.Entities.Feature> Features { get; set; } = new();
        public void EncodeName(int number)
        {
            EncodedName = (Make+" "+Model+" " +number.ToString()).ToLower().Replace(" ", "-");
        }

        public string CreatedById { get; set; } = default!;
        public ApplicationUser CreatedBy { get; set; } = default!;

    }
}
