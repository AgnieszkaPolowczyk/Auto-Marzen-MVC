using AutoMapper;
using Car.Application.Feature;
using Car.Application.Feature.Commands.CreateFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Mappings
{
    public class FeatureMappingProfile: Profile
    {
        public FeatureMappingProfile()
        {
            CreateMap<CreateFeatureCommand, Domain.Entities.Feature>();
            CreateMap<Domain.Entities.Feature, FeatureDto>();
        }
    }
}
