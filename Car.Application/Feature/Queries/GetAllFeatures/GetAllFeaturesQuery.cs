using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Feature.Queries.GetAllFeatures
{
    public class GetAllFeaturesQuery: IRequest<IEnumerable<FeatureDto>>
    {
        public string EncodedName { get; set; } = default!;
        public GetAllFeaturesQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
