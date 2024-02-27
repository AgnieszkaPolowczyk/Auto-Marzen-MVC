using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public int CarId { get; set; } = default!;
        public Car Car { get; set; } = default!;
    }
}
