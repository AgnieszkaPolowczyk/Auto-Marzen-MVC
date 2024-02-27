using Car.Domain.Entities;
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
    public class FeatureRepository : IFeatureRepository
    {
        private readonly CarDbContext _dbContext;

        public FeatureRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateFeature(Domain.Entities.Feature feature)
        {
            _dbContext.Features.Add(feature);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Feature>> GetAllFeatures(string encodedName)
        {
            return await _dbContext.Features
                .Where(s=>s.Car.EncodedName == encodedName)
                .ToListAsync();
        }


    }
}
