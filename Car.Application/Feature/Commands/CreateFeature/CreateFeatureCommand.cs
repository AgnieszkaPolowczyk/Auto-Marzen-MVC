using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Feature.Commands.CreateFeature
{
    public class CreateFeatureCommand : FeatureDto, IRequest
    {
        public string CarEncodedName { get; set; } = default!;
    }
}
