using AutoMapper;
using Car.Application.ApplicationUser;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Feature.Commands.CreateFeature
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IMapper _mapper;
        private readonly IFeatureRepository _featureRepository;
        private readonly ICarRepository _carRepository;
        private readonly IUserContext _userContext;

        public CreateFeatureCommandHandler(IMapper mapper, IFeatureRepository featureRepository, ICarRepository carRepository, IUserContext userContext)
        {
            _mapper = mapper;   
            _featureRepository = featureRepository;
            _carRepository = carRepository;
            _userContext = userContext;
        }
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            var car = await _carRepository.GetCarByEncodedName(request.CarEncodedName);
            var isEdibable = user != null && car.CreatedById == user.Id;

            if (!isEdibable)
            {
                return;
            }
            var feature =  _mapper.Map<Domain.Entities.Feature>(request);


            feature.CarId = car.Id;

            await _featureRepository.CreateFeature(feature);

        }
    }
}
