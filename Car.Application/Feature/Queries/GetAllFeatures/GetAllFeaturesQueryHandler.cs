using AutoMapper;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Feature.Queries.GetAllFeatures
{
    public class GetAllFeaturesQueryHandler : IRequestHandler<GetAllFeaturesQuery, IEnumerable<FeatureDto>>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public GetAllFeaturesQueryHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeatureDto>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _featureRepository.GetAllFeatures(request.EncodedName);
            var dtos = _mapper.Map<IEnumerable<FeatureDto>>(features);
            return dtos;
        }
    }
}
