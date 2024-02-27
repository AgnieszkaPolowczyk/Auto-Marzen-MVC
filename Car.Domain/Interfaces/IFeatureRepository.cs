using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Domain.Interfaces
{
    public interface IFeatureRepository
    {
        Task CreateFeature(Domain.Entities.Feature feature);
        Task <IEnumerable<Domain.Entities.Feature>> GetAllFeatures(string encodedName);

    }
}
