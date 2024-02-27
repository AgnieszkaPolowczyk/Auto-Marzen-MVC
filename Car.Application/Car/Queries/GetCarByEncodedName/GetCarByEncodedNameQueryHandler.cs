using AutoMapper;
using Car.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Car.Queries.GetCarByEncodedName
{
    internal class GetCarByEncodedNameQueryHandler : IRequestHandler<GetCarByEncodedNameQuery, CarDto>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarByEncodedNameQueryHandler(ICarRepository repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CarDto> Handle(GetCarByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetCarByEncodedName(request.EncodedName);
            var dto = _mapper.Map<CarDto>(car);
            return dto;
        }
    }
}
