using Car.Domain.Interfaces;
using Car.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _dbContext;

        public CarRepository(CarDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

		public async Task Commit()
		{
            await _dbContext.SaveChangesAsync();
		}

		public async Task Create (Domain.Entities.Car car)
        {
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarByEncodedName(string encodedName)
        {
            var car = await _dbContext.Cars.FirstAsync(c => c.EncodedName == encodedName);
            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Car>> GetAllCars()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task<Domain.Entities.Car> GetCarByEncodedName(string encodedName)
        {
            return await _dbContext.Cars.FirstAsync(c => c.EncodedName == encodedName);
        }

        public async Task<Domain.Entities.Car?> GetLastCar()
        {
            return await _dbContext.Cars.OrderBy(c => c.Id).LastOrDefaultAsync();
        }
    }
}
