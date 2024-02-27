using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.ApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public List<Domain.Entities.Car> Cars { get; set; } = new();
    }
}
