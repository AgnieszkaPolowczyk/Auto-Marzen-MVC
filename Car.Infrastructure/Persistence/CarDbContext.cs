using Car.Application.ApplicationUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Persistence
{
    public class CarDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> options): base(options)
        {}
        public DbSet<Domain.Entities.Car> Cars { get; set; }
        public DbSet<Domain.Entities.Feature> Features { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.Car>()
                .OwnsOne(c => c.Details);

            modelBuilder.Entity<Domain.Entities.Car>()
                .HasMany(c => c.Features)
                .WithOne(f => f.Car)
                .HasForeignKey(f => f.CarId);

            modelBuilder.Entity<Domain.Entities.Car>()
                .HasOne(c => c.CreatedBy)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.CreatedById);
                    
        }


    }
}
